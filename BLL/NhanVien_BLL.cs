using DAL;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class NhanVien_BLL
    {
        private readonly NhanVien_DAL _dal = new NhanVien_DAL();

        /// 🔍 Lấy nhân viên theo IdNguoiDung
        public async Task<NguoiDung_DTO> LayTheoIdNguoiDungAsync(string idNguoiDung)
        {
            if (string.IsNullOrWhiteSpace(idNguoiDung))
                return null;

            if (!ObjectId.TryParse(idNguoiDung, out ObjectId objId))
                return null;

            var filter = Builders<NguoiDung_DTO>.Filter.Eq(x => x.Id, objId);
            var list = await _dal.GetByFilterAsync(filter);
            return list.FirstOrDefault();
        }

        /// 🔄 Cập nhật thông tin nhân viên
        public async Task<bool> CapNhatNhanVienAsync(NguoiDung_DTO nv)
        {
            if (nv == null)
                throw new ArgumentException("Thông tin nhân viên không hợp lệ.");

            nv.NgayCapNhatCuoi = DateTime.UtcNow;
            return await _dal.UpdateAsync(nv);
        }

        /// ➕ Thêm nhân viên mới
        public async Task<bool> ThemNhanVienAsync(NguoiDung_DTO nv)
        {
            if (nv == null)
                throw new ArgumentException("Thông tin nhân viên không hợp lệ.");

            nv.NgayTao = nv.NgayCapNhatCuoi = DateTime.UtcNow;
            nv.LoaiNguoiDung = "NhanVien";
            await _dal.CreateAsync(nv);
            return true;
        }

        /// ❌ Xóa nhân viên
        public async Task<bool> XoaNhanVienAsync(ObjectId id)
        {
            return await _dal.DeleteAsync(id);
        }

        /// 📦 Lấy danh sách đơn hàng theo nhân viên
        public async Task<List<DonHang_DTO>> LayDonHangTheoShipperAsync(ObjectId nhanVienId)
        {
            return await _dal.LayDonHangTheoShipperAsync(nhanVienId);
        }

        /// ✅ Đánh dấu đơn hàng hoàn thành
        public async Task<bool> HoanThanhDonHangAsync(ObjectId donHangId)
        {
            return await _dal.HoanThanhDonHangAsync(donHangId);
        }
    }
}
