﻿using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class PhuongThucThanhToanAddRequest
    {
        [Required(ErrorMessage = "Tên phương thức thanh toán không được để trống !")]
        public string? TenPTTT { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Phải chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public PTTT ToPhuongThucThanhToan()
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
