using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ServerFormsMultiThread
{
    public partial class ServerForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ACER-NITRO-5-20\SQLEXPRESS01;Initial Catalog=DuanNet;Integrated Security=True;");

        private void opencon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void closecon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private Boolean Exe(string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closecon();
            return check;
        }

        private DataTable Red(String cmd, out string errorMessage)
        {
            opencon();
            DataTable dt = new DataTable();
            errorMessage = string.Empty;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (SqlException ex)
            {
                dt = null;
                errorMessage = ex.Message; // Lưu thông báo lỗi cụ thể
            }
            catch (Exception ex)
            {
                dt = null;
                errorMessage = "Lỗi không xác định: " + ex.Message;
            }
            closecon();
            return dt;
        }

        private void load()
        {
            string errorMessage;
            DataTable dt = Red("SELECT * FROM TaiKhoan", out errorMessage);
            if (dt != null)
            {
                dgv.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ SQL Server: " + errorMessage);
            }
        }

        private TcpListener server;          // Đối tượng TcpListener để lắng nghe kết nối từ clients
        private Thread listenThread;         // Luồng lắng nghe kết nối từ clients
        private List<TcpClient> connectedClients; // Danh sách các TcpClient đang kết nối tới server

        public ServerForm()
        {
            InitializeComponent();
            connectedClients = new List<TcpClient>(); // Khởi tạo danh sách TcpClient
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            load();
            server = new TcpListener(IPAddress.Any, 5000); // Khởi tạo TcpListener với IP và cổng 5000
            listenThread = new Thread(new ThreadStart(ListenForClients)); // Khởi tạo luồng lắng nghe clients
            listenThread.Start(); // Bắt đầu lắng nghe kết nối từ clients
            AppendMessage("Server đang chờ kết nối...."); // Hiển thị thông báo server đang chờ kết nối
        }

        private void ListenForClients()
        {
            server.Start(); // Bắt đầu lắng nghe kết nối từ clients

            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); // Chấp nhận kết nối từ một client
                connectedClients.Add(client); // Thêm client vào danh sách các client đã kết nối
                AppendConnection(client.Client.RemoteEndPoint.ToString()); // Hiển thị thông tin kết nối của client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client); // Khởi động một luồng để xử lý giao tiếp với client này
            }
        }

        private void HandleClientComm(object client_obj)
        {
            TcpClient tcpClient = (TcpClient)client_obj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string clientMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                if (clientMessage.StartsWith("file:"))
                {
                    // Nhận file từ client
                    string[] parts = clientMessage.Split(':');
                    if (parts.Length >= 3)
                    {
                        string fileName = parts[1];
                        long fileSize = long.Parse(parts[2]);

                        // Đọc dữ liệu file từ luồng
                        byte[] fileData = new byte[fileSize];
                        int totalBytesRead = 0;
                        while (totalBytesRead < fileSize)
                        {
                            int bytesReadFromFile = clientStream.Read(fileData, totalBytesRead, (int)fileSize - totalBytesRead);
                            totalBytesRead += bytesReadFromFile;
                        }

                        // Lưu file vào đường dẫn mong muốn
                        string savePath = Path.Combine(@"C:\Users\default.LAPTOP-RKT9HVC4\OneDrive\Máy tính\clien1\sv-1", fileName);
                        File.WriteAllBytes(savePath, fileData);

                        AppendMessage($"File '{fileName}' ");

                        // Gửi file tới tất cả các client khác
                        foreach (TcpClient client in connectedClients)
                        {
                            if (client != tcpClient) // Bỏ qua client gửi tin nhắn gốc
                            {
                                NetworkStream stream = client.GetStream();
                                string headerMessage = $"file:{fileName}:{fileSize}";
                                byte[] headerBytes = Encoding.ASCII.GetBytes(headerMessage);
                                stream.Write(headerBytes, 0, headerBytes.Length);
                                stream.Flush();

                                // Gửi dữ liệu file
                                stream.Write(fileData, 0, fileData.Length);
                                stream.Flush();

                                //AppendMessage($"File '{fileName}' đã được gửi tới client {client.Client.RemoteEndPoint}");
                            }
                        }
                    }
                }
                else
                {
                    AppendMessage($"Client: {clientMessage}");

                    // Gửi tin nhắn từ client này tới tất cả các client khác
                    foreach (TcpClient client in connectedClients)
                    {
                        if (client != tcpClient) // Bỏ qua client gửi tin nhắn gốc
                        {
                            NetworkStream stream = client.GetStream();
                            byte[] broadcastMessage = Encoding.ASCII.GetBytes(clientMessage);
                            stream.Write(broadcastMessage, 0, broadcastMessage.Length);
                            stream.Flush();
                        }
                    }
                }
            }

            connectedClients.Remove(tcpClient);
            RemoveConnection(tcpClient.Client.RemoteEndPoint.ToString());
            tcpClient.Close();
        }



        private void AppendMessage(string message)
        {
            if (txtMessages1.InvokeRequired)
            {
                // Sử dụng invoke để thêm tin nhắn vào textbox từ một luồng khác
                txtMessages1.Invoke(new MethodInvoker(delegate { AppendMessage(message); }));
            }
            else
            {
                // Thêm tin nhắn vào textbox
                txtMessages1.AppendText(message + Environment.NewLine);
            }
        }

        private void AppendConnection(string connection)
        {
            if (listconnect.InvokeRequired)
            {
                // Sử dụng invoke để thêm kết nối vào danh sách từ một luồng khác
                listconnect.Invoke(new MethodInvoker(delegate { AppendConnection(connection); }));
            }
            else
            {
                // Thêm kết nối vào danh sách
                listconnect.Items.Add(connection);
            }
        }

        private void RemoveConnection(string connection)
        {
            if (listconnect.InvokeRequired)
            {
                // Sử dụng invoke để xóa kết nối từ danh sách từ một luồng khác
                listconnect.Invoke(new MethodInvoker(delegate { RemoveConnection(connection); }));
            }
            else
            {
                // Xóa kết nối từ danh sách
                listconnect.Items.Remove(connection);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Đóng tất cả các kết nối khi form đóng lại
            foreach (var client in connectedClients)
            {
                client.Close();
            }
            base.OnFormClosing(e);
        }

        private void txtMessages1_TextChanged(object sender, EventArgs e)
        {

        }

       private void btnsend_Click(object sender, EventArgs e)
{
    // Lấy thông tin về client được chọn từ listconnect
    if (listconnect.SelectedItem != null)
    {
        string selectedClient = listconnect.SelectedItem.ToString();

        // Tìm TcpClient tương ứng với client được chọn
        TcpClient targetClient = connectedClients.FirstOrDefault(client =>
            client.Client.RemoteEndPoint.ToString() == selectedClient);

        if (targetClient != null)
        {
            try
            {
                // Gửi dữ liệu đến client được chọn
                NetworkStream stream = targetClient.GetStream();
                string messageToSend = "Server sayd: "+txtmessage.Text;
                byte[] messageBytes = Encoding.ASCII.GetBytes(messageToSend);
                stream.Write(messageBytes, 0, messageBytes.Length);
                stream.Flush();

                // Hiển thị tin nhắn đã gửi trên giao diện server
                AppendMessage($"Đã gửi tới client {selectedClient}: {messageToSend}");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ khi gửi dữ liệu không thành công
                MessageBox.Show($"Lỗi khi gửi dữ liệu đến client {selectedClient}: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show($"Không thể tìm thấy client {selectedClient} trong danh sách kết nối.");
        }
    }
    else
    {
        MessageBox.Show("Vui lòng chọn một client từ danh sách kết nối để gửi dữ liệu.");
    }
    txtmessage.ResetText();
}

        private void btnSendToAll_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có kết nối nào hay chưa
            if (connectedClients.Count > 0)
            {
                // Chuỗi tin nhắn muốn gửi
                string messageToSend = "server : "+ txtmessage.Text;

                // Chuyển đổi tin nhắn thành mảng byte
                byte[] messageBytes = Encoding.ASCII.GetBytes(messageToSend);

                // Lặp qua danh sách các client và gửi tin nhắn đến từng client
                foreach (TcpClient client in connectedClients)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(messageBytes, 0, messageBytes.Length);
                        stream.Flush();

                        // Hiển thị tin nhắn đã gửi trên giao diện server
                        AppendMessage($"Đã gửi tới client {client.Client.RemoteEndPoint.ToString()}: {messageToSend}");
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ khi gửi dữ liệu không thành công
                        MessageBox.Show($"Lỗi khi gửi dữ liệu đến client {client.Client.RemoteEndPoint.ToString()}: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có client nào kết nối đến server.");
            }
            txtmessage.ResetText();
        }

        private void btnfile_Click(object sender, EventArgs e)
        {

        }

        private void txtMessages1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
