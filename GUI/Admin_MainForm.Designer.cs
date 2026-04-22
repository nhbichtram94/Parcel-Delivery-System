namespace GUI
{
    partial class Admin_MainForm
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
            this.btn_backup_restore = new System.Windows.Forms.Button();
            this.btn_QLThanhToan = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Azure;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(293, 74);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(942, 551);
            this.mainPanel.TabIndex = 3;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Ivory;
            this.sidebar.Controls.Add(this.label1);
            this.sidebar.Controls.Add(this.btn_backup_restore);
            this.sidebar.Controls.Add(this.btn_QLThanhToan);
            this.sidebar.Controls.Add(this.btnDangXuat);
            this.sidebar.Controls.Add(this.btnTaiKhoan);
            this.sidebar.Controls.Add(this.btnDonHang);
            this.sidebar.Controls.Add(this.btnPhanCong);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidebar.Location = new System.Drawing.Point(0, 74);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(293, 551);
            this.sidebar.TabIndex = 5;
            // 
            // btn_backup_restore
            // 
            this.btn_backup_restore.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_backup_restore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_backup_restore.FlatAppearance.BorderSize = 0;
            this.btn_backup_restore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backup_restore.ForeColor = System.Drawing.Color.Black;
            this.btn_backup_restore.Location = new System.Drawing.Point(33, 405);
            this.btn_backup_restore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_backup_restore.Name = "btn_backup_restore";
            this.btn_backup_restore.Size = new System.Drawing.Size(226, 49);
            this.btn_backup_restore.TabIndex = 0;
            this.btn_backup_restore.Text = "🔁 Backup/Restore";
            this.btn_backup_restore.UseVisualStyleBackColor = false;
            this.btn_backup_restore.Click += new System.EventHandler(this.btn_backup_restore_Click);
            // 
            // btn_QLThanhToan
            // 
            this.btn_QLThanhToan.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_QLThanhToan.FlatAppearance.BorderSize = 0;
            this.btn_QLThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLThanhToan.ForeColor = System.Drawing.Color.Black;
            this.btn_QLThanhToan.Location = new System.Drawing.Point(33, 259);
            this.btn_QLThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_QLThanhToan.Name = "btn_QLThanhToan";
            this.btn_QLThanhToan.Size = new System.Drawing.Size(226, 49);
            this.btn_QLThanhToan.TabIndex = 1;
            this.btn_QLThanhToan.Text = "💰 Quản lý thanh toán";
            this.btn_QLThanhToan.UseVisualStyleBackColor = false;
            this.btn_QLThanhToan.Click += new System.EventHandler(this.btn_QLThanhToan_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDangXuat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Black;
            this.btnDangXuat.Location = new System.Drawing.Point(33, 489);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(226, 49);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "🔚 Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnTaiKhoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.Black;
            this.btnTaiKhoan.Location = new System.Drawing.Point(33, 29);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(226, 49);
            this.btnTaiKhoan.TabIndex = 3;
            this.btnTaiKhoan.Text = "👤 Quản lý tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDonHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDonHang.FlatAppearance.BorderSize = 0;
            this.btnDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonHang.ForeColor = System.Drawing.Color.Black;
            this.btnDonHang.Location = new System.Drawing.Point(33, 105);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(226, 49);
            this.btnDonHang.TabIndex = 4;
            this.btnDonHang.Text = "📦 Quản lý đơn hàng";
            this.btnDonHang.UseVisualStyleBackColor = false;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPhanCong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPhanCong.FlatAppearance.BorderSize = 0;
            this.btnPhanCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanCong.ForeColor = System.Drawing.Color.Black;
            this.btnPhanCong.Location = new System.Drawing.Point(33, 182);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(226, 49);
            this.btnPhanCong.TabIndex = 5;
            this.btnPhanCong.Text = "📋 Phân công giao hàng";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1235, 74);
            this.header.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1235, 74);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📮 HỆ THỐNG QUẢN TRỊ - GIAO NHẬN BƯU PHẨM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(32, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "---------------------------";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Admin_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 625);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Admin_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_MainForm";
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btn_QLThanhToan;
        private System.Windows.Forms.Button btn_backup_restore;
        private System.Windows.Forms.Label label1;
    }
}
