namespace GUI
{
    partial class User_MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.btnTheoDoiDonHang = new System.Windows.Forms.Button();
            this.btn_taiKhoan = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnContact = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(271, 74);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1130, 654);
            this.mainPanel.TabIndex = 3;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.sidebar.Controls.Add(this.label1);
            this.sidebar.Controls.Add(this.btnHome);
            this.sidebar.Controls.Add(this.btnDashboard);
            this.sidebar.Controls.Add(this.btnTaoDonHang);
            this.sidebar.Controls.Add(this.btnTheoDoiDonHang);
            this.sidebar.Controls.Add(this.btn_taiKhoan);
            this.sidebar.Controls.Add(this.btnAbout);
            this.sidebar.Controls.Add(this.btnContact);
            this.sidebar.Controls.Add(this.btnDangXuat);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 74);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(271, 654);
            this.sidebar.TabIndex = 5;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnHome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnHome.Location = new System.Drawing.Point(13, 26);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(242, 55);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "🏠 Trang chủ";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnDashboard.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnDashboard.Location = new System.Drawing.Point(13, 99);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(242, 55);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.BackColor = System.Drawing.Color.White;
            this.btnTaoDonHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTaoDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoDonHang.FlatAppearance.BorderSize = 0;
            this.btnTaoDonHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnTaoDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDonHang.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnTaoDonHang.Location = new System.Drawing.Point(13, 175);
            this.btnTaoDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Size = new System.Drawing.Size(242, 55);
            this.btnTaoDonHang.TabIndex = 2;
            this.btnTaoDonHang.Text = "📝 Gửi hàng";
            this.btnTaoDonHang.UseVisualStyleBackColor = false;
            this.btnTaoDonHang.Click += new System.EventHandler(this.btnTaoDonHang_Click);
            // 
            // btnTheoDoiDonHang
            // 
            this.btnTheoDoiDonHang.BackColor = System.Drawing.Color.White;
            this.btnTheoDoiDonHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTheoDoiDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheoDoiDonHang.FlatAppearance.BorderSize = 0;
            this.btnTheoDoiDonHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnTheoDoiDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheoDoiDonHang.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnTheoDoiDonHang.Location = new System.Drawing.Point(13, 249);
            this.btnTheoDoiDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTheoDoiDonHang.Name = "btnTheoDoiDonHang";
            this.btnTheoDoiDonHang.Size = new System.Drawing.Size(242, 55);
            this.btnTheoDoiDonHang.TabIndex = 0;
            this.btnTheoDoiDonHang.Text = "📦 Theo dõi trạng thái";
            this.btnTheoDoiDonHang.UseVisualStyleBackColor = false;
            this.btnTheoDoiDonHang.Click += new System.EventHandler(this.btnTheoDoiDonHang_Click);
            // 
            // btn_taiKhoan
            // 
            this.btn_taiKhoan.BackColor = System.Drawing.Color.White;
            this.btn_taiKhoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_taiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_taiKhoan.FlatAppearance.BorderSize = 0;
            this.btn_taiKhoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btn_taiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taiKhoan.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_taiKhoan.Location = new System.Drawing.Point(13, 325);
            this.btn_taiKhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_taiKhoan.Name = "btn_taiKhoan";
            this.btn_taiKhoan.Size = new System.Drawing.Size(242, 55);
            this.btn_taiKhoan.TabIndex = 4;
            this.btn_taiKhoan.Text = "👤 Tài khoản";
            this.btn_taiKhoan.UseVisualStyleBackColor = false;
            this.btn_taiKhoan.Click += new System.EventHandler(this.btn_taiKhoan_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.White;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnAbout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnAbout.Location = new System.Drawing.Point(13, 435);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(242, 55);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "ℹ️ About Us";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnContact
            // 
            this.btnContact.BackColor = System.Drawing.Color.White;
            this.btnContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContact.FlatAppearance.BorderSize = 0;
            this.btnContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnContact.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContact.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnContact.Location = new System.Drawing.Point(13, 511);
            this.btnContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(242, 55);
            this.btnContact.TabIndex = 6;
            this.btnContact.Text = "📞 Liên hệ";
            this.btnContact.UseVisualStyleBackColor = false;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.White;
            this.btnDangXuat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnDangXuat.Location = new System.Drawing.Point(13, 586);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(242, 55);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "🔓 Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.DarkTurquoise;
            this.header.Controls.Add(this.lblWelcome);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1401, 74);
            this.header.TabIndex = 4;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 18);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(331, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "👋 Xin chào, Họ Tên!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "---------------------------------";
            // 
            // User_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 728);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "User_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Main Form";
            this.Load += new System.EventHandler(this.User_MainForm_Load);
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel header;

        private System.Windows.Forms.Label lblWelcome;

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Button btnTheoDoiDonHang;
        private System.Windows.Forms.Button btn_taiKhoan;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label label1;
    }
}
