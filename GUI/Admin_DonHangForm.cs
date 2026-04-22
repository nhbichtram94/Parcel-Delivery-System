using BLL;
using DTO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Admin_DonHangForm : Form
    {
        private readonly DonHang_BLL _donHangBLL = new DonHang_BLL();
        private List<DonHang_DTO> _danhSachDonHang = new List<DonHang_DTO>();
        private List<DonHang_DTO> _filteredDonHang = new List<DonHang_DTO>();

        private int _pageSize = 10;
        private int _currentPage = 1;

        private readonly string[] _statuses =
    {
    "Mới tạo",
    "Đang xử lý",
    "Đang giao",
    "Hoàn thành",
    "Đã hủy",
    "Đã hoàn tiền"
};

        private ContextMenuStrip _statusContextMenu;

        public Admin_DonHangForm()
        {
            InitializeComponent();

            Load += Admin_DonHangForm_Load;

            // Đăng ký sự kiện nút
            btnReset.Click += BtnReset_Click;
            btnSapXepMoiNhat.Click += BtnSapXepMoiNhat_Click;
            
            btnPrevPage.Click += BtnPrevPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            cbTrangThaiLoc.SelectedIndexChanged += CbTrangThaiLoc_SelectedIndexChanged;

            KhoiTaoBangDonHang();
            KhoiTaoContextMenu();
        }

        private async void Admin_DonHangForm_Load(object sender, EventArgs e)
        {
            await LoadDonHangAsync();
        }

        #region ======== Khởi tạo DataGridView ========
        private void KhoiTaoBangDonHang()
        {
            DgvDonHang.Columns.Clear();
            DgvDonHang.AutoGenerateColumns = false;
            DgvDonHang.AllowUserToAddRows = false;
            DgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaDonHang",
                HeaderText = "Mã đơn hàng",
                DataPropertyName = "MaDonHang",
                Width = 150
            });

            // Id khách hàng
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdKhachHang",
                HeaderText = "Mã Khách hàng",
                DataPropertyName = "IdKhachHang",
                Width = 120
            });


            // Ngày tạo
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTenNguoiNhan",
                HeaderText = "Họ tên người gửi",
                DataPropertyName = "HoTenNguoiNhan",
                Width = 140,
              
            });

            // Tổng tiền
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTenNguoiGui",
                HeaderText = "Họ tên người nhận",
                DataPropertyName = "HoTenNguoiGui",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Trạng thái
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 100
            });
            // Tổng tiền
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayTao",
                HeaderText = "Ngày Tạo",
                DataPropertyName = "NgayTao",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            DgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongTien",
                HeaderText = "Tổng Tiền",
                DataPropertyName = "TongTien",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            DgvDonHang.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "XemChiTiet",
                HeaderText = "Xem chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            DgvDonHang.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "LamMoi",
                HeaderText = "Làm mới",
                Text = "Làm mới",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            DgvDonHang.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "CapNhatTrangThai",
                HeaderText = "Cập nhật trạng thái",
                Text = "Cập nhật",
                UseColumnTextForButtonValue = true,
                Width = 110
            });

            DgvDonHang.CellContentClick += DgvDonHang_CellContentClick;
        }

        private void KhoiTaoContextMenu()
        {
            _statusContextMenu = new ContextMenuStrip();
            _statusContextMenu.ItemClicked += StatusContextMenu_ItemClicked;
        }
        #endregion

        #region ======== Load dữ liệu ========
        private async Task LoadDonHangAsync()
        {
            try
            {
                _danhSachDonHang = await _donHangBLL.LayTatCaDonHangAsync();

                if (_danhSachDonHang.Count == 0)
                {
                    MessageBox.Show("Chưa có đơn hàng nào!");
                    DgvDonHang.Rows.Clear();
                    lblTrang.Text = "Trang 0 / 0";
                    return;
                }

                _filteredDonHang = new List<DonHang_DTO>(_danhSachDonHang);
                _currentPage = 1;
                LoadPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn hàng: {ex.Message}");
            }
        }
        #endregion

        #region ======== Phân trang & Lọc ========
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            text = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = text
                .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                            System.Globalization.UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(System.Text.NormalizationForm.FormC).ToLower();
        }

        private void ApplyFilters()
        {
            // 🔍 Lấy giá trị tìm kiếm và chuẩn hóa
            string maDonHang = RemoveDiacritics(txtMaDonHang.Text.Trim());
              string trangThai = cbTrangThaiLoc.SelectedItem?.ToString() ?? "Tất cả";

            // 🧾 Bắt đầu từ toàn bộ danh sách
            IEnumerable<DonHang_DTO> query = _danhSachDonHang;

            // 🔹 Lọc theo mã đơn
            if (!string.IsNullOrEmpty(maDonHang))
                query = query.Where(d =>
                    !string.IsNullOrEmpty(d.MaDonHang) &&
                    RemoveDiacritics(d.MaDonHang).Contains(maDonHang));

            // 🔹 Lọc theo tên người gửi
            //if (!string.IsNullOrEmpty(tenNguoiGui))
            //    query = query.Where(d =>
            //        d.NguoiGuiThongTin != null &&
            //        !string.IsNullOrEmpty(d.NguoiGuiThongTin.HoTen) &&
            //        RemoveDiacritics(d.NguoiGuiThongTin.HoTen).Contains(tenNguoiGui));

            //// 🔹 Lọc theo tên người nhận
            //if (!string.IsNullOrEmpty(tenNguoiNhan))
            //    query = query.Where(d =>
            //        d.NguoiNhanThongTin!= null &&
            //        !string.IsNullOrEmpty(d.NguoiNhanThongTin.HoTen) &&
            //        RemoveDiacritics(d.NguoiNhanThongTin.HoTen).Contains(tenNguoiNhan));

            //// 🔹 Lọc theo trạng thái
            if (trangThai != "Tất cả")
                query = query.Where(d =>
                    !string.IsNullOrEmpty(d.TrangThai) &&
                    d.TrangThai.Equals(trangThai, StringComparison.OrdinalIgnoreCase));

            // ✅ Cập nhật danh sách hiển thị
            _filteredDonHang = query.ToList();
            _currentPage = 1;
            LoadPage();

            // Nếu không tìm thấy
            if (_filteredDonHang.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void LoadPage()
        {
            DgvDonHang.Rows.Clear();
            int totalPage = (int)Math.Ceiling((double)_filteredDonHang.Count / _pageSize);
            if (totalPage == 0) totalPage = 1;

            _currentPage = Math.Max(1, Math.Min(_currentPage, totalPage));
            var pageData = _filteredDonHang.Skip((_currentPage - 1) * _pageSize).Take(_pageSize);

            foreach (var donHang in pageData)
            {
                int rowIndex = DgvDonHang.Rows.Add(
                    donHang.MaDonHang,
                    donHang.IdNguoiGui, // hoặc IdNguoiNhan nếu bạn muốn hiển thị người nhận
                    donHang.NguoiGuiThongTin?.HoTen ?? "",
                    donHang.NguoiNhanThongTin?.HoTen ?? "",
                    donHang.TrangThai,
                    donHang.NgayTaoDon.ToLocalTime().ToString("dd/MM/yyyy HH:mm"),
                    $"{donHang.TongTien:N0} VNĐ"
                );
                DgvDonHang.Rows[rowIndex].Tag = donHang.Id;
            }

            lblTrang.Text = $"Trang {_currentPage} / {totalPage}";
        }
        #endregion

        #region ======== Xử lý sự kiện nút ========
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1) _currentPage--;
            LoadPage();
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalPage = (int)Math.Ceiling((double)_filteredDonHang.Count / _pageSize);
            if (_currentPage < totalPage) _currentPage++;
            LoadPage();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cbTrangThaiLoc.SelectedIndex = 0;
            _filteredDonHang = new List<DonHang_DTO>(_danhSachDonHang);
            _currentPage = 1;
            LoadPage();
        }

        private void CbTrangThaiLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnSapXepMoiNhat_Click(object sender, EventArgs e)
        {
            _filteredDonHang = _filteredDonHang.OrderByDescending(d => d.NgayTaoDon).ToList();
            _currentPage = 1;
            LoadPage();
        }

        private async void BtnTimKiem_Click(object sender, EventArgs e)
        {
            await TimKiemNangCaoAsync();
        }
        #endregion

        #region ======== Tìm kiếm nâng cao ========
        private async Task TimKiemNangCaoAsync()
        {
            string maDonHang = txtMaDonHang.Text.Trim();
         
            string sdtNguoiGui = txtSDTNguoiGui.Text.Trim();
           
            string sdtNguoiNhan = txtSDTNguoiNhan.Text.Trim();
            string trangThai = cbTrangThaiLoc.SelectedItem?.ToString();

            DateTime? tuNgay = dtpTuNgay.Checked ? dtpTuNgay.Value.Date : (DateTime?)null;
            DateTime? denNgay = dtpDenNgay.Checked ? dtpDenNgay.Value.Date : (DateTime?)null;
            bool? daThanhToan = chkDaThanhToan.Checked ? true : (bool?)null;

            try
            {
                // 🔹 Gọi BLL để tìm kiếm trực tiếp MongoDB
                _filteredDonHang = await _donHangBLL.TimKiemNangCaoAsync(
                    maDonHang,
                 
                    sdtNguoiGui,
                  
                    sdtNguoiNhan,
                    trangThai,
                    tuNgay,
                    denNgay,
                    daThanhToan
                );

                _currentPage = 1;
                LoadPage();

                if (_filteredDonHang.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm nâng cao: {ex.Message}");
            }

        }

        #endregion

        #region ======== Cập nhật trạng thái ========
        private void DgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            string maDonHang = dgv.Rows[e.RowIndex].Cells["MaDonHang"].Value?.ToString();

            if (colName == "XemChiTiet")
            {
                var donHang = _danhSachDonHang.FirstOrDefault(d => d.Id == (ObjectId)DgvDonHang.Rows[e.RowIndex].Tag);
                if (donHang != null)
                {
                    // --- Danh sách sản phẩm ---
                    string danhSachSanPham = "";
                    if (donHang.DanhSachSanPham != null && donHang.DanhSachSanPham.Count > 0)
                    {
                        for (int i = 0; i < donHang.DanhSachSanPham.Count; i++)
                        {
                            var sp = donHang.DanhSachSanPham[i];
                            danhSachSanPham += $"{i + 1}. {sp.TenSanPham} - SL: {sp.SoLuong} - Giá: {sp.GiaTri:N0} VNĐ\n";
                        }
                    }
                    else
                    {
                        danhSachSanPham = "Chưa có sản phẩm trong đơn hàng.\n";
                    }

                    // --- Người phụ trách ---
                    string nguoiPhuTrach = !string.IsNullOrEmpty(donHang.NguoiPhuTrachTen)
                        ? donHang.NguoiPhuTrachTen
                        : "Chưa có người phụ trách";

                    // --- Gộp thông tin hiển thị ---
                    string chiTiet =
                        $"--- THÔNG TIN ĐƠN HÀNG ---\n" +
                        $"Mã đơn hàng: {donHang.MaDonHang}\n" +
                        $"Ngày tạo: {donHang.NgayTaoDon:dd/MM/yyyy HH:mm}\n" +
                        $"Trạng thái: {donHang.TrangThai}\n" +
                        $"Thanh toán: {donHang.HinhThucThanhToan} ({(donHang.DaThanhToan ? "Đã thanh toán" : "Chưa thanh toán")})\n" +
                        $"Phí vận chuyển: {donHang.PhiVanChuyen:N0} VNĐ\n" +
                        $"Tổng tiền: {donHang.TongTien:N0} VNĐ\n\n" +

                        $"--- NGƯỜI GỬI / NGƯỜI NHẬN ---\n" +
                        $"Người gửi: {donHang.NguoiGuiThongTin?.HoTen ?? ""} | " +
                        $"{donHang.NguoiGuiThongTin?.SoDienThoai ?? ""} | " +
                        $"{donHang.NguoiGuiThongTin?.DiaChiChiTiet ?? ""}\n" +
                        $"Người nhận: {donHang.NguoiNhanThongTin?.HoTen ?? ""} | " +
                        $"{donHang.NguoiNhanThongTin?.SoDienThoai ?? ""} | " +
                        $"{donHang.NguoiNhanThongTin?.DiaChiChiTiet ?? ""}\n\n" +

                        $"--- NGƯỜI PHỤ TRÁCH ---\n{nguoiPhuTrach}\n\n" +

                        $"--- GHI CHÚ & YÊU CẦU ---\n" +
                        $"Ghi chú: {donHang.GhiChuDonHang ?? "Không có"}\n" +
                        $"Yêu cầu đặc biệt: {donHang.YeuCauDacBiet ?? "Không có"}\n\n" +

                        $"--- DANH SÁCH SẢN PHẨM ({donHang.TongSoLuongSanPham} SP, {donHang.TongTrongLuong} kg) ---\n" +
                        danhSachSanPham;

                    MessageBox.Show(chiTiet, "Chi tiết đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "LamMoi")
            {
                MessageBox.Show($"Làm mới đơn hàng: {maDonHang}");
            }
            else if (colName == "CapNhatTrangThai")
            {
                HienThiContextMenuTrangThai(e.RowIndex, e.ColumnIndex);
            }
        }

        private void HienThiContextMenuTrangThai(int rowIndex, int columnIndex)
        {
            string currentStatus = DgvDonHang.Rows[rowIndex].Cells["TrangThai"].Value?.ToString();
            int startIndex = Array.IndexOf(_statuses, currentStatus);
            if (startIndex < 0) startIndex = 0;

            _statusContextMenu.Items.Clear();
            for (int i = startIndex; i < _statuses.Length; i++)
                _statusContextMenu.Items.Add(_statuses[i]);

            var cellRect = DgvDonHang.GetCellDisplayRectangle(columnIndex, rowIndex, true);
            var point = DgvDonHang.PointToScreen(new Point(cellRect.Left, cellRect.Bottom));
            _statusContextMenu.Tag = rowIndex;
            _statusContextMenu.Show(point);
        }

        private async void StatusContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int rowIndex = (int)((ContextMenuStrip)sender).Tag;
            string selectedStatus = e.ClickedItem.Text;

            var row = DgvDonHang.Rows[rowIndex];
            if (row.Tag is ObjectId donHangId)
            {
                bool updated = await _donHangBLL.CapNhatTrangThaiDonHangAsync(donHangId, selectedStatus);
                if (updated)
                {
                    row.Cells["TrangThai"].Value = selectedStatus;
                    MessageBox.Show("Cập nhật trạng thái thành công.");
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật trạng thái (có thể là lùi lại?).");
                }
            }
            _statusContextMenu.Hide();
        }
        #endregion

        #region ======== Xuất file CSV ========
     
        private void XuatExcel_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV file|*.csv",
                FileName = $"DonHang_{timestamp}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                {
                    // Ghi dòng tiêu đề
                    sw.WriteLine("Mã đơn hàng,Trạng thái,Ngày tạo,Tổng tiền");

                    // Ghi từng dòng dữ liệu
                    foreach (DataGridViewRow row in DgvDonHang.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string ma = EscapeCsv(row.Cells["MaDonHang"].Value?.ToString());
                        string tt = EscapeCsv(row.Cells["TrangThai"].Value?.ToString());
                        string ngay = FormatDateTime(row.Cells["NgayTao"].Value);
                        string tong = EscapeCsv(row.Cells["TongTien"].Value?.ToString());

                        string line = $"{ma},{tt},{ngay},{tong}";
                        sw.WriteLine(line);
                    }
                }

                MessageBox.Show("Xuất file CSV thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            if (input.Contains(",") || input.Contains("\n") || input.Contains("\""))
                input = "\"" + input.Replace("\"", "\"\"") + "\"";
            return input;
        }

        // ✅ Hàm xử lý an toàn giá trị ngày giờ
        private string FormatDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
                return "";

            // Nếu là DateTime thật
            if (value is DateTime dt)
                return dt.ToString("dd/MM/yyyy HH:mm");

            // Nếu là chuỗi có thể parse được
            if (DateTime.TryParse(value.ToString(), out DateTime parsed))
                return parsed.ToString("dd/MM/yyyy HH:mm");

            // Nếu không parse được, trả nguyên chuỗi
            return EscapeCsv(value.ToString());
        }
        #endregion





        private void btnReset_Click_1(object sender, EventArgs e)
        {
            txtMaDonHang.Text = "";
          
            txtSDTNguoiGui.Text = "";
         
            txtSDTNguoiNhan.Text = "";

            // Reset combobox trạng thái
            cbTrangThaiLoc.SelectedIndex = 0; // "Tất cả"

            // Reset các datepicker
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;

            // Reset checkbox
            chkDaThanhToan.Checked = false;

            // Reset dữ liệu
            _filteredDonHang = new List<DonHang_DTO>(_danhSachDonHang);
            _currentPage = 1;

            // Load lại trang đầu tiên
            LoadPage();
        }

        private void lblTrang_Click(object sender, EventArgs e)
        {

        }
    }
}
