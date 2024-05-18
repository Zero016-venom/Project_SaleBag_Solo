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
    public class HangUpdateRequest
    {
        [Required(ErrorMessage = "ID Hãng không đươc để trống !")]
        public Guid ID_Hang { get; set; }

        [Required(ErrorMessage = "Tên hãng không được để trống !")]
        public string? TenHang { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public Hang ToHang()
        {
            return new Hang()
            {
                ID_Hang = ID_Hang,
                TenHang = TenHang,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
