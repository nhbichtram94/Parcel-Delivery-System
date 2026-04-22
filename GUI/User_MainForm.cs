using BLL;
using DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Drawing;

namespace GUI
{
    public partial class User_MainForm : Form
    {
        private readonly DonHang_BLL _donHangBLL = new DonHang_BLL();
        private readonly NguoiDung_DTO _currentUser;

        private readonly string[] _statuses =
        {
            "Mới tạo",
            "Đang xử lý",
            "Đang giao",
            "Hoàn thành",
            "Đã hủy",
            "Đã hoàn tiền"
        };

        public User_MainForm(NguoiDung_DTO user)
        {
            InitializeComponent();
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            this.Load += User_MainForm_Load;
        }

        private void User_MainForm_Load(object sender, EventArgs e)
        {
            string tenNguoiDung = _currentUser.HoTen ?? "Khách hàng";
            lblWelcome.Text = $"👋 Xin chào, {tenNguoiDung}!";

            ShowTrangChu();
        }

        // ---------------------- TRANG TĨNH -----------------------

        private void ShowTrangChu()
        {
            mainPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text = "📦 HỆ THỐNG GIAO NHẬN BƯU PHẨM\n\nChào mừng bạn đến với trang chủ.",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            mainPanel.Controls.Add(lbl);
        }

        private void ShowAboutUs()
        {
            mainPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text =
                "ℹ️ GIỚI THIỆU HỆ THỐNG\n\n" +
                "• Ứng dụng hỗ trợ gửi – nhận bưu phẩm nhanh chóng.\n" +
                "• Kết nối giữa người gửi, người vận chuyển và người nhận.\n" +
                "• Quản lý trạng thái đơn hàng theo thời gian thực.",
                Font = new Font("Segoe UI", 14),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(20)
            };

            mainPanel.Controls.Add(lbl);
        }

        private void ShowContact()
        {
            mainPanel.Controls.Clear();

            Label lbl = new Label
            {
                Text =
                "📞 LIÊN HỆ\n\n" +
                "• Hotline: 1900 6868\n" +
                "• Email: support@giaonhan.com\n" +
                "• Địa chỉ: 123 Đường ABC, Quận XYZ, TP.HCM",
                Font = new Font("Segoe UI", 14),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(20)
            };

            mainPanel.Controls.Add(lbl);
        }

        // ---------------------------------------------------------

        private async void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                mainPanel.Controls.Clear();

                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("GiaoNhanBuuPham");
                var donHangCollection = database.GetCollection<DonHang_DTO>("DonHang");

                FilterDefinition<DonHang_DTO> filter;
                var idNguoi = _currentUser.Id;

                if (idNguoi is ObjectId)
                    filter = Builders<DonHang_DTO>.Filter.Eq(dh => dh.IdNguoiGui, (ObjectId)idNguoi);
                else
                    filter = Builders<DonHang_DTO>.Filter.Eq("idNguoiGui", idNguoi.ToString());

                var danhSachDonHang = await donHangCollection.Find(filter).ToListAsync();

                if (danhSachDonHang.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "⚠️ Không có đơn hàng nào!",
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.DarkOrange,
                        AutoSize = true,
                        Location = new Point(50, 50)
                    };
                    mainPanel.Controls.Add(lblEmpty);
                    return;
                }

                Label lblTitle = new Label
                {
                    Text = $"📦 DANH SÁCH ĐƠN HÀNG CỦA: {_currentUser.HoTen}",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.MediumBlue,
                    AutoSize = true,
                    Location = new Point(30, 20)
                };
                mainPanel.Controls.Add(lblTitle);

                int y = 70;

                foreach (var dh in danhSachDonHang)
                {
                    Panel card = new Panel
                    {
                        BackColor = Color.FromArgb(240, 245, 255),
                        Size = new Size(700, 140),
                        Location = new Point(30, y),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label lblMa = new Label
                    {
                        Text = $"🆔 Mã đơn: {dh.MaDonHang}",
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        Location = new Point(10, 10),
                        AutoSize = true
                    };

                    Label lblTrangThai = new Label
                    {
                        Text = $"🚚 Trạng thái: {dh.TrangThai}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 40),
                        AutoSize = true
                    };

                    Label lblNguoiNhan = new Label
                    {
                        Text = $"📍 Người nhận: {dh.NguoiNhanThongTin?.HoTen ?? "Không rõ"}",
                        Font = new Font("Segoe UI", 10),
                        Location = new Point(10, 70),
                        AutoSize = true
                    };

                    Label lblTongTien = new Label
                    {
                        Text = $"💰 Tổng tiền: {dh.TongTien:N0} VNĐ",
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        ForeColor = Color.DarkGreen,
                        Location = new Point(10, 100),
                        AutoSize = true
                    };

                    card.Controls.Add(lblMa);
                    card.Controls.Add(lblTrangThai);
                    card.Controls.Add(lblNguoiNhan);
                    card.Controls.Add(lblTongTien);

                    mainPanel.Controls.Add(card);

                    y += 160;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTheoDoiDonHang_Click(object sender, EventArgs e)
        {
            using (var formTheoDoi = new User_TheoDoiDonHang(_currentUser))
            {
                formTheoDoi.ShowDialog();
            }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            using (var form = new User_TaoDonHang(_currentUser))
            {
                form.ShowDialog();
            }
        }

        private void btn_taiKhoan_Click(object sender, EventArgs e)
        {
            using (var form = new User_TaiKhoan(_currentUser))
            {
                form.ShowDialog();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // NÚT MỚI
        private void btnHome_Click(object sender, EventArgs e) => ShowTrangChu();
        private void btnAbout_Click(object sender, EventArgs e) => ShowAboutUs();
        private void btnContact_Click(object sender, EventArgs e) => ShowContact();
    }
}
