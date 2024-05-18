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
    public class MauSacUpdateRequest
    {
        [Required]
        public Guid ID_MauSac { get; set; }

        [Required(ErrorMessage = "Tên màu không được để trống !")]
        public string? TenMauSac { get; set; }

        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public MauSac ToMauSac()
        {
            return new MauSac()
            {
                TenMauSac = TenMauSac,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
