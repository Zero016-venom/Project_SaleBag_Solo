using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.DTO;
using Assignment_NET105.Core.ServiceContracts;
using Assignment_NET105.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Services
{
    public class HangSortService : IHangSortService
    {
        private readonly IHangRepository _hangRepository;

        public HangSortService(IHangRepository hangRepository)
        {
            _hangRepository = hangRepository;
        }

        public async Task<List<HangResponse>> GetSortHangs(List<HangResponse> allHangs, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allHangs;

            List<HangResponse> sortedHangs = (sortBy, sortOrder) switch
            {
                (nameof(HangResponse.TenHang), SortOrderOptions.ASC)
                => allHangs.OrderBy(temp => temp.TenHang, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(HangResponse.TenHang), SortOrderOptions.DESC)
                => allHangs.OrderByDescending(temp => temp.TenHang, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(HangResponse.MoTa), SortOrderOptions.ASC)
                => allHangs.OrderBy(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(HangResponse.MoTa), SortOrderOptions.DESC)
                => allHangs.OrderByDescending(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(HangResponse.TrangThai), SortOrderOptions.ASC)
                => allHangs.OrderBy(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(HangResponse.TrangThai), SortOrderOptions.DESC)
                => allHangs.OrderByDescending(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                _ => allHangs
            };
            return sortedHangs;
        }
    }
}
