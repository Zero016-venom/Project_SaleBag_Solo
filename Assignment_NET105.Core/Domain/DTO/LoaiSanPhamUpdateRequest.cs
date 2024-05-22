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
    public class LoaiSanPhamUpdateRequest
    {
        [Required(ErrorMessage = "ID loại sản phẩm không được để trống !")]
        public Guid ID_LoaiSP { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống !")]
        public string? TenLoaiSP { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Phải chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public LoaiSP ToLoaiSP()
        {
            return new LoaiSP()
            {
                ID_LoaiSP = ID_LoaiSP,
                TenLoaiSP = TenLoaiSP,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
