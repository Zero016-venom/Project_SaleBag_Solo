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
    public class PTTTAddRequest
    {
        [Required(ErrorMessage = "Tên phương thức thanh toán không được để trống !")]
        public string? TenPTTT { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public PTTT ToPttt()
        {
            return new PTTT()
            {
                TenPTTT = TenPTTT,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
