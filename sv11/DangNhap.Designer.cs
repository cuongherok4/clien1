namespace Đăng_nhập__đăng_xuất
{
    partial class DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel_QuyenMatKhau = new System.Windows.Forms.LinkLabel();
            this.textBox_MatKhau = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox_TentaiKhoan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btndangki = new System.Windows.Forms.Button();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.chkhienthi = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel_QuyenMatKhau
            // 
            this.linkLabel_QuyenMatKhau.AutoEllipsis = true;
            this.linkLabel_QuyenMatKhau.AutoSize = true;
            this.linkLabel_QuyenMatKhau.DisabledLinkColor = System.Drawing.Color.Lime;
            this.linkLabel_QuyenMatKhau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_QuyenMatKhau.ForeColor = System.Drawing.Color.Lime;
            this.linkLabel_QuyenMatKhau.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel_QuyenMatKhau.LinkColor = System.Drawing.Color.CadetBlue;
            this.linkLabel_QuyenMatKhau.Location = new System.Drawing.Point(98, 303);
            this.linkLabel_QuyenMatKhau.Name = "linkLabel_QuyenMatKhau";
            this.linkLabel_QuyenMatKhau.Size = new System.Drawing.Size(136, 19);
            this.linkLabel_QuyenMatKhau.TabIndex = 1;
            this.linkLabel_QuyenMatKhau.TabStop = true;
            this.linkLabel_QuyenMatKhau.Text = "Quyên mật khẩu?";
            this.linkLabel_QuyenMatKhau.UseWaitCursor = true;
            this.linkLabel_QuyenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_QuyenMatKhau_LinkClicked);
            // 
            // textBox_MatKhau
            // 
            this.textBox_MatKhau.BackColor = System.Drawing.Color.White;
            this.textBox_MatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_MatKhau.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MatKhau.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_MatKhau.Location = new System.Drawing.Point(25, 158);
            this.textBox_MatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_MatKhau.Multiline = true;
            this.textBox_MatKhau.Name = "textBox_MatKhau";
            this.textBox_MatKhau.PasswordChar = '●';
            this.textBox_MatKhau.Size = new System.Drawing.Size(276, 40);
            this.textBox_MatKhau.TabIndex = 2;
            this.textBox_MatKhau.TextChanged += new System.EventHandler(this.textBox_MatKhau_TextChanged);
            // 
            // textBox_TentaiKhoan
            // 
            this.textBox_TentaiKhoan.BackColor = System.Drawing.Color.White;
            this.textBox_TentaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TentaiKhoan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TentaiKhoan.Location = new System.Drawing.Point(25, 97);
            this.textBox_TentaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_TentaiKhoan.Multiline = true;
            this.textBox_TentaiKhoan.Name = "textBox_TentaiKhoan";
            this.textBox_TentaiKhoan.Size = new System.Drawing.Size(276, 41);
            this.textBox_TentaiKhoan.TabIndex = 2;
            this.textBox_TentaiKhoan.TextChanged += new System.EventHandler(this.TenTKtextBox__TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "LOGIN";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btndangki);
            this.groupBox1.Controls.Add(this.btn_dangnhap);
            this.groupBox1.Controls.Add(this.chkhienthi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_TentaiKhoan);
            this.groupBox1.Controls.Add(this.textBox_MatKhau);
            this.groupBox1.Controls.Add(this.linkLabel_QuyenMatKhau);
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(517, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 406);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btndangki
            // 
            this.btndangki.AutoSize = true;
            this.btndangki.BackColor = System.Drawing.Color.White;
            this.btndangki.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangki.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btndangki.Location = new System.Drawing.Point(30, 333);
            this.btndangki.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndangki.Name = "btndangki";
            this.btndangki.Size = new System.Drawing.Size(276, 37);
            this.btndangki.TabIndex = 10;
            this.btndangki.Text = "Đăng kí";
            this.btndangki.UseVisualStyleBackColor = false;
            this.btndangki.Click += new System.EventHandler(this.btndangki_Click);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.AutoSize = true;
            this.btn_dangnhap.BackColor = System.Drawing.Color.White;
            this.btn_dangnhap.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dangnhap.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_dangnhap.Location = new System.Drawing.Point(30, 253);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(276, 37);
            this.btn_dangnhap.TabIndex = 10;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // chkhienthi
            // 
            this.chkhienthi.AutoSize = true;
            this.chkhienthi.Location = new System.Drawing.Point(30, 213);
            this.chkhienthi.Name = "chkhienthi";
            this.chkhienthi.Size = new System.Drawing.Size(133, 20);
            this.chkhienthi.TabIndex = 8;
            this.chkhienthi.Text = "Hiển thị mật khẩu ";
            this.chkhienthi.UseVisualStyleBackColor = true;
            this.chkhienthi.CheckedChanged += new System.EventHandler(this.chkhienthi_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pasword:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Name:";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::sv11.Properties.Resources.Lovepik_com_450092251_online_chat_flat_illustration_communication_over_the_internet_1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 438);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(904, 547);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "server";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_MatKhau;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox_TentaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel_QuyenMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.CheckBox chkhienthi;
        private System.Windows.Forms.Button btndangki;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}