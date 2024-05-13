using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChatLieuAddService
    {
        Task<ChatLieuResponse> AddChatLieu(ChatLieuAddRequest? chatLieuAddRequest);
    }
}
