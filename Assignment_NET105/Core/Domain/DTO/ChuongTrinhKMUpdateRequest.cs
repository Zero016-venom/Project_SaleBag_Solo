using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChuongTrinhKMUpdateRequest
    {
        [Required(ErrorMessage = "ID chương trình khuyến mãi không được để trống !")]
        public Guid ID_ChuongTrinhKhuyenMai { get; set; }

        [Required(ErrorMessage = "Tên chương trình khuyến mãi không được để trống !")]
        public string? TenChuongTrinhKhuyenMai { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống !")]
        public DateTime NgayBatDau { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống !")]
        public DateTime NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Hãy chọn sản phẩm áp dụng khuyến mãi")]
        public Guid? ID_SanPham { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }


        public ChuongTrinhKhuyenMai ToChuongTrinhKhuyenMai()
        {
            return new ChuongTrinhKhuyenMai()
            {
                ID_ChuongTrinhKhuyenMai = ID_ChuongTrinhKhuyenMai,
                TenChuongTrinhKhuyenMai = TenChuongTrinhKhuyenMai,
                NgayBatDau = NgayBatDau,
                NgayKetThuc = NgayKetThuc,
                ID_SanPham = ID_SanPham,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
