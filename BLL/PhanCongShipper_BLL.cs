using DAL;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanCongShipper_BLL
    {
        private readonly PhanCongShipper_DAL _dal = new PhanCongShipper_DAL();
        private const int MAX_DONHANG_TRONG_LUC = 5;

        // 📦 Lấy danh sách đơn hàng đang xử lý
        public async Task<List<DonHang_DTO>> LayDonHangDangXuLyAsync()
            => await _dal.LayDonHangDangXuLyAsync();

        // 🚴 Lấy danh sách shipper hiện có
        public async Task<List<NguoiDung_DTO>> LayTatCaShipperAsync()
            => await _dal.LayTatCaShipperAsync();

        // 🔍 Tìm shipper phù hợp theo khu vực, ca làm và số lượng đơn
        public async Task<NguoiDung_DTO> TimShipperPhuHopAsync(string khuVuc)
        {
            var now = DateTime.UtcNow.TimeOfDay;

            var baseFilter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(nv => nv.LoaiNguoiDung, "NhanVien"),
                Builders<NguoiDung_DTO>.Filter.Eq(nv => nv.ChucVu, "Shipper"),
                Builders<NguoiDung_DTO>.Filter.Eq(nv => nv.TrangThaiShipper, "available"),
                Builders<NguoiDung_DTO>.Filter.Lt(nv => nv.SoLuongDonHangDangGiao, MAX_DONHANG_TRONG_LUC),
                Builders<NguoiDung_DTO>.Filter.Lte(nv => nv.GioBatDauLamViec, now),
                Builders<NguoiDung_DTO>.Filter.Gte(nv => nv.GioKetThucLamViec, now)
            );

            var khuVucFilter = Builders<NguoiDung_DTO>.Filter.Regex(
                nv => nv.KhuVucPhuTrach,
                new BsonRegularExpression(khuVuc ?? "", "i")
            );

            var combined = Builders<NguoiDung_DTO>.Filter.And(baseFilter, khuVucFilter);

            // Ưu tiên shipper cùng khu vực
            var shipper = await _dal.TimShipperTheoDieuKienAsync(combined);
            if (shipper == null)
            {
                // Nếu không có ai cùng khu vực, chọn shipper rảnh bất kỳ
                shipper = await _dal.TimShipperTheoDieuKienAsync(baseFilter);
            }

            return shipper;
        }

        // 🧭 Thực hiện phân công tự động đơn hàng cho shipper phù hợp
        public async Task<bool> PhanCongDonHangAsync(ObjectId idDonHang)
        {
            var donHang = await _dal.LayDonHangTheoIdAsync(idDonHang);
            if (donHang == null) return false;

            string khuVuc = donHang.NguoiNhanThongTin?.DiaChiChiTiet ?? "";
            var shipper = await TimShipperPhuHopAsync(khuVuc);
            if (shipper == null) return false;

            var okDonHang = await _dal.CapNhatDonHangAsync(idDonHang, shipper);
            var okShipper = await _dal.CapNhatShipperAsync(shipper.Id, 1, "busy");

            return okDonHang && okShipper;
        }

        // ✅ Đánh dấu đơn hàng hoàn thành
        public async Task<bool> HoanThanhDonHangAsync(ObjectId idDonHang)
        {
            var donHang = await _dal.LayDonHangTheoIdAsync(idDonHang);
            if (donHang == null || donHang.IdNguoiPhuTrach == ObjectId.Empty)
                return false;

            bool okDon = await _dal.HoanThanhDonHangAsync(idDonHang);
            bool okShip = await _dal.CapNhatShipperAsync(donHang.IdNguoiPhuTrach, -1, "available");

            return okDon && okShip;
        }

        // 🧑‍💼 Phân công đơn hàng thủ công (chọn shipper cụ thể)
        public async Task<bool> PhanCongDonHangTheoShipperAsync(ObjectId donHangId, ObjectId shipperId)
        {
            return await _dal.PhanCongDonHangTheoShipperAsync(donHangId, shipperId);
        }
    }
}
