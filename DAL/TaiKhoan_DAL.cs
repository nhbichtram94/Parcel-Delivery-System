using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan_DAL
    {
        private readonly IMongoCollection<NguoiDung_DTO> _nguoiDungCollection;

        public TaiKhoan_DAL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("GiaoNhanBuuPham");
            _nguoiDungCollection = database.GetCollection<NguoiDung_DTO>("NguoiDung");
        }

        // 🧾 Lấy tất cả tài khoản (người dùng)
        public async Task<List<NguoiDung_DTO>> GetAllAsync() =>
            await _nguoiDungCollection.Find(_ => true).ToListAsync();

        // ➕ Thêm người dùng mới (có cả thông tin tài khoản)
        public async Task CreateAsync(NguoiDung_DTO nd) =>
            await _nguoiDungCollection.InsertOneAsync(nd);

        // ✏️ Cập nhật thông tin người dùng
        public async Task<bool> UpdateAsync(ObjectId id, NguoiDung_DTO nd)
        {
            var filter = Builders<NguoiDung_DTO>.Filter.Eq(t => t.Id, id);
            var result = await _nguoiDungCollection.ReplaceOneAsync(filter, nd);
            return result.ModifiedCount > 0;
        }

        // ❌ Xóa tài khoản (người dùng)
        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var result = await _nguoiDungCollection.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }

        // 🔒 Đặt trạng thái khóa/mở khóa tài khoản
        public async Task<bool> SetTrangThaiAsync(ObjectId id, bool trangThai)
        {
            var update = Builders<NguoiDung_DTO>.Update
                .Set(t => t.TrangThai, trangThai)
                .Set(t => t.NgayCapNhatCuoi, DateTime.UtcNow);
            var result = await _nguoiDungCollection.UpdateOneAsync(t => t.Id == id, update);
            return result.ModifiedCount > 0;
        }

        // 🔍 Tìm theo tên đăng nhập
        public async Task<NguoiDung_DTO> GetByTenDangNhapAsync(string username)
        {
            return await _nguoiDungCollection.Find(tk => tk.TenDangNhap == username)
                                             .FirstOrDefaultAsync();
        }

        // 🔍 Tìm theo bộ lọc Mongo
        public async Task<NguoiDung_DTO> GetByFilterAsync(FilterDefinition<NguoiDung_DTO> filter)
        {
            return await _nguoiDungCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
