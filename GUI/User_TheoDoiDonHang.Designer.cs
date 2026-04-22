using System;

namespace GUI
{
    partial class User_TheoDoiDonHang
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
            this.flowDonHang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMoiTao = new System.Windows.Forms.Button();
            this.btnDangXuLy = new System.Windows.Forms.Button();
            this.btnDangGiao = new System.Windows.Forms.Button();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btnDaHuy = new System.Windows.Forms.Button();
            this.btnDaHoanTien = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowDonHang
            // 
            this.flowDonHang.AutoScroll = true;
            this.flowDonHang.BackColor = System.Drawing.Color.MintCream;
            this.flowDonHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.flowDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowDonHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowDonHang.Location = new System.Drawing.Point(209, 115);
            this.flowDonHang.Name = "flowDonHang";
            this.flowDonHang.Size = new System.Drawing.Size(811, 346);
            this.flowDonHang.TabIndex = 0;
            // 
            // btnMoiTao
            // 
            this.btnMoiTao.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMoiTao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMoiTao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoiTao.ForeColor = System.Drawing.Color.Teal;
            this.btnMoiTao.Location = new System.Drawing.Point(24, 115);
            this.btnMoiTao.Name = "btnMoiTao";
            this.btnMoiTao.Size = new System.Drawing.Size(160, 46);
            this.btnMoiTao.TabIndex = 1;
            this.btnMoiTao.Text = "Mới tạo";
            this.btnMoiTao.UseVisualStyleBackColor = false;
            this.btnMoiTao.Click += new System.EventHandler(this.btnMoiTao_Click);
            // 
            // btnDangXuLy
            // 
            this.btnDangXuLy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDangXuLy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDangXuLy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuLy.ForeColor = System.Drawing.Color.Teal;
            this.btnDangXuLy.Location = new System.Drawing.Point(24, 175);
            this.btnDangXuLy.Name = "btnDangXuLy";
            this.btnDangXuLy.Size = new System.Drawing.Size(160, 46);
            this.btnDangXuLy.TabIndex = 2;
            this.btnDangXuLy.Text = "Đang xử lý";
            this.btnDangXuLy.UseVisualStyleBackColor = false;
            this.btnDangXuLy.Click += new System.EventHandler(this.btnDangXuLy_Click);
            // 
            // btnDangGiao
            // 
            this.btnDangGiao.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDangGiao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDangGiao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangGiao.ForeColor = System.Drawing.Color.Teal;
            this.btnDangGiao.Location = new System.Drawing.Point(24, 235);
            this.btnDangGiao.Name = "btnDangGiao";
            this.btnDangGiao.Size = new System.Drawing.Size(160, 46);
            this.btnDangGiao.TabIndex = 3;
            this.btnDangGiao.Text = "Đang giao";
            this.btnDangGiao.UseVisualStyleBackColor = false;
            this.btnDangGiao.Click += new System.EventHandler(this.btnDangGiao_Click);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnHoanThanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHoanThanh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanThanh.ForeColor = System.Drawing.Color.Teal;
            this.btnHoanThanh.Location = new System.Drawing.Point(24, 295);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(160, 46);
            this.btnHoanThanh.TabIndex = 4;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // btnDaHuy
            // 
            this.btnDaHuy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDaHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDaHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaHuy.ForeColor = System.Drawing.Color.Teal;
            this.btnDaHuy.Location = new System.Drawing.Point(24, 355);
            this.btnDaHuy.Name = "btnDaHuy";
            this.btnDaHuy.Size = new System.Drawing.Size(160, 46);
            this.btnDaHuy.TabIndex = 5;
            this.btnDaHuy.Text = "Đã hủy";
            this.btnDaHuy.UseVisualStyleBackColor = false;
            this.btnDaHuy.Click += new System.EventHandler(this.btnDaHuy_Click);
            // 
            // btnDaHoanTien
            // 
            this.btnDaHoanTien.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDaHoanTien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDaHoanTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaHoanTien.ForeColor = System.Drawing.Color.Teal;
            this.btnDaHoanTien.Location = new System.Drawing.Point(24, 415);
            this.btnDaHoanTien.Name = "btnDaHoanTien";
            this.btnDaHoanTien.Size = new System.Drawing.Size(160, 46);
            this.btnDaHoanTien.TabIndex = 6;
            this.btnDaHoanTien.Text = "Đã hoàn tiền";
            this.btnDaHoanTien.UseVisualStyleBackColor = false;
            this.btnDaHoanTien.Click += new System.EventHandler(this.btnDaHoanTien_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Azure;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1050, 112);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "THEO DÕI ĐƠN HÀNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // User_TheoDoiDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1050, 493);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flowDonHang);
            this.Controls.Add(this.btnMoiTao);
            this.Controls.Add(this.btnDangXuLy);
            this.Controls.Add(this.btnDangGiao);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.btnDaHuy);
            this.Controls.Add(this.btnDaHoanTien);
            this.Name = "User_TheoDoiDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theo dõi đơn hàng";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowDonHang;
        private System.Windows.Forms.Button btnMoiTao;
        private System.Windows.Forms.Button btnDangXuLy;
        private System.Windows.Forms.Button btnDangGiao;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Button btnDaHuy;
        private System.Windows.Forms.Button btnDaHoanTien;
        private System.Windows.Forms.Label lblTitle;
    }
}
