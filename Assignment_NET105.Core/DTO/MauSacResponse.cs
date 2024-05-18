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
    public class MauSacResponse
    {
        public Guid ID_MauSac { get; set; }
        public string? TenMauSac { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if(obj.GetType() != typeof(MauSacResponse))
                return false;
            MauSacResponse mauSac = (MauSacResponse)obj;

            return ID_MauSac == mauSac.ID_MauSac && TenMauSac == mauSac.TenMauSac
                && MoTa == mauSac.MoTa && TrangThai == mauSac.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public MauSacUpdateRequest ToMauSacUpdateRequest()
        {
            return new MauSacUpdateRequest()
            {
                ID_MauSac = ID_MauSac,
                TenMauSac = TenMauSac,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }

    public static class MauSacExtensions
    {
        public static MauSacResponse ToMauSacResponse(this MauSac mauSac)
        {
            return new MauSacResponse()
            {
                ID_MauSac = mauSac.ID_MauSac,
                TenMauSac = mauSac.TenMauSac,
                MoTa = mauSac.MoTa,
                TrangThai = mauSac.TrangThai
            };
        }
    }
}
