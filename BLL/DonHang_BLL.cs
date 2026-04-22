using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using DAL;
using MongoDB.Bson;

namespace BLL
{
    public class DonHang_BLL
    {
        private readonly DonHang_DAL _donHangService_BLL = new DonHang_DAL();

        // ===============================
        //  LẤY TẤT CẢ ĐƠN HÀNG
        // ===============================
        public async Task<List<DonHang_DTO>> LayTatCaDonHangAsync()
        {
            return await _donHangService_BLL.LayTatCaDonHangAsync();
        }

        // ===============================
        //  SHIPPER: Lấy đơn theo Shipper
        // ===============================
        public async Task<List<DonHang_DTO>> GetDonHangByShipper(string shipperId)
        {
            return await _donHangService_BLL.GetDonHangByShipper(shipperId);
        }

        // ===============================
        //  SHIPPER: Hoàn thành đơn
        // ===============================
        public async Task<bool> MarkAsCompleted(ObjectId id)
        {
            return await _donHangService_BLL.MarkAsCompleted(id);
        }

        // ===============================
        //  Cập nhật trạng thái
        // ===============================
        public async Task<bool> CapNhatTrangThaiDonHangAsync(ObjectId id, string trangThaiMoi)
        {
            return await _donHangService_BLL.CapNhatTrangThaiDonHangAsync(id, trangThaiMoi);
        }

        // ===============================
        // Tìm kiếm đơn hàng cơ bản
        // ===============================
        public async Task<List<DonHang_DTO>> TimKiemDonHangAsync(string keyword, string trangThai)
        {
            return await _donHangService_BLL.TimKiemDonHangAsync(keyword, trangThai);
        }

        // ===============================
        // Lấy đơn theo khách hàng
        // ===============================
        public async Task<List<DonHang_DTO>> LayDonHangTheoKhachHangAsync(string maKhachHang)
        {
            var tatCaDon = await _donHangService_BLL.LayTatCaDonHangAsync();
            return tatCaDon.FindAll(d => d.IdNguoiGui.ToString() == maKhachHang);
        }

        // ===============================
        // Cập nhật đơn hàng
        // ===============================
        public async Task<bool> CapNhatDonHangAsync(DonHang_DTO donHang)
        {
            try
            {
                return await _donHangService_BLL.CapNhatDonHangAsync(donHang);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BLL: " + ex.Message);
                return false;
            }
        }

        // ===============================
        // Lấy theo trạng thái
        // ===============================
        public Task<List<DonHang_DTO>> LayDonHangTheoTrangThaiAsync(string trangThai, ObjectId khachHangId)
        {
            return _donHangService_BLL.GetDonHangsByTrangThaiAsync(trangThai, khachHangId);
        }

        // ===============================
        // Lấy chi tiết sản phẩm trong đơn
        // ===============================
        public Task<List<SanPham_DTO>> LayChiTietDonHangAsync(ObjectId donHangId)
        {
            return _donHangService_BLL.GetChiTietDonHangAsync(donHangId);
        }

        // ===============================
        // Hủy đơn hàng
        // ===============================
        public Task<bool> HuyDonHangAsync(ObjectId donHangId)
        {
            return _donHangService_BLL.HuyDonHangAsync(donHangId);
        }

        // ===============================
        // Tính tổng tiền
        // ===============================
        public void TinhTongTien(DonHang_DTO donHang)
        {
            if (donHang == null || donHang.DanhSachSanPham == null)
                return;

            donHang.TongSoLuongSanPham = donHang.DanhSachSanPham.Sum(sp => sp.SoLuong);
            donHang.TongTrongLuong = donHang.DanhSachSanPham.Sum(sp => sp.TrongLuong * sp.SoLuong);
            donHang.TongGiaTriSanPham = donHang.DanhSachSanPham.Sum(sp => sp.GiaTri * sp.SoLuong);

            donHang.PhiVanChuyen = (decimal)(donHang.TongTrongLuong * 10000);

            donHang.TongTien = donHang.TongGiaTriSanPham + donHang.PhiVanChuyen;
        }

        // ===============================
        // Lưu đơn hàng mới
        // ===============================
        public async Task<bool> TaoDonHangAsync(DonHang_DTO donHang)
        {
            TinhTongTien(donHang);

            if (string.IsNullOrEmpty(donHang.TrangThai))
                donHang.TrangThai = "Mới tạo";

            donHang.NgayTaoDon = DateTime.Now;

            return await _donHangService_BLL.TaoDonHangAsync(donHang);
        }

        // ===============================
        // Phân trang
        // ===============================
        public List<DonHang_DTO> LayTrangHienTai(List<DonHang_DTO> data, int page, int pageSize)
        {
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int TinhTongSoTrang(int totalCount, int pageSize)
        {
            return (int)Math.Ceiling((double)totalCount / pageSize);
        }

        // ===============================
        // Lấy theo SDT + ngày
        // ===============================
        public async Task<List<DonHang_DTO>> LayDonHangTheoSDTvaNgayAsync(string soDienThoai, DateTime ngay)
        {
            return await _donHangService_BLL.LayDonHangTheoSDTvaNgayAsync(soDienThoai, ngay);
        }

        // ===============================
        // Tìm đơn lẻ
        // ===============================
        public async Task<List<DonHang_DTO>> TimDonHangDonLeAsync(
            string soDienThoai,
            string maDonHang,
            DateTime? ngay,
            bool? daThanhToan)
        {
            return await _donHangService_BLL.TimDonHangDonLeAsync(
                soDienThoai, maDonHang, ngay, daThanhToan);
        }

        // ===============================
        // Tìm trong khoảng thời gian
        // ===============================
        public async Task<List<DonHang_DTO>> TimDonHangTheoKhoangThoiGianAsync(
            DateTime ngayBatDau,
            DateTime ngayKetThuc,
            string soDienThoai,
            string maDonHang,
            bool? daThanhToan)
        {
            return await _donHangService_BLL.TimDonHangTheoKhoangThoiGianAsync(
                ngayBatDau, ngayKetThuc, soDienThoai, maDonHang, daThanhToan);
        }

        // ===============================
        // Tìm kiếm nâng cao
        // ===============================
        public async Task<List<DonHang_DTO>> TimKiemNangCaoAsync(
            string maDonHang,
            string sdtNguoiGui,
            string sdtNguoiNhan,
            string trangThai,
            DateTime? tuNgay,
            DateTime? denNgay,
            bool? daThanhToan)
        {
            return await _donHangService_BLL.TimKiemNangCaoAsync(
                maDonHang,
                sdtNguoiGui,
                sdtNguoiNhan,
                trangThai,
                tuNgay,
                denNgay,
                daThanhToan
            );
        }
        public Task<bool> HuyDonHangLDAsync(ObjectId donHangId, string ghiChu)
        {
            return _donHangService_BLL.HuyDonHangLDAsync(donHangId, ghiChu);
        }
    }
}
