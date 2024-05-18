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
    public class LoaiSPResponse
    {
        public Guid ID_LoaiSP { get; set; }
        public string? TenLoaiSP { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null)
                return false;
            if(obj.GetType () != typeof(LoaiSPResponse)) 
                return false;
            LoaiSPResponse loaiSP = (LoaiSPResponse)obj;

            return ID_LoaiSP == loaiSP.ID_LoaiSP
                && TenLoaiSP == loaiSP.TenLoaiSP
                && MoTa == loaiSP.MoTa
                && TrangThai == loaiSP.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public LoaiSPUpdateRequest ToLoaiSPUpdateRequest()
        {
            return new LoaiSPUpdateRequest()
            {
                ID_LoaiSP = ID_LoaiSP,
                TenLoaiSP = TenLoaiSP,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }

    public static class LoaiSPExtentions
    {
        public static LoaiSPResponse ToLoaiSPResponse (this LoaiSP loaiSP)
        {
            return new LoaiSPResponse()
            {
                ID_LoaiSP = loaiSP.ID_LoaiSP,
                TenLoaiSP = loaiSP.TenLoaiSP,
                MoTa = loaiSP.MoTa,
                TrangThai = loaiSP.TrangThai
            };
        }
    }
}
