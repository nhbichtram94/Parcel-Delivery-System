namespace GUI
{
    partial class Admin_ThanhToan
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
            this.dgv_DonHangTheoTimKiem = new System.Windows.Forms.DataGridView();
            this.textBox_SDT = new System.Windows.Forms.TextBox();
            this.lb_SoDT = new System.Windows.Forms.Label();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.dtp_Ngay = new System.Windows.Forms.DateTimePicker();
            this.grB_TimKiem = new System.Windows.Forms.GroupBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaDH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ngay = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_XuatHD = new System.Windows.Forms.Button();
            this.btn_CapNhatTrangThaiThanhToan = new System.Windows.Forms.Button();
            this.listBox_ChiTietDh = new System.Windows.Forms.ListBox();
            this.grB_TimKiem_ThoiGian = new System.Windows.Forms.GroupBox();
            this.cbo_trangThai_2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MaDH_2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSDT_2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_ngayCuoi = new System.Windows.Forms.DateTimePicker();
            this.btn_Reset2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_tim_2 = new System.Windows.Forms.Button();
            this.dtp_ngayDau = new System.Windows.Forms.DateTimePicker();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnXuatTxt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHangTheoTimKiem)).BeginInit();
            this.grB_TimKiem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grB_TimKiem_ThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DonHangTheoTimKiem
            // 
            this.dgv_DonHangTheoTimKiem.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DonHangTheoTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DonHangTheoTimKiem.Location = new System.Drawing.Point(321, 108);
            this.dgv_DonHangTheoTimKiem.Name = "dgv_DonHangTheoTimKiem";
            this.dgv_DonHangTheoTimKiem.RowHeadersWidth = 51;
            this.dgv_DonHangTheoTimKiem.Size = new System.Drawing.Size(641, 180);
            this.dgv_DonHangTheoTimKiem.TabIndex = 0;
            this.dgv_DonHangTheoTimKiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DonHangTheoTimKiem_CellClick);
            // 
            // textBox_SDT
            // 
            this.textBox_SDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SDT.Location = new System.Drawing.Point(101, 15);
            this.textBox_SDT.Name = "textBox_SDT";
            this.textBox_SDT.Size = new System.Drawing.Size(133, 26);
            this.textBox_SDT.TabIndex = 1;
            // 
            // lb_SoDT
            // 
            this.lb_SoDT.AutoSize = true;
            this.lb_SoDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_SoDT.ForeColor = System.Drawing.Color.DarkCyan;
            this.lb_SoDT.Location = new System.Drawing.Point(5, 21);
            this.lb_SoDT.Name = "lb_SoDT";
            this.lb_SoDT.Size = new System.Drawing.Size(91, 19);
            this.lb_SoDT.TabIndex = 2;
            this.lb_SoDT.Text = "Số điện thoại:";
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.Color.White;
            this.btn_Tim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_Tim.Location = new System.Drawing.Point(179, 162);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(54, 27);
            this.btn_Tim.TabIndex = 3;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = false;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // dtp_Ngay
            // 
            this.dtp_Ngay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Ngay.Location = new System.Drawing.Point(101, 51);
            this.dtp_Ngay.Name = "dtp_Ngay";
            this.dtp_Ngay.Size = new System.Drawing.Size(133, 26);
            this.dtp_Ngay.TabIndex = 6;
            this.dtp_Ngay.ValueChanged += new System.EventHandler(this.dtp_Ngay_ValueChanged);
            // 
            // grB_TimKiem
            // 
            this.grB_TimKiem.Controls.Add(this.btn_reset);
            this.grB_TimKiem.Controls.Add(this.cbo_TrangThai);
            this.grB_TimKiem.Controls.Add(this.label2);
            this.grB_TimKiem.Controls.Add(this.txt_MaDH);
            this.grB_TimKiem.Controls.Add(this.label1);
            this.grB_TimKiem.Controls.Add(this.lb_ngay);
            this.grB_TimKiem.Controls.Add(this.lb_SoDT);
            this.grB_TimKiem.Controls.Add(this.dtp_Ngay);
            this.grB_TimKiem.Controls.Add(this.btn_Tim);
            this.grB_TimKiem.Controls.Add(this.textBox_SDT);
            this.grB_TimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grB_TimKiem.Location = new System.Drawing.Point(32, 113);
            this.grB_TimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grB_TimKiem.Name = "grB_TimKiem";
            this.grB_TimKiem.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grB_TimKiem.Size = new System.Drawing.Size(242, 198);
            this.grB_TimKiem.TabIndex = 7;
            this.grB_TimKiem.TabStop = false;
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.White;
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_reset.Location = new System.Drawing.Point(100, 162);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(54, 27);
            this.btn_reset.TabIndex = 15;
            this.btn_reset.Text = "Đặt lại";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(101, 124);
            this.cbo_TrangThai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(133, 27);
            this.cbo_TrangThai.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(5, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Trạng thái:";
            // 
            // txt_MaDH
            // 
            this.txt_MaDH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaDH.Location = new System.Drawing.Point(101, 89);
            this.txt_MaDH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_MaDH.Name = "txt_MaDH";
            this.txt_MaDH.Size = new System.Drawing.Size(133, 26);
            this.txt_MaDH.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(5, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // lb_ngay
            // 
            this.lb_ngay.AutoSize = true;
            this.lb_ngay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngay.ForeColor = System.Drawing.Color.DarkCyan;
            this.lb_ngay.Location = new System.Drawing.Point(5, 56);
            this.lb_ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ngay.Name = "lb_ngay";
            this.lb_ngay.Size = new System.Drawing.Size(45, 19);
            this.lb_ngay.TabIndex = 10;
            this.lb_ngay.Text = "Ngày:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXuatTxt);
            this.groupBox1.Controls.Add(this.btn_XuatHD);
            this.groupBox1.Controls.Add(this.btn_CapNhatTrangThaiThanhToan);
            this.groupBox1.Controls.Add(this.listBox_ChiTietDh);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Location = new System.Drawing.Point(307, 310);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(670, 262);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật thanh toán";
            // 
            // btn_XuatHD
            // 
            this.btn_XuatHD.BackColor = System.Drawing.Color.White;
            this.btn_XuatHD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatHD.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_XuatHD.Location = new System.Drawing.Point(418, 224);
            this.btn_XuatHD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_XuatHD.Name = "btn_XuatHD";
            this.btn_XuatHD.Size = new System.Drawing.Size(106, 27);
            this.btn_XuatHD.TabIndex = 2;
            this.btn_XuatHD.Text = "Hiện thị chi tiết ";
            this.btn_XuatHD.UseVisualStyleBackColor = false;
            // 
            // btn_CapNhatTrangThaiThanhToan
            // 
            this.btn_CapNhatTrangThaiThanhToan.BackColor = System.Drawing.Color.White;
            this.btn_CapNhatTrangThaiThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhatTrangThaiThanhToan.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_CapNhatTrangThaiThanhToan.Location = new System.Drawing.Point(14, 224);
            this.btn_CapNhatTrangThaiThanhToan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CapNhatTrangThaiThanhToan.Name = "btn_CapNhatTrangThaiThanhToan";
            this.btn_CapNhatTrangThaiThanhToan.Size = new System.Drawing.Size(136, 34);
            this.btn_CapNhatTrangThaiThanhToan.TabIndex = 1;
            this.btn_CapNhatTrangThaiThanhToan.Text = "Cập nhật trạng thái";
            this.btn_CapNhatTrangThaiThanhToan.UseVisualStyleBackColor = false;
            this.btn_CapNhatTrangThaiThanhToan.Click += new System.EventHandler(this.btn_CapNhatTrangThaiThanhToan_Click);
            // 
            // listBox_ChiTietDh
            // 
            this.listBox_ChiTietDh.FormattingEnabled = true;
            this.listBox_ChiTietDh.ItemHeight = 19;
            this.listBox_ChiTietDh.Location = new System.Drawing.Point(14, 35);
            this.listBox_ChiTietDh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_ChiTietDh.Name = "listBox_ChiTietDh";
            this.listBox_ChiTietDh.Size = new System.Drawing.Size(642, 175);
            this.listBox_ChiTietDh.TabIndex = 0;
            // 
            // grB_TimKiem_ThoiGian
            // 
            this.grB_TimKiem_ThoiGian.Controls.Add(this.cbo_trangThai_2);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.label7);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.txt_MaDH_2);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.label4);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.label6);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.txtSDT_2);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.label3);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.dtp_ngayCuoi);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.btn_Reset2);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.label5);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.btn_tim_2);
            this.grB_TimKiem_ThoiGian.Controls.Add(this.dtp_ngayDau);
            this.grB_TimKiem_ThoiGian.ForeColor = System.Drawing.Color.DarkCyan;
            this.grB_TimKiem_ThoiGian.Location = new System.Drawing.Point(32, 348);
            this.grB_TimKiem_ThoiGian.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grB_TimKiem_ThoiGian.Name = "grB_TimKiem_ThoiGian";
            this.grB_TimKiem_ThoiGian.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grB_TimKiem_ThoiGian.Size = new System.Drawing.Size(242, 232);
            this.grB_TimKiem_ThoiGian.TabIndex = 9;
            this.grB_TimKiem_ThoiGian.TabStop = false;
            // 
            // cbo_trangThai_2
            // 
            this.cbo_trangThai_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_trangThai_2.FormattingEnabled = true;
            this.cbo_trangThai_2.Location = new System.Drawing.Point(103, 159);
            this.cbo_trangThai_2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbo_trangThai_2.Name = "cbo_trangThai_2";
            this.cbo_trangThai_2.Size = new System.Drawing.Size(133, 27);
            this.cbo_trangThai_2.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(9, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Trạng thái:";
            // 
            // txt_MaDH_2
            // 
            this.txt_MaDH_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaDH_2.Location = new System.Drawing.Point(103, 124);
            this.txt_MaDH_2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_MaDH_2.Name = "txt_MaDH_2";
            this.txt_MaDH_2.Size = new System.Drawing.Size(133, 26);
            this.txt_MaDH_2.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Số điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(9, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mã đơn hàng:";
            // 
            // txtSDT_2
            // 
            this.txtSDT_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT_2.Location = new System.Drawing.Point(103, 89);
            this.txtSDT_2.Name = "txtSDT_2";
            this.txtSDT_2.Size = new System.Drawing.Size(133, 26);
            this.txtSDT_2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày cuối:";
            // 
            // dtp_ngayCuoi
            // 
            this.dtp_ngayCuoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngayCuoi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngayCuoi.Location = new System.Drawing.Point(103, 51);
            this.dtp_ngayCuoi.Name = "dtp_ngayCuoi";
            this.dtp_ngayCuoi.Size = new System.Drawing.Size(133, 26);
            this.dtp_ngayCuoi.TabIndex = 16;
            this.dtp_ngayCuoi.ValueChanged += new System.EventHandler(this.dtp_ngayCuoi_ValueChanged);
            // 
            // btn_Reset2
            // 
            this.btn_Reset2.BackColor = System.Drawing.Color.White;
            this.btn_Reset2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset2.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_Reset2.Location = new System.Drawing.Point(104, 197);
            this.btn_Reset2.Name = "btn_Reset2";
            this.btn_Reset2.Size = new System.Drawing.Size(54, 27);
            this.btn_Reset2.TabIndex = 15;
            this.btn_Reset2.Text = "Đặt lại";
            this.btn_Reset2.UseVisualStyleBackColor = false;
            this.btn_Reset2.Click += new System.EventHandler(this.btn_Reset2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ngày đầu:";
            // 
            // btn_tim_2
            // 
            this.btn_tim_2.BackColor = System.Drawing.Color.White;
            this.btn_tim_2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tim_2.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_tim_2.Location = new System.Drawing.Point(182, 197);
            this.btn_tim_2.Name = "btn_tim_2";
            this.btn_tim_2.Size = new System.Drawing.Size(54, 27);
            this.btn_tim_2.TabIndex = 3;
            this.btn_tim_2.Text = "Tìm";
            this.btn_tim_2.UseVisualStyleBackColor = false;
            this.btn_tim_2.Click += new System.EventHandler(this.btn_tim_2_Click);
            // 
            // dtp_ngayDau
            // 
            this.dtp_ngayDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngayDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngayDau.Location = new System.Drawing.Point(103, 16);
            this.dtp_ngayDau.Name = "dtp_ngayDau";
            this.dtp_ngayDau.Size = new System.Drawing.Size(133, 26);
            this.dtp_ngayDau.TabIndex = 6;
            this.dtp_ngayDau.ValueChanged += new System.EventHandler(this.dtp_ngayDau_ValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.White;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.DarkCyan;
            this.radioButton2.Location = new System.Drawing.Point(57, 330);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(197, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Tìm kiếm theo mốc thời gian";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.White;
            this.radioButton1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.DarkCyan;
            this.radioButton1.Location = new System.Drawing.Point(88, 101);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tìm kiếm đơn lẻ";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Azure;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1010, 86);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "QUẢN LÝ THANH TOÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXuatTxt
            // 
            this.btnXuatTxt.BackColor = System.Drawing.Color.White;
            this.btnXuatTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatTxt.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnXuatTxt.Location = new System.Drawing.Point(538, 214);
            this.btnXuatTxt.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatTxt.Name = "btnXuatTxt";
            this.btnXuatTxt.Size = new System.Drawing.Size(106, 27);
            this.btnXuatTxt.TabIndex = 3;
            this.btnXuatTxt.Text = "Xuất hóa đơn";
            this.btnXuatTxt.UseVisualStyleBackColor = false;
            this.btnXuatTxt.Click += new System.EventHandler(this.btnXuatTxt_Click);
            // 
            // Admin_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1010, 591);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.grB_TimKiem_ThoiGian);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grB_TimKiem);
            this.Controls.Add(this.dgv_DonHangTheoTimKiem);
            this.Name = "Admin_ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_ThanhToan";
            this.Load += new System.EventHandler(this.Admin_ThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DonHangTheoTimKiem)).EndInit();
            this.grB_TimKiem.ResumeLayout(false);
            this.grB_TimKiem.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grB_TimKiem_ThoiGian.ResumeLayout(false);
            this.grB_TimKiem_ThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DonHangTheoTimKiem;
        private System.Windows.Forms.TextBox textBox_SDT;
        private System.Windows.Forms.Label lb_SoDT;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.DateTimePicker dtp_Ngay;
        private System.Windows.Forms.GroupBox grB_TimKiem;
        private System.Windows.Forms.Label lb_ngay;
        private System.Windows.Forms.TextBox txt_MaDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.Button btn_reset;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_CapNhatTrangThaiThanhToan;
        private System.Windows.Forms.ListBox listBox_ChiTietDh;
        private System.Windows.Forms.Button btn_XuatHD;
        private System.Windows.Forms.GroupBox grB_TimKiem_ThoiGian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_ngayCuoi;
        private System.Windows.Forms.Button btn_Reset2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_ngayDau;
        private System.Windows.Forms.Button btn_tim_2;
        private System.Windows.Forms.TextBox txt_MaDH_2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSDT_2;
        private System.Windows.Forms.ComboBox cbo_trangThai_2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnXuatTxt;
    }
}