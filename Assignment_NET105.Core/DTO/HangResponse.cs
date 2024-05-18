using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.DTO
{
    public class HangResponse
    {
        public Guid ID_Hang { get; set; }
        public string? TenHang { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(HangResponse)) return false;

            HangResponse hang = (HangResponse)obj;

            return ID_Hang == hang.ID_Hang
                && TenHang == hang.TenHang
                && MoTa == hang.MoTa
                && TrangThai == hang.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public HangUpdateRequest ToHangUpdateRequest()
        {
            return new HangUpdateRequest()
            {
                ID_Hang = ID_Hang,
                TenHang = TenHang,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }

    public static class HangExtensions
    {
        public static HangResponse ToHangResponse(this Hang hang)
        {
            return new HangResponse()
            {
                ID_Hang = hang.ID_Hang,
                TenHang = hang.TenHang,
                MoTa = hang.MoTa,
                TrangThai = hang.TrangThai
            };
        }
    }
}
