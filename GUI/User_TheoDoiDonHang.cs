using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class User_TheoDoiDonHang : Form
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


        public User_TheoDoiDonHang(NguoiDung_DTO currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            // chọn trạng thái khởi tạo hợp lệ (ví dụ phần tử đầu tiên của mảng)
            var defaultStatus = _statuses[0]; // "Mới tạo"
            LoadDonHangTheoTrangThaiAsync(defaultStatus);
        }

        private async void LoadDonHangTheoTrangThaiAsync(string trangThai)
        {
            try
            {
                flowDonHang.Controls.Clear();
                var donHangs = await _donHangBLL.LayDonHangTheoTrangThaiAsync(trangThai, _currentUser.Id);

                if (donHangs == null || donHangs.Count == 0)
                {
                    var lblEmpty = new Label()
                    {
                        Text = $"Không có đơn hàng ở trạng thái '{trangThai}'",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Padding = new Padding(10)
                    };
                    flowDonHang.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var donHang in donHangs)
                {
                    var card = TaoCardDonHang(donHang);
                    flowDonHang.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel TaoCardDonHang(DonHang_DTO donHang)
        {
            var panel = new Panel()
            {
                Width = 250,
                Height = 150,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            var lblMaDon = new Label()
            {
                Text = $"Mã đơn: {donHang.Id}",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblTrangThai = new Label()
            {
                Text = $"Trạng thái: {donHang.TrangThai}",
                Location = new Point(10, 40),
                AutoSize = true
            };

            var lblNgayTao = new Label()
            {
                Text = $"Ngày tạo: {donHang.NgayTaoDon:dd/MM/yyyy}",
                Location = new Point(10, 65),
                AutoSize = true
            };

            var btnChiTiet = new Button()
            {
                Text = "Xem chi tiết",
                Location = new Point(10, 100),
                Width = 100,
                Height = 30,
                BackColor = Color.LightSteelBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnChiTiet.Click += (s, e) => ShowChiTietDonHang(donHang);

            panel.Controls.Add(lblMaDon);
            panel.Controls.Add(lblTrangThai);
            panel.Controls.Add(lblNgayTao);
            panel.Controls.Add(btnChiTiet);

            // Nút hủy
            if (donHang.TrangThai == "Mới tạo")
            {
                var btnHuy = new Button()
                {
                    Text = "Hủy đơn",
                    Location = new Point(120, 100),
                    Width = 100,
                    Height = 30,
                    BackColor = Color.Tomato,
                    FlatStyle = FlatStyle.Flat
                };
                btnHuy.Click += async (s, e) => await HuyDonHang(donHang);
                panel.Controls.Add(btnHuy);
            }

            // === 3. NÚT ĐÁNH GIÁ / XEM ĐÁNH GIÁ (khi hoàn thành) ===

            // === 3. ĐÁNH GIÁ / XEM ĐÁNH GIÁ (chỉ khi Hoàn thành) ===
            else if (donHang.TrangThai == "Hoàn thành")
            {
                // XÓA TẤT CẢ NÚT CŨ TẠI VỊ TRÍ (120, 100)
                var oldButton = panel.Controls
                    .OfType<Button>()
                    .FirstOrDefault(b => b.Location.X == 120 && b.Location.Y == 100);
                if (oldButton != null)
                {
                    panel.Controls.Remove(oldButton);
                    oldButton.Dispose();
                }

                bool daDanhGia = donHang.DiemDichVu > 0 || donHang.NgayDanhGiaDichVu != default;

                Button newButton;

                if (daDanhGia)
                {
                    newButton = new Button()
                    {
                        Text = "Xem đánh giá",
                        Location = new Point(120, 100),
                        Width = 100,
                        Height = 30,
                        BackColor = Color.FromArgb(255, 165, 0),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };
                    newButton.Click += (s, e) => XemDanhGiaDaGui(donHang);
                }
                else
                {
                    newButton = new Button()
                    {
                        Text = "Đánh giá",
                        Location = new Point(120, 100),
                        Width = 100,
                        Height = 30,
                        BackColor = Color.FromArgb(255, 193, 7),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };
                    newButton.Click += async (s, e) => await DanhGiaMotLan(donHang, panel);
                }

                panel.Controls.Add(newButton);
            }

            return panel;
        }
        private async Task DanhGiaMotLan(DonHang_DTO donHang, Panel card)
        {
            using (var formDanhGia = new Form()
            {
                Text = $"Đánh giá đơn {donHang.MaDonHang}",
                Size = new Size(400, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                var lblTieuDe = new Label()
                {
                    Text = "Vui lòng đánh giá dịch vụ:",
                    Location = new Point(20, 20),
                    Size = new Size(350, 30),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                // === GROUPBOX + FLOWLAYOUTPANEL ĐỂ CĂN SAO ĐẸP ===
                var grpSao = new GroupBox()
                {
                    Text = "Số sao",
                    Location = new Point(20, 55),
                    Size = new Size(350, 90),
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Padding = new Padding(10)
                };

                // FlowLayoutPanel để tự động căn đều 5 sao
                var flowSao = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(5, 10, 5, 5),
                    Margin = new Padding(0)
                };

                // Tạo 5 RadioButton
                for (int i = 1; i <= 5; i++)
                {
                    var rb = new RadioButton()
                    {
                        Text = new string('★', i), // 1★, 2★★, ...
                        Tag = i,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                        Margin = new Padding(8, 0, 8, 0),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Checked = (i == 3) // Mặc định 3 sao
                    };

                    // Tô màu khi chọn
                    rb.CheckedChanged += (s, e) =>
                    {
                        if (rb.Checked)
                            rb.ForeColor = Color.FromArgb(255, 193, 7);
                        else
                            rb.ForeColor = Color.Black;
                    };

                    flowSao.Controls.Add(rb);
                }

                grpSao.Controls.Add(flowSao);


                // === NHÃN "NHẬN XÉT" ===
                var lblBinhLuan = new Label()
                {
                    Text = "Nhận xét (tùy chọn):",
                    Location = new Point(20, 155), // Dưới GroupBox sao
                    Size = new Size(350, 25),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false
                };

                // === TEXTBOX NHẬN XÉT ===
                var txtBinhLuan = new TextBox()
                {
                    Location = new Point(20, 185),    // Dưới Label
                    Size = new Size(350, 75),         // Cao hơn, dễ nhập
                    Multiline = true,
                    AcceptsReturn = true,
                    AcceptsTab = true,
                    ScrollBars = ScrollBars.Vertical,
                    Font = new Font("Segoe UI", 10F),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(8),
                    ForeColor = Color.FromArgb(30, 30, 30)
                };

                // Gợi ý khi chưa nhập
                txtBinhLuan.GotFocus += (s, e) =>
                {
                    if (txtBinhLuan.Text == "Ví dụ: Giao hàng nhanh, đóng gói cẩn thận...")
                        txtBinhLuan.Text = "";
                };
                txtBinhLuan.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txtBinhLuan.Text))
                        txtBinhLuan.Text = "Ví dụ: Giao hàng nhanh, đóng gói cẩn thận...";
                };
                txtBinhLuan.Text = "Ví dụ: Giao hàng nhanh, đóng gói cẩn thận...";
                txtBinhLuan.ForeColor = Color.Gray;
                var btnGui = new Button()
                {
                    Text = "Gửi đánh giá",
                    Location = new Point(210, 270),
                    Size = new Size(100, 38),
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    DialogResult = DialogResult.OK
                };

                var btnHuy = new Button()
                {
                    Text = "Hủy",
                    Location = new Point(320, 270),
                    Size = new Size(60, 38),
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F),
                    DialogResult = DialogResult.Cancel
                };

                formDanhGia.Controls.AddRange(new Control[] { lblTieuDe, grpSao, lblBinhLuan, txtBinhLuan, btnGui, btnHuy });
                formDanhGia.AcceptButton = btnGui;
                formDanhGia.CancelButton = btnHuy;

                if (formDanhGia.ShowDialog() == DialogResult.OK)
                {
                    int diem = FindCheckedRadioButton(grpSao)?.Tag as int? ?? 3;

                    // Hàm helper
                    RadioButton FindCheckedRadioButton(Control parent)
                    {
                        foreach (Control c in parent.Controls)
                        {
                            if (c is RadioButton rb && rb.Checked)
                                return rb;
                            else
                            {
                                var found = FindCheckedRadioButton(c);
                                if (found != null) return found;
                            }
                        }
                        return null;
                    }


                    string binhLuan = txtBinhLuan.Text.Trim();

                    var confirm = MessageBox.Show(
                        $"XÁC NHẬN ĐÁNH GIÁ\n\n" +
                        $"Sao: {new string('★', diem)} ({diem}/5)\n" +
                        $"Nhận xét: {(string.IsNullOrEmpty(binhLuan) ? "[Không có]" : binhLuan)}\n\n" +
                        $"Gửi đánh giá này?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            donHang.DiemDichVu = diem;
                            donHang.BinhLuanDichVu = binhLuan;
                            donHang.NgayDanhGiaDichVu = DateTime.Now;

                            bool success = await _donHangBLL.CapNhatDonHangAsync(donHang);
                            if (success)
                            {
                                MessageBox.Show("Cảm ơn bạn đã đánh giá!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CapNhatCard(card, donHang);
                            }
                            else
                            {
                                MessageBox.Show("Lưu đánh giá thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void XemDanhGiaDaGui(DonHang_DTO donHang)
        {
            using (var form = new Form()
            {
                Text = "",
                Size = new Size(460, 430),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.White,
                ShowInTaskbar = false
            })
            {
                // === HEADER ===
                var pnlHeader = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 60,
                    BackColor = Color.FromArgb(255, 152, 0)
                };

                var lblHeader = new Label()
                {
                    Text = "ĐÁNH GIÁ CỦA BẠN",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlHeader.Controls.Add(lblHeader);

                // Nút X đóng form
                var btnClose = new Button()
                {
                    Text = "×",
                    Dock = DockStyle.Right,
                    Width = 60,
                    Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(255, 152, 0),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => form.Close();
                pnlHeader.Controls.Add(btnClose);

                // === PANEL NỘI DUNG CHÍNH ===
                var pnlMain = new Panel()
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(20),
                    BackColor = Color.White
                };

                // === PANEL SAO ===
                var pnlSao = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 100,
                    BackColor = Color.Transparent
                };

                var lblDiemSao = new Label()
                {
                    Text = "Điểm sao",
                    Dock = DockStyle.Top,
                    Height = 25,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(60, 60, 60),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lblSao = new Label()
                {
                    Text = donHang.DiemDichVu > 0 ? new string('★', Math.Min(donHang.DiemDichVu, 5)) : "Chưa đánh giá",
                    Dock = DockStyle.Top,
                    Height = 55,
                    Font = new Font("Segoe UI", 42F),
                    ForeColor = donHang.DiemDichVu > 0 ? Color.FromArgb(255, 193, 7) : Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var lblSoDiem = new Label()
                {
                    Text = donHang.DiemDichVu > 0 ? $"({donHang.DiemDichVu}/5)" : "",
                    Dock = DockStyle.Top,
                    Height = 25,
                    Font = new Font("Segoe UI", 11F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                pnlSao.Controls.AddRange(new Control[] { lblSoDiem, lblSao, lblDiemSao });

                // === BÌNH LUẬN ===
                var lblBinhLuan = new Label()
                {
                    Text = "Bình luận của bạn:",
                    Dock = DockStyle.Top,
                    Height = 25,
                    Margin = new Padding(0, 10, 0, 5),
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(60, 60, 60)
                };

                var txtBinhLuan = new TextBox()
                {
                    Text = string.IsNullOrWhiteSpace(donHang.BinhLuanDichVu)
                        ? "[Chưa có bình luận]"
                        : donHang.BinhLuanDichVu,
                    Dock = DockStyle.Top,
                    Height = 90,
                    Multiline = true,
                    ReadOnly = true,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = string.IsNullOrWhiteSpace(donHang.BinhLuanDichVu) ? Color.Gray : Color.FromArgb(40, 40, 40),
                    BackColor = Color.FromArgb(252, 252, 252),
                    ScrollBars = ScrollBars.Vertical
                };

                // === NGÀY ĐÁNH GIÁ ===
                var lblNgay = new Label()
                {
                    Text = $"Ngày đã đánh giá: {donHang.NgayDanhGiaDichVu:dd/MM/yyyy HH:mm}",
                    Dock = DockStyle.Top,
                    Height = 25,
                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(100, 100, 100),
                    Margin = new Padding(0, 10, 0, 0)
                };

                // === NÚT ĐÓNG ===
                var btnDong = new Button()
                {
                    Text = "Đóng",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    BackColor = Color.FromArgb(40, 167, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnDong.FlatAppearance.BorderSize = 0;
                btnDong.Click += (s, e) => form.Close();

                // === GẮN CONTROL VÀO PANEL CHÍNH ===
                pnlMain.Controls.AddRange(new Control[] { lblNgay, txtBinhLuan, lblBinhLuan, pnlSao });
                pnlMain.Controls.Add(btnDong);

                // === GẮN TẤT CẢ VÀO FORM ===
                form.Controls.AddRange(new Control[] { pnlMain, pnlHeader });

                form.ShowDialog();
            }
        }

        private void CapNhatCard(Panel card, DonHang_DTO donHang)
        {
            var parent = card.Parent as FlowLayoutPanel;
            if (parent == null) return;

            int index = parent.Controls.IndexOf(card);

            parent.SuspendLayout();
            {
                parent.Controls.Remove(card);
                card.Dispose();

                var newCard = TaoCardDonHang(donHang);
                parent.Controls.Add(newCard);
                parent.Controls.SetChildIndex(newCard, index);
            }
            parent.ResumeLayout(true);
        }
     
      
        private async Task HuyDonHang(DonHang_DTO donHang)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _donHangBLL.HuyDonHangAsync(donHang.Id);
                MessageBox.Show(success ? "Đã hủy đơn hàng." : "Không thể hủy đơn hàng.");
                if (success) LoadDonHangTheoTrangThaiAsync("Mới tạo");
            }
        }

        private async void ShowChiTietDonHang(DonHang_DTO donHang)
        {
            var chiTietSP = await _donHangBLL.LayChiTietDonHangAsync(donHang.Id);

            string text = $"Đơn hàng: {donHang.MaDonHang}\n" +
                          $"Trạng thái: {donHang.TrangThai}\n" +
                          $"Ngày tạo: {donHang.NgayTaoDon:dd/MM/yyyy HH:mm}\n" +
                          $"Ngày cập nhật cuối: {donHang.NgayCapNhatCuoi:dd/MM/yyyy HH:mm}\n" +
                          $"Người gửi: {donHang.NguoiGuiThongTin?.HoTen} - {donHang.NguoiGuiThongTin?.SoDienThoai}\n" +
                          $"Người nhận: {donHang.NguoiNhanThongTin?.HoTen} - {donHang.NguoiNhanThongTin?.SoDienThoai}\n" +
                          $"Tổng số sản phẩm: {donHang.TongSoLuongSanPham}\n" +
                          $"Tổng trọng lượng: {donHang.TongTrongLuong} kg\n" +
                          $"Tổng giá trị sản phẩm: {donHang.TongGiaTriSanPham:C}\n" +
                          $"Phí vận chuyển: {donHang.PhiVanChuyen:C}\n" +
                          $"Tổng tiền: {donHang.TongTien:C}\n" +
                          $"Hình thức thanh toán: {donHang.HinhThucThanhToan}\n" +
                          $"Đã thanh toán: {(donHang.DaThanhToan ? "Có" : "Chưa")}\n" +
                          $"Ghi chú: {donHang.GhiChuDonHang}\n" +
                          $"Yêu cầu đặc biệt: {donHang.YeuCauDacBiet}\n\n" +
                          $"--- Chi tiết sản phẩm ---\n";

            foreach (var sp in chiTietSP)
                text += $"- {sp.TenSanPham} x {sp.SoLuong} (Giá: {sp.GiaTri:C})\n";

            MessageBox.Show(text, "Chi tiết đơn hàng");
        }




        private void btnMoiTao_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Mới tạo");
        private void btnDangXuLy_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Đang xử lý");
        private void btnDangGiao_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Đang giao");
        private void btnHoanThanh_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Hoàn thành");
        private void btnDaHuy_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Đã hủy");
        private void btnDaHoanTien_Click(object sender, EventArgs e) => LoadDonHangTheoTrangThaiAsync("Đã hoàn tiền");

    }
}
