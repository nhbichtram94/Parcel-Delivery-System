using DAL;
using DTO;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class Shipper_BLL
    {
        private readonly NhanVien_DAL _shipperDAL = new NhanVien_DAL();

        // Lấy danh sách đơn hàng cho shipper
        public Task<List<DonHang_DTO>> LayDonHangCuaShipperAsync(ObjectId shipperId)
        {
            return _shipperDAL.LayDonHangTheoShipperAsync(shipperId);
        }
        // Hoàn thành đơn hàng (update đơn + giảm số lượng)
        public async Task<bool> HoanThanhDonHangAsync(ObjectId donHangId, ObjectId shipperId)
        {
            var donHangUpdated = await _shipperDAL.HoanThanhDonHangAsync(donHangId);
            var shipperUpdated = await _shipperDAL.CapNhatSoLuongDonHangNhanVienAsync(shipperId);
            return donHangUpdated && shipperUpdated;
        }

    }
}
