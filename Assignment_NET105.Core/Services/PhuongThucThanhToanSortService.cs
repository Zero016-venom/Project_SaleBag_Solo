using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class PhuongThucThanhToanSortService : IPhuongThucThanhToanSortService
    {
        private readonly IPhuongThucThanhToanRepository _phuongThucThanhToanRepository;

        public PhuongThucThanhToanSortService(IPhuongThucThanhToanRepository phuongThucThanhToanRepository)
        {
            _phuongThucThanhToanRepository = phuongThucThanhToanRepository;
        }

        public async Task<List<PhuongThucThanhToanResponse>> GetSortPhuongThucThanhToan(List<PhuongThucThanhToanResponse> allPhuongThucThanhToan, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allPhuongThucThanhToan;

            List<PhuongThucThanhToanResponse> sortPhuongThucThanhToan;
            sortPhuongThucThanhToan = (sortBy, sortOrder) switch
            {
                (nameof(PhuongThucThanhToanResponse.TenPTTT), SortOrderOptions.ASC)
                => allPhuongThucThanhToan.OrderBy(temp => temp.TenPTTT, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PhuongThucThanhToanResponse.TenPTTT), SortOrderOptions.DESC)
                => allPhuongThucThanhToan.OrderByDescending(temp => temp.TenPTTT, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PhuongThucThanhToanResponse.MoTa), SortOrderOptions.ASC)
                => allPhuongThucThanhToan.OrderBy(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PhuongThucThanhToanResponse.MoTa), SortOrderOptions.DESC)
                => allPhuongThucThanhToan.OrderByDescending(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PhuongThucThanhToanResponse.TrangThai), SortOrderOptions.ASC)
                => allPhuongThucThanhToan.OrderBy(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(PhuongThucThanhToanResponse.TrangThai), SortOrderOptions.DESC)
                => allPhuongThucThanhToan.OrderByDescending(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                _ => allPhuongThucThanhToan
            };
            return sortPhuongThucThanhToan;
        }
    }
}
