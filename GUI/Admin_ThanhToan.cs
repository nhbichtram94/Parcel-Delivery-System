using BLL;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace GUI
{
    public partial class Admin_ThanhToan : Form
    {
        private readonly DonHang_BLL _donHangBLL = new DonHang_BLL();
        public Admin_ThanhToan()
        {
            InitializeComponent();
        }

        private void Admin_ThanhToan_Load(object sender, EventArgs e)
        {

            // Ẩn giá trị ban đầu của DateTimePicker (trông như trống)
            dtp_Ngay.Format = DateTimePickerFormat.Custom;
            dtp_Ngay.CustomFormat = " ";
            // Ẩn giá trị ban đầu của DateTimePicker (trông như trống)
            dtp_ngayDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayDau.CustomFormat = " ";
            // Ẩn giá trị ban đầu của DateTimePicker (trông như trống)
            dtp_ngayCuoi.Format = DateTimePickerFormat.Custom;
            dtp_ngayCuoi.CustomFormat = " ";

            grB_TimKiem.Enabled = false;
            grB_TimKiem_ThoiGian.Enabled = false;

            // Các cài đặt khác
            cbo_TrangThai.Items.Clear();
            cbo_TrangThai.Items.Add("Tất cả");
            cbo_TrangThai.Items.Add("Đã thanh toán");
            cbo_TrangThai.Items.Add("Chưa thanh toán");
            cbo_TrangThai.SelectedIndex = 0; // mặc định là "Tất cả"

            // Các cài đặt khác
            cbo_trangThai_2.Items.Clear();
            cbo_trangThai_2.Items.Add("Tất cả");
            cbo_trangThai_2.Items.Add("Đã thanh toán");
            cbo_trangThai_2.Items.Add("Chưa thanh toán");
            cbo_trangThai_2.SelectedIndex = 0; // mặc định là "Tất cả"
        }

        private void rdo_ChuaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            LocTheoTrangThai();
        }



        private async void btn_Tim_Click(object sender, EventArgs e)
        {

            try
            {
                bool? daThanhToan = null;
                string luaChonThanhToan = cbo_TrangThai.SelectedItem?.ToString();
                if (luaChonThanhToan == "Đã thanh toán")
                    daThanhToan = true;
                else if (luaChonThanhToan == "Chưa thanh toán")
                    daThanhToan = false;


                string sdt = textBox_SDT.Text.Trim();
                string maDon = txt_MaDH.Text.Trim();

                DateTime? ngay = null;
                if (dtp_Ngay.CustomFormat != " ") // nghĩa là user đã chọn ngày thật
                {
                    ngay = dtp_Ngay.Value.Date;
                }


                if (string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(maDon))
                {
                    MessageBox.Show("Vui lòng nhập SĐT hoặc Mã đơn hàng để tìm!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Console.WriteLine($"Trạng thái thanh toán = {cbo_TrangThai.SelectedItem}");

                Console.WriteLine($"daThanhToan = {daThanhToan}");
                var ketQua = await _donHangBLL.TimDonHangDonLeAsync(sdt, maDon, ngay, daThanhToan);

                if (ketQua == null || ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_DonHangTheoTimKiem.DataSource = null;
                    return;
                }

                /// Hiển thị datagridview
                SetupColumnsForThanhToan(dgv_DonHangTheoTimKiem);
                dgv_DonHangTheoTimKiem.DataSource = ketQua;



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocTheoTrangThai()
        {

        }

        private void rdo_DaThanhToan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            grB_TimKiem.Enabled = true;
            grB_TimKiem_ThoiGian.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            grB_TimKiem.Enabled = false;
            grB_TimKiem_ThoiGian.Enabled = true;
        }

        private void dtp_Ngay_ValueChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn ngày => hiển thị lại đúng định dạng
            dtp_Ngay.Format = DateTimePickerFormat.Custom;
            dtp_Ngay.CustomFormat = "dd/MM/yyyy";
        }

        private async void btn_tim_2_Click(object sender, EventArgs e)
        {
            try
            {
                string luaChonThanhToan = cbo_trangThai_2.SelectedItem?.ToString();

                bool? daThanhToan = null;
                if (luaChonThanhToan == "Đã thanh toán")
                    daThanhToan = true;
                else if (luaChonThanhToan == "Chưa thanh toán")
                    daThanhToan = false;
                DateTime ngayBatDau = dtp_ngayDau.Value.Date;
                DateTime ngayKetThuc = dtp_ngayCuoi.Value.Date;
                string sdt = txtSDT_2.Text.Trim();
                string maDon = txt_MaDH_2.Text.Trim();

                if (ngayKetThuc < ngayBatDau)
                {
                    MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ketQua = await _donHangBLL.TimDonHangTheoKhoangThoiGianAsync(
                    ngayBatDau, ngayKetThuc, sdt, maDon, daThanhToan);

                if (ketQua == null || ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào trong khoảng thời gian này!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_DonHangTheoTimKiem.DataSource = null;
                    return;
                }

                dgv_DonHangTheoTimKiem.DataSource = null;
                dgv_DonHangTheoTimKiem.AutoGenerateColumns = false;
                dgv_DonHangTheoTimKiem.DataSource = ketQua;

                /// Hiển thị datagridview
                SetupColumnsForThanhToan(dgv_DonHangTheoTimKiem);
                dgv_DonHangTheoTimKiem.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reset2_Click(object sender, EventArgs e)
        {
            // Ẩn giá trị ban đầu của DateTimePicker (trông như trống)
            dtp_ngayDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayDau.CustomFormat = " ";
            dtp_ngayCuoi.Format = DateTimePickerFormat.Custom;
            dtp_ngayCuoi.CustomFormat = " ";
            txtSDT_2.Clear();
            txt_MaDH_2.Clear();
            cbo_trangThai_2.SelectedIndex = -1;
            dgv_DonHangTheoTimKiem.DataSource = null;
        }

        private void SetupColumnsForThanhToan(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaDonHang",
                HeaderText = "Mã đơn hàng",
                Width = 160
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongGiaTriSanPham",
                HeaderText = "Tổng giá trị sản phẩm (₫)",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhiVanChuyen",
                HeaderText = "Phí vận chuyển (₫)",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HinhThucThanhToan",
                HeaderText = "Hình thức thanh toán",
                Width = 150
            });

            dgv.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "DaThanhToan",
                HeaderText = "Đã thanh toán?",
                Width = 120,
                ReadOnly = true // ✅ không cho tick vào
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayTaoDon",
                HeaderText = "Ngày tạo đơn",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayCapNhatCuoi",
                HeaderText = "Ngày cập nhật cuối",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            // Làm đẹp
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ReadOnly = true;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            // Ẩn giá trị ban đầu của DateTimePicker (trông như trống)
            dtp_Ngay.Format = DateTimePickerFormat.Custom;
            dtp_Ngay.CustomFormat = " ";
            textBox_SDT.Clear();
            txt_MaDH.Clear();
            cbo_TrangThai.SelectedIndex = -1;
            dgv_DonHangTheoTimKiem.DataSource = null;
        }

        private void dtp_ngayDau_ValueChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn ngày => hiển thị lại đúng định dạng
            dtp_ngayDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayDau.CustomFormat = "dd/MM/yyyy";
        }

        private void dtp_ngayCuoi_ValueChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn ngày => hiển thị lại đúng định dạng
            dtp_ngayCuoi.Format = DateTimePickerFormat.Custom;
            dtp_ngayCuoi.CustomFormat = "dd/MM/yyyy";
        }

        private void dgv_DonHangTheoTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                var row = dgv_DonHangTheoTimKiem.Rows[e.RowIndex];

                // Lấy mã đơn hàng
                string maDonHang = row.Cells[0].Value?.ToString();

                // Gọi BLL để lấy chi tiết đơn hàng
                HienThiChiTietDonHang(maDonHang);
            }
        }

        private async void HienThiChiTietDonHang(string maDonHang)
        {
            try
            {
                var danhSach = await _donHangBLL.TimKiemDonHangAsync(maDonHang, "Tất cả");
                if (danhSach == null || danhSach.Count == 0)
                {
                    listBox_ChiTietDh.Items.Clear();
                    listBox_ChiTietDh.Items.Add("Không tìm thấy đơn hàng.");
                    return;
                }

                var donHang = danhSach.First();

                listBox_ChiTietDh.Items.Clear();
                listBox_ChiTietDh.Items.Add($"🧾 Mã đơn hàng: {donHang.MaDonHang}");
                listBox_ChiTietDh.Items.Add($"👤 Người gửi: {donHang.NguoiGuiThongTin?.HoTen} - {donHang.NguoiGuiThongTin?.SoDienThoai}");
                listBox_ChiTietDh.Items.Add($"📦 Người nhận: {donHang.NguoiNhanThongTin?.HoTen} - {donHang.NguoiNhanThongTin?.SoDienThoai}");
                listBox_ChiTietDh.Items.Add($"🏠 Địa chỉ nhận: {donHang.NguoiNhanThongTin?.DiaChiChiTiet}, " +
                                            $"{donHang.NguoiNhanThongTin?.PhuongXa}, " +
                                            $"{donHang.NguoiNhanThongTin?.QuanHuyen}, " +
                                            $"{donHang.NguoiNhanThongTin?.TinhThanh}");
                listBox_ChiTietDh.Items.Add($"💰 Tổng giá trị: {donHang.TongGiaTriSanPham:N0} ₫");
                listBox_ChiTietDh.Items.Add($"🚚 Phí vận chuyển: {donHang.PhiVanChuyen:N0} ₫");
                listBox_ChiTietDh.Items.Add($"🪙 Tổng cộng: {donHang.TongTien:N0} ₫");
                listBox_ChiTietDh.Items.Add($"💳 Hình thức TT: {donHang.HinhThucThanhToan}");
                listBox_ChiTietDh.Items.Add($"🔘 Đã thanh toán: {(donHang.DaThanhToan ? "✅ Có" : "❌ Chưa")}");
                listBox_ChiTietDh.Items.Add($"📅 Ngày tạo: {donHang.NgayTaoDon:dd/MM/yyyy HH:mm}");
                listBox_ChiTietDh.Items.Add($"🕒 Cập nhật cuối: {donHang.NgayCapNhatCuoi:dd/MM/yyyy HH:mm}");
                listBox_ChiTietDh.Items.Add($"📋 Trạng thái: {donHang.TrangThai}");
                listBox_ChiTietDh.Items.Add($"🧍 Người phụ trách: {donHang.NguoiPhuTrachTen ?? "Chưa phân công"}");

                listBox_ChiTietDh.Items.Add("📦 Danh sách sản phẩm:");
                foreach (var sp in donHang.DanhSachSanPham)
                {
                    listBox_ChiTietDh.Items.Add($"   - {sp.TenSanPham} | SL: {sp.SoLuong} | Giá: {sp.GiaTri:N0}₫");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi tiết: {ex.Message}");
            }
        }
        private async Task XuatChiTietDonHangRaTxt(string maDonHang)
        {
            try
            {
                var danhSach = await _donHangBLL.TimKiemDonHangAsync(maDonHang, "Tất cả");
                if (danhSach == null || danhSach.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var donHang = danhSach.First();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Mã đơn hàng: {donHang.MaDonHang}");
                sb.AppendLine($"Người gửi: {donHang.NguoiGuiThongTin?.HoTen} - {donHang.NguoiGuiThongTin?.SoDienThoai}");
                sb.AppendLine($"Người nhận: {donHang.NguoiNhanThongTin?.HoTen} - {donHang.NguoiNhanThongTin?.SoDienThoai}");
                sb.AppendLine($"Địa chỉ nhận: {donHang.NguoiNhanThongTin?.DiaChiChiTiet}, " +
                              $"{donHang.NguoiNhanThongTin?.PhuongXa}, " +
                              $"{donHang.NguoiNhanThongTin?.QuanHuyen}, " +
                              $"{donHang.NguoiNhanThongTin?.TinhThanh}");
                sb.AppendLine($"Tổng giá trị: {donHang.TongGiaTriSanPham:N0} ₫");
                sb.AppendLine($"Phí vận chuyển: {donHang.PhiVanChuyen:N0} ₫");
                sb.AppendLine($"Tổng cộng: {donHang.TongTien:N0} ₫");
                sb.AppendLine($"Hình thức thanh toán: {donHang.HinhThucThanhToan}");
                sb.AppendLine($"Đã thanh toán: {(donHang.DaThanhToan ? "Có" : "Chưa")}");
                sb.AppendLine($"Ngày tạo: {donHang.NgayTaoDon:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"Cập nhật cuối: {donHang.NgayCapNhatCuoi:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"Trạng thái: {donHang.TrangThai}");
                sb.AppendLine($"Người phụ trách: {donHang.NguoiPhuTrachTen ?? "Chưa phân công"}");

                sb.AppendLine("\nDanh sách sản phẩm:");
                foreach (var sp in donHang.DanhSachSanPham)
                {
                    sb.AppendLine($"- {sp.TenSanPham} | SL: {sp.SoLuong} | Giá: {sp.GiaTri:N0}₫");
                }

                // Chọn nơi lưu
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    sfd.FileName = $"ChiTietDonHang_{donHang.MaDonHang}.txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file TXT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file TXT: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btn_CapNhatTrangThaiThanhToan_Click(object sender, EventArgs e)
        {
            if (dgv_DonHangTheoTimKiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDonHang = dgv_DonHangTheoTimKiem.CurrentRow.Cells[0].Value?.ToString();

            try
            {
                // Lấy danh sách đơn hàng có mã tương ứng
                var danhSach = await _donHangBLL.TimKiemDonHangAsync(maDonHang, "Tất cả");
                var donHang = danhSach.FirstOrDefault();
                if (donHang == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật trạng thái thanh toán
                donHang.DaThanhToan = true;
                donHang.NgayCapNhatCuoi = DateTime.Now;

                bool ketQua = await _donHangBLL.CapNhatDonHangAsync(donHang);

                if (ketQua)
                {
                    MessageBox.Show("✅ Cập nhật trạng thái thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Tim.PerformClick(); // làm mới danh sách
                }
                else
                {
                    MessageBox.Show("❌ Không thể cập nhật đơn hàng!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        private async void btnXuatTxt_Click(object sender, EventArgs e)
        {
            string maDon = txt_MaDH.Text.Trim();

            if (string.IsNullOrEmpty(maDon))
            {
                MessageBox.Show("Vui lòng nhập mã đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await XuatChiTietDonHangRaTxt(maDon);
        }

    }
}
