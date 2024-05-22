using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class ChuongTrinhKhuyenMaiSortService : IChuongTrinhKhuyenMaiSortService
    {
        private readonly IChuongTrinhKhuyenMaiRepository _chuongTrinhKhuyenMaiRepository;

        public ChuongTrinhKhuyenMaiSortService(IChuongTrinhKhuyenMaiRepository chuongTrinhKhuyenMaiRepository)
        {
            _chuongTrinhKhuyenMaiRepository = chuongTrinhKhuyenMaiRepository;
        }

        public async Task<List<ChuongTrinhKhuyenMaiResponse>> GetSortChuongTrinhKhuyenMai(List<ChuongTrinhKhuyenMaiResponse> allChuongTrinhKhuyenMais, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allChuongTrinhKhuyenMais;

            List<ChuongTrinhKhuyenMaiResponse> sortedChuongTrinhKhuyenMais = (sortBy, sortOrder) switch
            {
                (nameof(ChuongTrinhKhuyenMaiResponse.TenChuongTrinhKhuyenMai), SortOrderOptions.ASC)
                => allChuongTrinhKhuyenMais.OrderBy(temp => temp.TenChuongTrinhKhuyenMai, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(ChuongTrinhKhuyenMaiResponse.TenChuongTrinhKhuyenMai), SortOrderOptions.DESC)
                => allChuongTrinhKhuyenMais.OrderByDescending(temp => temp.TenChuongTrinhKhuyenMai, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChuongTrinhKhuyenMaiResponse.TrangThai), SortOrderOptions.ASC)
                => allChuongTrinhKhuyenMais.OrderBy(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(ChuongTrinhKhuyenMaiResponse.TrangThai), SortOrderOptions.DESC)
                => allChuongTrinhKhuyenMais.OrderByDescending(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChuongTrinhKhuyenMaiResponse.NgayBatDau), SortOrderOptions.ASC)
                => allChuongTrinhKhuyenMais.OrderBy(temp => temp.NgayBatDau.ToShortDateString(), StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(ChuongTrinhKhuyenMaiResponse.NgayBatDau), SortOrderOptions.DESC)
                => allChuongTrinhKhuyenMais.OrderByDescending(temp => temp.NgayBatDau.ToShortDateString(), StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChuongTrinhKhuyenMaiResponse.NgayKetThuc), SortOrderOptions.ASC)
                => allChuongTrinhKhuyenMais.OrderBy(temp => temp.NgayKetThuc.ToShortDateString(), StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(ChuongTrinhKhuyenMaiResponse.NgayKetThuc), SortOrderOptions.DESC)
                => allChuongTrinhKhuyenMais.OrderByDescending(temp => temp.NgayKetThuc.ToShortDateString(), StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChuongTrinhKhuyenMaiResponse.ID_SanPham), SortOrderOptions.ASC)
                => allChuongTrinhKhuyenMais.OrderBy(temp => temp.ID_SanPham.ToString(), StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(ChuongTrinhKhuyenMaiResponse.ID_SanPham), SortOrderOptions.DESC)
                => allChuongTrinhKhuyenMais.OrderByDescending(temp => temp.ID_SanPham.ToString(), StringComparer.OrdinalIgnoreCase).ToList(),
                _ => allChuongTrinhKhuyenMais
            };
            return sortedChuongTrinhKhuyenMais;
        }
    }
}
