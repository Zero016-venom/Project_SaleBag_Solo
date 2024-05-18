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
    public class PTTTResponse
    {
        public Guid ID_PTTT { get; set; }
        public string? TenPTTT { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;

            if (obj.GetType() != typeof(PTTTResponse)) return false;

            PTTTResponse pttt = (PTTTResponse)obj;

            return ID_PTTT == pttt.ID_PTTT && TenPTTT == pttt.TenPTTT
                && MoTa == pttt.MoTa && TrangThai == pttt.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public PTTTUpdateRequest ToPTTTUpdateRequest()
        {
            return new PTTTUpdateRequest()
            {
                ID_PTTT = ID_PTTT,
                TenPTTT = TenPTTT,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }

    public static class PTTTExtensions
    {
        public static PTTTResponse ToPTTTResponse(this PTTT pttt)
        {
            return new PTTTResponse()
            {
                ID_PTTT = pttt.ID_PTTT,
                TenPTTT = pttt.TenPTTT,
                MoTa = pttt.MoTa,
                TrangThai = pttt.TrangThai,
            };
        }
    }
}
