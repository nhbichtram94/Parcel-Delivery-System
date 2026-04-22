using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVien_DAL
    {
        private readonly IMongoCollection<DonHang_DTO> _donHangCollection;
        private readonly IMongoCollection<NguoiDung_DTO> _nguoiDungCollection;

        public NhanVien_DAL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");

            _donHangCollection = database.GetCollection<DonHang_DTO>("DonHang");
            _nguoiDungCollection = database.GetCollection<NguoiDung_DTO>("NguoiDung");
        }

        // 📦 Lấy danh sách đơn hàng mà nhân viên (shipper) đang phụ trách
        public async Task<List<DonHang_DTO>> LayDonHangTheoShipperAsync(ObjectId shipperId)
        {
            var filter = Builders<DonHang_DTO>.Filter.And(
                Builders<DonHang_DTO>.Filter.Eq(x => x.IdNguoiPhuTrach, shipperId),
                Builders<DonHang_DTO>.Filter.Ne(x => x.TrangThai, "Đã giao")
            );

            return await _donHangCollection.Find(filter).ToListAsync();
        }

        // ✅ Cập nhật trạng thái đơn hàng sang “Đã giao”
        public async Task<bool> HoanThanhDonHangAsync(ObjectId donHangId)
        {
            var filter = Builders<DonHang_DTO>.Filter.Eq(x => x.Id, donHangId);
            var update = Builders<DonHang_DTO>.Update
                .Set(x => x.TrangThai, "Đã giao")
                .Set(x => x.NgayCapNhatCuoi, DateTime.UtcNow);

            var result = await _donHangCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        // 📉 Giảm số lượng đơn hàng đang giao cho nhân viên (nếu bạn có trường này trong DB)
        public async Task<bool> CapNhatSoLuongDonHangNhanVienAsync(ObjectId nhanVienId)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.Id, nhanVienId),
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.LoaiNguoiDung, "NhanVien")
            );

            var update = Builders<NguoiDung_DTO>.Update
                .Inc("SoLuongDonHangDangGiao", -1)
                .Set("NgayCapNhatCuoi", DateTime.UtcNow);

            var result = await _nguoiDungCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        // 📄 Lấy danh sách nhân viên theo điều kiện filter
        public async Task<List<NguoiDung_DTO>> GetByFilterAsync(FilterDefinition<NguoiDung_DTO> filter)
        {
            var fullFilter = Builders<NguoiDung_DTO>.Filter.And(
                filter,
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.LoaiNguoiDung, "NhanVien")
            );
            return await _nguoiDungCollection.Find(fullFilter).ToListAsync();
        }

        // 📄 Lấy nhân viên theo ID
        public async Task<NguoiDung_DTO> GetByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.Id, objectId),
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.LoaiNguoiDung, "NhanVien")
            );
            return await _nguoiDungCollection.Find(filter).FirstOrDefaultAsync();
        }

        // ➕ Thêm mới nhân viên
        public async Task CreateAsync(NguoiDung_DTO nhanVien)
        {
            nhanVien.LoaiNguoiDung = "NhanVien";
            nhanVien.TrangThai = true;
            nhanVien.NgayTao = DateTime.UtcNow;
            nhanVien.NgayCapNhatCuoi = DateTime.UtcNow;

            await _nguoiDungCollection.InsertOneAsync(nhanVien);
        }

        // 🔄 Cập nhật nhân viên
        public async Task<bool> UpdateAsync(NguoiDung_DTO nhanVien)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.Id, nhanVien.Id),
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.LoaiNguoiDung, "NhanVien")
            );

            nhanVien.NgayCapNhatCuoi = DateTime.UtcNow;
            var result = await _nguoiDungCollection.ReplaceOneAsync(filter, nhanVien);
            return result.ModifiedCount > 0;
        }

        // ❌ Xóa nhân viên
        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.And(
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.Id, id),
                Builders<NguoiDung_DTO>.Filter.Eq(x => x.LoaiNguoiDung, "NhanVien")
            );
            var result = await _nguoiDungCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    }
}
