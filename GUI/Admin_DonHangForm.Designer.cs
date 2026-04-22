using System.Windows.Forms;

namespace GUI
{
    partial class Admin_DonHangForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblMaDonHang = new System.Windows.Forms.Label();
            this.txtMaDonHang = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThaiLoc = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblSDTNguoiGui = new System.Windows.Forms.Label();
            this.txtSDTNguoiGui = new System.Windows.Forms.TextBox();
            this.lblSDTNguoiNhan = new System.Windows.Forms.Label();
            this.txtSDTNguoiNhan = new System.Windows.Forms.TextBox();
            this.chkDaThanhToan = new System.Windows.Forms.CheckBox();
            this.btnSapXepMoiNhat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.DgvDonHang = new System.Windows.Forms.DataGridView();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            this.XuatExcel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaDonHang
            // 
            this.lblMaDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDonHang.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMaDonHang.Location = new System.Drawing.Point(20, 107);
            this.lblMaDonHang.Name = "lblMaDonHang";
            this.lblMaDonHang.Size = new System.Drawing.Size(118, 23);
            this.lblMaDonHang.TabIndex = 1;
            this.lblMaDonHang.Text = "Mã đơn hàng:";
            // 
            // txtMaDonHang
            // 
            this.txtMaDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDonHang.Location = new System.Drawing.Point(144, 100);
            this.txtMaDonHang.Name = "txtMaDonHang";
            this.txtMaDonHang.Size = new System.Drawing.Size(239, 30);
            this.txtMaDonHang.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 143);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 7;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThaiLoc
            // 
            this.cbTrangThaiLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThaiLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThaiLoc.Items.AddRange(new object[] {
            "Tất cả",
            "Chờ xử lý",
            "Đang xử lý",
            "Đã giao",
            "Đã hủy"});
            this.cbTrangThaiLoc.Location = new System.Drawing.Point(144, 136);
            this.cbTrangThaiLoc.Name = "cbTrangThaiLoc";
            this.cbTrangThaiLoc.Size = new System.Drawing.Size(239, 30);
            this.cbTrangThaiLoc.TabIndex = 8;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTuNgay.Location = new System.Drawing.Point(789, 98);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(100, 23);
            this.lblTuNgay.TabIndex = 15;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(895, 91);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 30);
            this.dtpTuNgay.TabIndex = 16;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDenNgay.Location = new System.Drawing.Point(789, 136);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(100, 23);
            this.lblDenNgay.TabIndex = 17;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(895, 129);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 30);
            this.dtpDenNgay.TabIndex = 18;
            // 
            // lblSDTNguoiGui
            // 
            this.lblSDTNguoiGui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTNguoiGui.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSDTNguoiGui.Location = new System.Drawing.Point(424, 105);
            this.lblSDTNguoiGui.Name = "lblSDTNguoiGui";
            this.lblSDTNguoiGui.Size = new System.Drawing.Size(138, 23);
            this.lblSDTNguoiGui.TabIndex = 9;
            this.lblSDTNguoiGui.Text = "SDT người gửi:";
            // 
            // txtSDTNguoiGui
            // 
            this.txtSDTNguoiGui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTNguoiGui.Location = new System.Drawing.Point(568, 98);
            this.txtSDTNguoiGui.Name = "txtSDTNguoiGui";
            this.txtSDTNguoiGui.Size = new System.Drawing.Size(181, 30);
            this.txtSDTNguoiGui.TabIndex = 10;
            // 
            // lblSDTNguoiNhan
            // 
            this.lblSDTNguoiNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTNguoiNhan.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSDTNguoiNhan.Location = new System.Drawing.Point(424, 143);
            this.lblSDTNguoiNhan.Name = "lblSDTNguoiNhan";
            this.lblSDTNguoiNhan.Size = new System.Drawing.Size(148, 23);
            this.lblSDTNguoiNhan.TabIndex = 11;
            this.lblSDTNguoiNhan.Text = "SDT người nhận:";
            // 
            // txtSDTNguoiNhan
            // 
            this.txtSDTNguoiNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTNguoiNhan.Location = new System.Drawing.Point(568, 134);
            this.txtSDTNguoiNhan.Name = "txtSDTNguoiNhan";
            this.txtSDTNguoiNhan.Size = new System.Drawing.Size(181, 30);
            this.txtSDTNguoiNhan.TabIndex = 12;
            // 
            // chkDaThanhToan
            // 
            this.chkDaThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaThanhToan.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkDaThanhToan.Location = new System.Drawing.Point(959, 172);
            this.chkDaThanhToan.Name = "chkDaThanhToan";
            this.chkDaThanhToan.Size = new System.Drawing.Size(140, 30);
            this.chkDaThanhToan.TabIndex = 13;
            this.chkDaThanhToan.Text = "Đã thanh toán";
            // 
            // btnSapXepMoiNhat
            // 
            this.btnSapXepMoiNhat.BackColor = System.Drawing.Color.White;
            this.btnSapXepMoiNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSapXepMoiNhat.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnSapXepMoiNhat.Location = new System.Drawing.Point(595, 235);
            this.btnSapXepMoiNhat.Name = "btnSapXepMoiNhat";
            this.btnSapXepMoiNhat.Size = new System.Drawing.Size(104, 33);
            this.btnSapXepMoiNhat.TabIndex = 14;
            this.btnSapXepMoiNhat.Text = "Mới nhất";
            this.btnSapXepMoiNhat.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnTimKiem.Location = new System.Drawing.Point(729, 235);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 33);
            this.btnTimKiem.TabIndex = 19;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnReset.Location = new System.Drawing.Point(862, 235);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 33);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // DgvDonHang
            // 
            this.DgvDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDonHang.ColumnHeadersHeight = 29;
            this.DgvDonHang.Location = new System.Drawing.Point(47, 274);
            this.DgvDonHang.Name = "DgvDonHang";
            this.DgvDonHang.ReadOnly = true;
            this.DgvDonHang.RowHeadersWidth = 51;
            this.DgvDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDonHang.Size = new System.Drawing.Size(1042, 282);
            this.DgvDonHang.TabIndex = 21;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.White;
            this.btnPrevPage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevPage.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnPrevPage.Location = new System.Drawing.Point(48, 565);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(55, 37);
            this.btnPrevPage.TabIndex = 22;
            this.btnPrevPage.Text = "<<<";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.White;
            this.btnNextPage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnNextPage.Location = new System.Drawing.Point(109, 565);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(55, 37);
            this.btnNextPage.TabIndex = 23;
            this.btnNextPage.Text = ">>>";
            this.btnNextPage.UseVisualStyleBackColor = false;
            // 
            // lblTrang
            // 
            this.lblTrang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrang.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTrang.Location = new System.Drawing.Point(989, 571);
            this.lblTrang.Name = "lblTrang";
            this.lblTrang.Size = new System.Drawing.Size(100, 23);
            this.lblTrang.TabIndex = 24;
            this.lblTrang.Text = "Trang 1 / 1";
            this.lblTrang.Click += new System.EventHandler(this.lblTrang_Click);
            // 
            // XuatExcel
            // 
            this.XuatExcel.BackColor = System.Drawing.Color.White;
            this.XuatExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XuatExcel.ForeColor = System.Drawing.Color.DarkCyan;
            this.XuatExcel.Location = new System.Drawing.Point(989, 235);
            this.XuatExcel.Name = "XuatExcel";
            this.XuatExcel.Size = new System.Drawing.Size(100, 33);
            this.XuatExcel.TabIndex = 26;
            this.XuatExcel.Text = "Xuất Excel";
            this.XuatExcel.UseVisualStyleBackColor = false;
            this.XuatExcel.Click += new System.EventHandler(this.XuatExcel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Azure;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1140, 86);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ ĐƠN HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Admin_DonHangForm
            // 
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1140, 623);
            this.Controls.Add(this.XuatExcel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMaDonHang);
            this.Controls.Add(this.txtMaDonHang);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cbTrangThaiLoc);
            this.Controls.Add(this.lblSDTNguoiGui);
            this.Controls.Add(this.txtSDTNguoiGui);
            this.Controls.Add(this.lblSDTNguoiNhan);
            this.Controls.Add(this.txtSDTNguoiNhan);
            this.Controls.Add(this.chkDaThanhToan);
            this.Controls.Add(this.btnSapXepMoiNhat);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.DgvDonHang);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.lblTrang);
            this.Name = "Admin_DonHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đơn hàng";
            ((System.ComponentModel.ISupportInitialize)(this.DgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblMaDonHang;
        private TextBox txtMaDonHang;
        private Label lblTrangThai;
        private ComboBox cbTrangThaiLoc;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblSDTNguoiGui;
        private TextBox txtSDTNguoiGui;
        private Label lblSDTNguoiNhan;
        private TextBox txtSDTNguoiNhan;
        private CheckBox chkDaThanhToan;
        private Button btnSapXepMoiNhat;
        private Button btnTimKiem;
        private Button btnReset;
        private DataGridView DgvDonHang;
        private Button btnPrevPage;
        private Button btnNextPage;
        private Label lblTrang;
        private Button XuatExcel;
        private Label lblTitle;
    }
}
