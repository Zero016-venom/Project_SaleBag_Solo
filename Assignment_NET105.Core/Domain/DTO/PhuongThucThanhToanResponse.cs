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
    public class PhuongThucThanhToanResponse
    {
        public Guid ID_PTTT { get; set; }
        public string? TenPTTT { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(PhuongThucThanhToanResponse)) return false;
            PhuongThucThanhToanResponse phuongThucThanhToan = (PhuongThucThanhToanResponse)obj;

            return ID_PTTT == phuongThucThanhToan.ID_PTTT && TenPTTT == phuongThucThanhToan.TenPTTT
                && MoTa == phuongThucThanhToan.MoTa && TrangThai == phuongThucThanhToan.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public PhuongThucThanhToanUpdateRequest ToPhuongThucThanhToanUpdateRequest()
        {
            return new PhuongThucThanhToanUpdateRequest()
            {
                ID_PhuongThucThanhToan = ID_PTTT,
                TenPTTT = TenPTTT,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai)
            };
        }
    }

    public static class PhuongThucThanhToanExtensions
    {
        public static PhuongThucThanhToanResponse ToPhuongThucThanhToanResponse(this PTTT phuongThucThanhToan)
        {
            return new PhuongThucThanhToanResponse()
            {
                ID_PTTT = phuongThucThanhToan.ID_PTTT,
                TenPTTT = phuongThucThanhToan.TenPTTT,
                MoTa = phuongThucThanhToan.MoTa,
                TrangThai = phuongThucThanhToan.TrangThai.ToString()
            };
        }
    }
}
