using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChatLieuUpdateService
    {
        Task<ChatLieuResponse> UpdateChatLieu(ChatLieuUpdateRequest? chatLieuUpdateRequest);
    }
}
