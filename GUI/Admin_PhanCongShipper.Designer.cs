namespace GUI
{
    partial class Admin_PhanCongShipper
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

        private void InitializeComponent()
        {
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnTaoPhanCong = new System.Windows.Forms.Button();
            this.lblShippers = new System.Windows.Forms.Label();
            this.lblDonHang = new System.Windows.Forms.Label();
            this.lblPhanCong = new System.Windows.Forms.Label();
            this.dataGridViewDonHang = new System.Windows.Forms.DataGridView();
            this.dataGridViewPhanCong = new System.Windows.Forms.DataGridView();
            this.listViewShippers = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.White;
            this.btnPhanCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanCong.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnPhanCong.Location = new System.Drawing.Point(613, 367);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(6);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(105, 37);
            this.btnPhanCong.TabIndex = 8;
            this.btnPhanCong.Text = "Phân Công";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnTaoPhanCong
            // 
            this.btnTaoPhanCong.BackColor = System.Drawing.Color.White;
            this.btnTaoPhanCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhanCong.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnTaoPhanCong.Location = new System.Drawing.Point(884, 368);
            this.btnTaoPhanCong.Margin = new System.Windows.Forms.Padding(6);
            this.btnTaoPhanCong.Name = "btnTaoPhanCong";
            this.btnTaoPhanCong.Size = new System.Drawing.Size(144, 36);
            this.btnTaoPhanCong.TabIndex = 9;
            this.btnTaoPhanCong.Text = "Tạo Phân Công";
            this.btnTaoPhanCong.UseVisualStyleBackColor = false;
            this.btnTaoPhanCong.Click += new System.EventHandler(this.btnTaoPhanCong_Click);
            // 
            // lblShippers
            // 
            this.lblShippers.AutoSize = true;
            this.lblShippers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippers.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblShippers.Location = new System.Drawing.Point(18, 90);
            this.lblShippers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblShippers.Name = "lblShippers";
            this.lblShippers.Size = new System.Drawing.Size(123, 19);
            this.lblShippers.TabIndex = 0;
            this.lblShippers.Text = "Danh sách Shipper";
            // 
            // lblDonHang
            // 
            this.lblDonHang.AutoSize = true;
            this.lblDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonHang.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDonHang.Location = new System.Drawing.Point(17, 409);
            this.lblDonHang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(134, 19);
            this.lblDonHang.TabIndex = 2;
            this.lblDonHang.Text = "Danh sách Đơn hàng";
            // 
            // lblPhanCong
            // 
            this.lblPhanCong.AutoSize = true;
            this.lblPhanCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhanCong.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPhanCong.Location = new System.Drawing.Point(609, 90);
            this.lblPhanCong.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPhanCong.Name = "lblPhanCong";
            this.lblPhanCong.Size = new System.Drawing.Size(139, 19);
            this.lblPhanCong.TabIndex = 4;
            this.lblPhanCong.Text = "Danh sách Phân công";
            // 
            // dataGridViewDonHang
            // 
            this.dataGridViewDonHang.AllowUserToAddRows = false;
            this.dataGridViewDonHang.AllowUserToDeleteRows = false;
            this.dataGridViewDonHang.AllowUserToOrderColumns = true;
            this.dataGridViewDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonHang.Location = new System.Drawing.Point(21, 437);
            this.dataGridViewDonHang.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewDonHang.Name = "dataGridViewDonHang";
            this.dataGridViewDonHang.ReadOnly = true;
            this.dataGridViewDonHang.RowHeadersWidth = 51;
            this.dataGridViewDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDonHang.Size = new System.Drawing.Size(528, 241);
            this.dataGridViewDonHang.TabIndex = 3;
            // 
            // dataGridViewPhanCong
            // 
            this.dataGridViewPhanCong.AllowUserToAddRows = false;
            this.dataGridViewPhanCong.AllowUserToDeleteRows = false;
            this.dataGridViewPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhanCong.Location = new System.Drawing.Point(582, 131);
            this.dataGridViewPhanCong.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewPhanCong.Name = "dataGridViewPhanCong";
            this.dataGridViewPhanCong.ReadOnly = true;
            this.dataGridViewPhanCong.RowHeadersWidth = 51;
            this.dataGridViewPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPhanCong.Size = new System.Drawing.Size(617, 199);
            this.dataGridViewPhanCong.TabIndex = 5;
            // 
            // listViewShippers
            // 
            this.listViewShippers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewShippers.FullRowSelect = true;
            this.listViewShippers.GridLines = true;
            this.listViewShippers.HideSelection = false;
            this.listViewShippers.Location = new System.Drawing.Point(22, 118);
            this.listViewShippers.Margin = new System.Windows.Forms.Padding(6);
            this.listViewShippers.MultiSelect = false;
            this.listViewShippers.Name = "listViewShippers";
            this.listViewShippers.Size = new System.Drawing.Size(461, 198);
            this.listViewShippers.TabIndex = 1;
            this.listViewShippers.UseCompatibleStateImageBehavior = false;
            this.listViewShippers.View = System.Windows.Forms.View.Details;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Azure;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1370, 86);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "PHÂN CÔNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Admin_PhanCongShipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1370, 742);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblShippers);
            this.Controls.Add(this.listViewShippers);
            this.Controls.Add(this.lblDonHang);
            this.Controls.Add(this.dataGridViewDonHang);
            this.Controls.Add(this.lblPhanCong);
            this.Controls.Add(this.dataGridViewPhanCong);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.btnTaoPhanCong);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Admin_PhanCongShipper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_PhanCongShipper";
            this.Load += new System.EventHandler(this.Admin_PhanCongShipper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewShippers;
        private System.Windows.Forms.DataGridView dataGridViewDonHang;
        private System.Windows.Forms.DataGridView dataGridViewPhanCong;
        private System.Windows.Forms.Label lblShippers;
        private System.Windows.Forms.Label lblDonHang;
        private System.Windows.Forms.Label lblPhanCong;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnTaoPhanCong;
        private System.Windows.Forms.Label lblTitle;
    }
}
