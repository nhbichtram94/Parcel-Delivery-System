using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanCongShipper_DAL
    {
        private readonly IMongoCollection<DonHang_DTO> _donHangCollection;
        private readonly IMongoCollection<NguoiDung_DTO> _nguoiDungCollection;

        public PhanCongShipper_DAL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("GiaoNhanBuuPham");

            _donHangCollection = db.GetCollection<DonHang_DTO>("DonHang");
            _nguoiDungCollection = db.GetCollection<NguoiDung_DTO>("NguoiDung");
        }

        // 🧾 Lấy thông tin đơn hàng theo ID
        public async Task<DonHang_DTO> LayDonHangTheoIdAsync(ObjectId id)
        {
            return await _donHangCollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        // 🔍 Tìm shipper thỏa điều kiện (lọc trong collection NguoiDung)
        public async Task<NguoiDung_DTO> TimShipperTheoDieuKienAsync(FilterDefinition<NguoiDung_DTO> filter)
        {
            var filterShipper = Builders<NguoiDung_DTO>.Filter.And(
                filter,
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "NhanVien"),
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.ChucVu, "Shipper")
            );

            return await _nguoiDungCollection
                .Find(filterShipper)
                .SortBy(nd => nd.SoLuongDonHangDangGiao)
                .FirstOrDefaultAsync();
        }

        // 🚚 Cập nhật đơn hàng khi đã phân công shipper
        public async Task<bool> CapNhatDonHangAsync(ObjectId idDonHang, NguoiDung_DTO shipper)
        {
            var update = Builders<DonHang_DTO>.Update
                .Set(d => d.IdNguoiPhuTrach, shipper.Id)
                .Set(d => d.NguoiPhuTrachTen, shipper.HoTen ?? "")
                .Set(d => d.TrangThai, "Đang giao")
                .Set(d => d.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(d => d.Id == idDonHang, update);
            return result.ModifiedCount > 0;
        }


        // 🔄 Cập nhật thông tin shipper khi nhận/hoàn thành đơn
        public async Task<bool> CapNhatShipperAsync(ObjectId shipperId, int thayDoiSoDon, string trangThai)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.Id, shipperId),
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "NhanVien"),
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.ChucVu, "Shipper")
            );

            var update = Builders<NguoiDung_DTO>.Update
                .Inc("SoLuongDonHangDangGiao", thayDoiSoDon)
                .Set("TrangThaiShipper", trangThai)
                .Set("NgayCapNhatCuoi", DateTime.UtcNow);

            var result = await _nguoiDungCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        // ✅ Cập nhật đơn hàng sang hoàn thành
        public async Task<bool> HoanThanhDonHangAsync(ObjectId idDonHang)
        {
            var update = Builders<DonHang_DTO>.Update
                .Set(d => d.TrangThai, "Hoàn thành")
                .Set(d => d.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(d => d.Id == idDonHang, update);
            return result.ModifiedCount > 0;
        }

        // 📦 Lấy danh sách đơn hàng cần phân công (trạng thái “Đang xử lý”)
        public async Task<List<DonHang_DTO>> LayDonHangDangXuLyAsync()
        {
            var filter = Builders<DonHang_DTO>.Filter.Eq(d => d.TrangThai, "Đang xử lý");
            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // 🧑‍🏭 Lấy danh sách shipper hiện có
        public async Task<List<NguoiDung_DTO>> LayTatCaShipperAsync()
        {
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.LoaiNguoiDung, "NhanVien"),
                Builders<NguoiDung_DTO>.Filter.Eq(nd => nd.ChucVu, "Shipper")
            );
            return await _nguoiDungCollection.Find(filter).ToListAsync();
        }

        // 🚀 Phân công đơn hàng cho shipper (phiên bản tối ưu)
        public async Task<bool> PhanCongDonHangTheoShipperAsync(ObjectId donHangId, ObjectId shipperId)
        {
            var shipper = await _nguoiDungCollection.Find(nd => nd.Id == shipperId).FirstOrDefaultAsync();
            if (shipper == null) return false;

            // Cập nhật đơn hàng
            var updateDonHang = Builders<DonHang_DTO>.Update
                .Set(d => d.IdNguoiPhuTrach, shipper.Id)
                .Set(d => d.NguoiPhuTrachTen, shipper.HoTen ?? "")
                .Set(d => d.TrangThai, "Đang giao")
                .Set(d => d.NgayCapNhatCuoi, DateTime.UtcNow);

            var resultDonHang = await _donHangCollection.UpdateOneAsync(d => d.Id == donHangId, updateDonHang);
            if (resultDonHang.ModifiedCount == 0) return false;

            // Cập nhật shipper
            var updateShipper = Builders<NguoiDung_DTO>.Update
                .Inc("SoLuongDonHangDangGiao", 1)
                .Set("NgayCapNhatCuoi", DateTime.UtcNow);

            var resultShipper = await _nguoiDungCollection.UpdateOneAsync(nv => nv.Id == shipperId, updateShipper);
            return resultShipper.ModifiedCount > 0;
        }
    }
}
