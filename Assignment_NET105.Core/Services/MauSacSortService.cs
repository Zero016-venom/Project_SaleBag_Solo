using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Core.ServiceContracts;

namespace Assignment_NET105.Core.Services
{
    public class MauSacSortService : IMauSacSortService
    {
        private readonly IMauSacRepository _mauSacRepository;

        public MauSacSortService(IMauSacRepository mauSacRepository)
        {
            _mauSacRepository = mauSacRepository;
        }

        public async Task<List<MauSacResponse>> GetSortMauSac(List<MauSacResponse> allMauSac, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allMauSac;


            List<MauSacResponse> sortMauSac = (sortBy, sortOrder) switch
            {
                (nameof(MauSacResponse.TenMauSac), SortOrderOptions.ASC)
                => allMauSac.OrderBy(temp => temp.TenMauSac, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(MauSacResponse.TenMauSac), SortOrderOptions.DESC)
                => allMauSac.OrderByDescending(temp => temp.TenMauSac, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(MauSacResponse.MoTa), SortOrderOptions.ASC)
                => allMauSac.OrderBy(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(MauSacResponse.MoTa), SortOrderOptions.DESC)
                => allMauSac.OrderByDescending(temp => temp.MoTa, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(MauSacResponse.TrangThai), SortOrderOptions.ASC)
                => allMauSac.OrderBy(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(MauSacResponse.TrangThai), SortOrderOptions.DESC)
                => allMauSac.OrderByDescending(temp => temp.TrangThai, StringComparer.OrdinalIgnoreCase).ToList(),
                _ => allMauSac
            };
            return sortMauSac;
        }
    }
}
