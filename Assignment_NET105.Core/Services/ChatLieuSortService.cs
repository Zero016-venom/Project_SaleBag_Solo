using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.RepositoryContracts;
using Assignment_NET105.ServiceContracts;

namespace Assignment_NET105.Services
{
    public class ChatLieuSortService : IChatLieuSortService
    {
        private readonly IChatLieuRepository _chatLieuRepository;

        public ChatLieuSortService(IChatLieuRepository chatLieuRepository)
        {
            _chatLieuRepository = chatLieuRepository;
        }

        public async Task<List<ChatLieuResponse>> GetSortChatLieus(List<ChatLieuResponse> allChatLieus, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allChatLieus;

            List<ChatLieuResponse> sortedChatLieus = (sortBy, sortOrder) switch
            {
                (nameof(ChatLieuResponse.TenChatLieu), SortOrderOptions.ASC)
                    => allChatLieus.OrderBy(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChatLieuResponse.TenChatLieu), SortOrderOptions.DESC)
                => allChatLieus.OrderByDescending(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChatLieuResponse.MoTa), SortOrderOptions.ASC)
                    => allChatLieus.OrderBy(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChatLieuResponse.MoTa), SortOrderOptions.DESC)
                => allChatLieus.OrderByDescending(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChatLieuResponse.TrangThai), SortOrderOptions.ASC)
                    => allChatLieus.OrderBy(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(ChatLieuResponse.TrangThai), SortOrderOptions.DESC)
                => allChatLieus.OrderByDescending(temp => temp.TenChatLieu, StringComparer.OrdinalIgnoreCase).ToList(),

                _ => allChatLieus
            };

            return sortedChatLieus;
        }
    }
}
