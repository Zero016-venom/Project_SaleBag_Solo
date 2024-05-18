using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.DTO;

namespace Assignment_NET105.Core.ServiceContracts
{
    public interface IHangSortService
    {
        Task<List<HangResponse>> GetSortHangs(List<HangResponse> allHangs, 
            string sortBy, SortOrderOptions sortOrder);
    }
}
