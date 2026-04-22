using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DTO
{
    // Enum trạng thái đơn hàng
    public enum TrangThaiDonHang
    {
        ChoXacNhan,   // "Chờ xác nhận"
        MoiTao,       // "Mới tạo"
        ChoXuLy,      // "Chờ xử lý"
        DangXuLy,     // "Đang xử lý"
        DangGiao,     // "Đang giao"
        DaGiao,       // "Đã giao"
        DaHuy         // "Đã hủy"
    }
}
