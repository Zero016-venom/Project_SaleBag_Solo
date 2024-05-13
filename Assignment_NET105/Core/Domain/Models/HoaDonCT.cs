﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_NET105.Core.Domain.Models
{
    public class HoaDonCT
    {
        [Key]
        public Guid ID_HoaDonCT { get; set; }
        public Guid? ID_SanPham { get; set; }
        public Guid? ID_HoaDon { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }

        [ForeignKey("ID_SanPham")]
        public virtual SanPham? SanPham { get; set; }

        [ForeignKey("ID_HoaDon")]
        public virtual HoaDon? HoaDons { get; set; }
    }
}
