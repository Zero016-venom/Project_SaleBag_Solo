using Assignment_NET105.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChuongTrinhKMResponse
    {
        public Guid ID_ChuongTrinhKhuyenMai { get; set; }
        public string? TenChuongTrinhKhuyenMai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? TrangThai { get; set; }
        public Guid? ID_SanPham { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;

            if(obj.ToString() != this.ToString()) return false;

            ChuongTrinhKMResponse chuongTrinhKM = (ChuongTrinhKMResponse)obj;

            return ID_ChuongTrinhKhuyenMai == chuongTrinhKM.ID_ChuongTrinhKhuyenMai
                && TenChuongTrinhKhuyenMai == chuongTrinhKM.TenChuongTrinhKhuyenMai
                && NgayBatDau == chuongTrinhKM.NgayBatDau
                && NgayKetThuc == chuongTrinhKM.NgayKetThuc
                && ID_SanPham == chuongTrinhKM.ID_SanPham
                && TrangThai == chuongTrinhKM.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ChuongTrinhKMUpdateRequest ToChuongTrinhKMUpdateRequest()
        {
            return new ChuongTrinhKMUpdateRequest()
            {
                ID_ChuongTrinhKhuyenMai = ID_ChuongTrinhKhuyenMai,
                TenChuongTrinhKhuyenMai = TenChuongTrinhKhuyenMai,
                NgayBatDau = NgayBatDau,
                NgayKetThuc = NgayKetThuc,
                ID_SanPham = ID_SanPham,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }
}
