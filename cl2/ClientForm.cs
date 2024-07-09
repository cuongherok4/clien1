using Đăng_nhập__đăng_xuất;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClientsFormsMultiThread
{
    public partial class Client : Form
    {
        private TcpClient client;           // Đối tượng TcpClient để kết nối tới server
        private NetworkStream clientStream; // Luồng dữ liệu của client

        public Client()
        {
            InitializeComponent();
            client = new TcpClient();       // Khởi tạo TcpClient
        }

        private void btnConnect_Load(object sender, EventArgs e)
        {
            client.Connect("127.0.0.1", 5000); // Kết nối tới địa chỉ IP và cổng của server
            clientStream = client.GetStream(); // Lấy luồng dữ liệu từ TcpClient

            // Khởi tạo một luồng đọc tin nhắn từ server
            Thread readThread = new Thread(new ThreadStart(ReadMessages));
            readThread.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người gửi", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtInput.Text.StartsWith(@"C:\") || (txtInput.Text.StartsWith(@"D:\")))
            {
                string filePath = txtInput.Text;
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = File.ReadAllBytes(filePath);
                long fileSize = fileData.Length;

                // Tạo header để gửi file
                string header = $"file:{fileName}:{fileSize}";
                byte[] headerData = Encoding.ASCII.GetBytes(header);

                // Gửi header trước
                clientStream.Write(headerData, 0, headerData.Length);
                clientStream.Flush();

                // Gửi dữ liệu file
                clientStream.Write(fileData, 0, fileData.Length);
                clientStream.Flush();

                AppendMessage($" Me:  '{fileName}'");
                txtInput.ResetText();
            }
            else
            {
                string message1 = txtInput.Text; // Lấy nội dung tin nhắn từ textbox
                string message = txtname.Text + " say to: " + txtInput.Text; // Tạo nội dung tin nhắn gửi đi
                byte[] buffer = Encoding.ASCII.GetBytes(message); // Chuyển đổi tin nhắn thành mảng byte
                clientStream.Write(buffer, 0, buffer.Length); // Gửi tin nhắn qua luồng dữ liệu
                clientStream.Flush(); // Đẩy dữ liệu đi

                AppendMessage($"Me: {message1}"); // Hiển thị tin nhắn của mình lên khung chat
                txtInput.Clear(); // Xóa nội dung textbox để chuẩn bị tin nhắn mới
            }
        }

        private void ReadMessages()
        {
            byte[] message = new byte[4096]; // Mảng byte để lưu tin nhắn nhận được
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096); // Đọc dữ liệu từ luồng dữ liệu của client
                }
                catch
                {
                    AppendMessage("Đã ngắt kết nối từ server..."); // Xử lý khi bị ngắt kết nối từ server
                    break;
                }

                if (bytesRead == 0)
                {
                    AppendMessage("Đã ngắt kết nối từ server..."); // Xử lý khi server ngắt kết nối
                    break;
                }

                string serverMessage = Encoding.ASCII.GetString(message, 0, bytesRead); // Chuyển mảng byte thành chuỗi tin nhắn từ server

                // Kiểm tra nếu tin nhắn là dữ liệu file
                if (serverMessage.StartsWith("file:"))
                {
                    string[] parts = serverMessage.Split(':');
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
                        string savePath = Path.Combine(@"C:\Users\default.LAPTOP-RKT9HVC4\OneDrive\Máy tính\clien1\cl02", fileName);

                        File.WriteAllBytes(savePath, fileData);

                        outMessage($">>> send to '{fileName}'");

                    }
                }
                else
                {
                    // Xử lý tin nhắn văn bản bình thường
                    outMessage($"send  {serverMessage}"); // Hiển thị tin nhắn từ server lên khung chat
                }
            }
        }


        private void outMessage(string message)
        {
            if (txtouput.InvokeRequired)
            {
                // Nếu gọi từ một luồng khác, thực hiện invoke để thêm tin nhắn vào textbox
                txtouput.Invoke(new MethodInvoker(delegate { AppendOutput(message); }));
            }
            else
            {
                // Thêm tin nhắn vào khung chat
                AppendOutput(message);
            }
        }

        private void AppendOutput(string message)
        {
            // Thêm tin nhắn vào khung chat
            txtouput.AppendText(message + Environment.NewLine);
        }

        private void AppendMessage(string message)
        {
            if (txtMessages.InvokeRequired)
            {
                // Nếu gọi từ một luồng khác, thực hiện invoke để thêm tin nhắn vào textbox
                txtMessages.Invoke(new MethodInvoker(delegate { AppendMessage(message); }));
            }
            else
            {
                // Thêm tin nhắn vào khung chat
                txtMessages.AppendText(message + Environment.NewLine);
            }
        }



        private void txtMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtouput_TextChanged(object sender, EventArgs e)
        {

        }



        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            // Xác nhận người dùng muốn đóng kết nối
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng kết nối?", "Xác nhận đóng kết nối", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                clientStream.Close();
                client.Close();

                // Ẩn cửa sổ Client
                this.Hide();
            }


        }

        private void btnfile_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người gửi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtInput.Text = openFileDialog.FileName;
                    //string filePath = openFileDialog.FileName;
                    //string fileName = Path.GetFileName(filePath);
                    //byte[] fileData = File.ReadAllBytes(filePath);
                    //long fileSize = fileData.Length;

                    //// Tạo header để gửi file
                    //string header = $"file:{fileName}:{fileSize}";
                    //byte[] headerData = Encoding.ASCII.GetBytes(header);

                    //// Gửi header trước
                    //clientStream.Write(headerData, 0, headerData.Length);
                    //clientStream.Flush();

                    //// Gửi dữ liệu file
                    //clientStream.Write(fileData, 0, fileData.Length);
                    //clientStream.Flush();

                    //AppendMessage($" Me:  '{fileName}'");
                }
            }
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
