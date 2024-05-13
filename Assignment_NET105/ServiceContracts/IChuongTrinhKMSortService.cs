using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChuongTrinhKMSortService
    {
        Task<List<ChuongTrinhKMResponse>> GetSortChuongTrinhKM(List<ChuongTrinhKMResponse> allCTKM, string sortBy, SortOrderOptions sortOrder);
    }
}
