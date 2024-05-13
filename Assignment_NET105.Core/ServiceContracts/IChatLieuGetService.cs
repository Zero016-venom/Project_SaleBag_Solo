using Assignment_NET105.Core.Domain.DTO;

namespace Assignment_NET105.ServiceContracts
{
    public interface IChatLieuGetService
    {
        Task<List<ChatLieuResponse>> GetAllChatLieu();

        Task<ChatLieuResponse?> GetChatLieuByChatLieuID(Guid? chatLieuID);

        Task<List<ChatLieuResponse>> GetFilteredChatLieus(string searchBy, string? searchString);
    }
}
