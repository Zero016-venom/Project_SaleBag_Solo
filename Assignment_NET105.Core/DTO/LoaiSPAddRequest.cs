using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.DTO
{
    public class LoaiSPAddRequest
    {
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống !")]
        public string? TenLoaiSP { get; set; }

        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public LoaiSP ToLoaiSP()
        {
            return new LoaiSP()
            {
                TenLoaiSP = TenLoaiSP,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
