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
    public class LoaiSanPhamSortService : ILoaiSanPhamSortService
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;

        public LoaiSanPhamSortService(ILoaiSanPhamRepository loaiSanPhamRepository)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
        }

        public async Task<List<LoaiSanPhamResponse>> GetSortLoaiSanPham(List<LoaiSanPhamResponse> allLoaiSanPham, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allLoaiSanPham;

            List<LoaiSanPhamResponse> sortLoaiSanPham = (sortBy, sortOrder) switch
            {
                (nameof(LoaiSanPhamResponse.TenLoaiSP), SortOrderOptions.ASC)
                => allLoaiSanPham.OrderBy(temp => temp.TenLoaiSP, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(LoaiSanPhamResponse.TenLoaiSP), SortOrderOptions.DESC)
                => allLoaiSanPham.OrderByDescending(temp => temp.TenLoaiSP, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(LoaiSanPhamResponse.MoTa), SortOrderOptions.ASC)
                => allLoaiSanPham.OrderBy(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(LoaiSanPhamResponse.MoTa), SortOrderOptions.DESC)
                => allLoaiSanPham.OrderByDescending(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(LoaiSanPhamResponse.TrangThai), SortOrderOptions.ASC)
                => allLoaiSanPham.OrderBy(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(LoaiSanPhamResponse.TrangThai), SortOrderOptions.DESC)
                => allLoaiSanPham.OrderByDescending(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                _ => allLoaiSanPham
            };
            return sortLoaiSanPham;
        }
    }
}
