using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChatLieuSortService
    {
        Task<List<ChatLieuResponse>> GetSortChatLieus(List<ChatLieuResponse> allChatLieus, string sortBy, SortOrderOptions sortOrder);
    }
}
