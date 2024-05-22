using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChuongTrinhKhuyenMaiUpdateRequest
    {
        [Required]
        public Guid ID_ChuongTrinhKhuyenMai { get; set; }

        [Required(ErrorMessage = "Tên chương trình khuyến mãi không được để trống !")]
        public string? TenChuongTrinhKhuyenMai { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống !")]
        public DateTime NgayBatDau { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống !")]
        public DateTime NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Trạng thái phải chọn !")]
        public StatusOptions? TrangThai { get; set; }

        [Required(ErrorMessage = "Phải chọn sản phẩm áp dụng !")]
        public Guid? ID_SanPham { get; set; }

        public ChuongTrinhKhuyenMai ToChuongTrinhKhuyenMai()
        {
            return new ChuongTrinhKhuyenMai()
            {
                ID_ChuongTrinhKhuyenMai = ID_ChuongTrinhKhuyenMai,
                TenChuongTrinhKhuyenMai = TenChuongTrinhKhuyenMai,
                NgayBatDau = NgayBatDau,
                NgayKetThuc = NgayKetThuc,
                TrangThai = TrangThai.ToString(),
                ID_SanPham = ID_SanPham
            };
        }
    }
}
