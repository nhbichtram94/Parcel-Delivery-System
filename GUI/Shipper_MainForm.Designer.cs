using System.Drawing;

namespace GUI
{
    partial class Shipper_MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongTinShipper = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchKhuVuc = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnApDungLoc = new System.Windows.Forms.Button();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.btnCapNhatDon = new System.Windows.Forms.Button();
            this.btnXuatCSV = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(220)))));
            this.headerPanel.Controls.Add(this.btnDangXuat);
            this.headerPanel.Controls.Add(this.btnThongTinShipper);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1100, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Gray;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(990, 10);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(98, 37);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "🚪 Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongTinShipper
            // 
            this.btnThongTinShipper.BackColor = System.Drawing.Color.White;
            this.btnThongTinShipper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTinShipper.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnThongTinShipper.Location = new System.Drawing.Point(12, 10);
            this.btnThongTinShipper.Name = "btnThongTinShipper";
            this.btnThongTinShipper.Size = new System.Drawing.Size(71, 37);
            this.btnThongTinShipper.TabIndex = 1;
            this.btnThongTinShipper.Text = "ℹ Tôi";
            this.btnThongTinShipper.UseVisualStyleBackColor = false;
            this.btnThongTinShipper.Click += new System.EventHandler(this.btnThongTinShipper_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1100, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📮 VẬN CHUYỂN ĐƠN HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSearch.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSearch.Location = new System.Drawing.Point(20, 70);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(118, 19);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm theo khu vực:";
            // 
            // txtSearchKhuVuc
            // 
            this.txtSearchKhuVuc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtSearchKhuVuc.Location = new System.Drawing.Point(150, 67);
            this.txtSearchKhuVuc.Name = "txtSearchKhuVuc";
            this.txtSearchKhuVuc.Size = new System.Drawing.Size(200, 26);
            this.txtSearchKhuVuc.TabIndex = 2;
            this.txtSearchKhuVuc.TextChanged += new System.EventHandler(this.TxtSearchKhuVuc_TextChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTrangThai.Location = new System.Drawing.Point(370, 70);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(71, 19);
            this.lblTrangThai.TabIndex = 3;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Đang giao",
            "Hoàn thành", "Đã hủy"});
            this.cboTrangThai.Location = new System.Drawing.Point(460, 66);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(150, 27);
            this.cboTrangThai.TabIndex = 4;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.CboTrangThai_SelectedIndexChanged);
            // 
            // btnApDungLoc
            // 
            this.btnApDungLoc.BackColor = System.Drawing.Color.White;
            this.btnApDungLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDungLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnApDungLoc.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnApDungLoc.Location = new System.Drawing.Point(645, 65);
            this.btnApDungLoc.Name = "btnApDungLoc";
            this.btnApDungLoc.Size = new System.Drawing.Size(112, 27);
            this.btnApDungLoc.TabIndex = 5;
            this.btnApDungLoc.Text = "🔍 Lọc";
            this.btnApDungLoc.UseVisualStyleBackColor = false;
            this.btnApDungLoc.Click += new System.EventHandler(this.ApplyFiltersButton_Click);
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToDeleteRows = false;
            this.dgvDonHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDonHang.ColumnHeadersHeight = 29;
            this.dgvDonHang.EnableHeadersVisualStyles = false;
            this.dgvDonHang.Location = new System.Drawing.Point(20, 110);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.RowTemplate.Height = 32;
            this.dgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHang.Size = new System.Drawing.Size(1040, 300);
            this.dgvDonHang.TabIndex = 6;
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.White;
            this.btnHoanThanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanThanh.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHoanThanh.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnHoanThanh.Location = new System.Drawing.Point(200, 420);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(130, 30);
            this.btnHoanThanh.TabIndex = 7;
            this.btnHoanThanh.Text = "✔ Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.BtnHoanThanh_Click);
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.BackColor = System.Drawing.Color.White;
            this.btn_ThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_ThanhToan.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_ThanhToan.Location = new System.Drawing.Point(400, 420);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(130, 30);
            this.btn_ThanhToan.TabIndex = 8;
            this.btn_ThanhToan.Text = "💰 Thanh toán";
            this.btn_ThanhToan.UseVisualStyleBackColor = false;
            this.btn_ThanhToan.Click += new System.EventHandler(this.Btn_ThanhToan_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.BackColor = System.Drawing.Color.Firebrick;
            this.btnHuyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyDon.Location = new System.Drawing.Point(20, 420);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(130, 30);
            this.btnHuyDon.TabIndex = 12;
            this.btnHuyDon.Text = "🛑 Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = false;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // btnCapNhatDon
            // 
            this.btnCapNhatDon.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCapNhatDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatDon.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatDon.Location = new System.Drawing.Point(20, 460);
            this.btnCapNhatDon.Name = "btnCapNhatDon";
            this.btnCapNhatDon.Size = new System.Drawing.Size(130, 30);
            this.btnCapNhatDon.TabIndex = 13;
            this.btnCapNhatDon.Text = "📝 Cập nhật đơn";
            this.btnCapNhatDon.UseVisualStyleBackColor = false;
            // 
            // btnXuatCSV
            // 
            this.btnXuatCSV.BackColor = System.Drawing.Color.White;
            this.btnXuatCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatCSV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnXuatCSV.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnXuatCSV.Location = new System.Drawing.Point(600, 420);
            this.btnXuatCSV.Name = "btnXuatCSV";
            this.btnXuatCSV.Size = new System.Drawing.Size(130, 30);
            this.btnXuatCSV.TabIndex = 9;
            this.btnXuatCSV.Text = "⬇ Xuất CSV";
            this.btnXuatCSV.UseVisualStyleBackColor = false;
            this.btnXuatCSV.Click += new System.EventHandler(this.BtnXuatCSV_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.White;
            this.btnPrevPage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnPrevPage.Location = new System.Drawing.Point(950, 420);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(50, 30);
            this.btnPrevPage.TabIndex = 10;
            this.btnPrevPage.Text = "⏮";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.BtnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.White;
            this.btnNextPage.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnNextPage.Location = new System.Drawing.Point(1010, 420);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(50, 30);
            this.btnNextPage.TabIndex = 11;
            this.btnNextPage.Text = "⏭";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // Shipper_MainForm
            // 
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1100, 510);
            this.Controls.Add(this.btnCapNhatDon);
            this.Controls.Add(this.btnHuyDon);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnXuatCSV);
            this.Controls.Add(this.btn_ThanhToan);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.btnApDungLoc);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtSearchKhuVuc);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.headerPanel);
            this.Name = "Shipper_MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipper - Quản lý đơn hàng";
            this.Load += new System.EventHandler(this.Shipper_MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnThongTinShipper;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchKhuVuc;

        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnApDungLoc;

        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Button btn_ThanhToan;
        private System.Windows.Forms.Button btnXuatCSV;

        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnCapNhatDon;

        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
    }
}
