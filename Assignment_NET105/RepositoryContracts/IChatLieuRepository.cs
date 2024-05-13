using Assignment_NET105.Core.Domain.Models;
using System.Linq.Expressions;

namespace Assignment_NET105.RepositoryContracts
{
    public interface IChatLieuRepository
    {
        Task<ChatLieu> AddChatLieu(ChatLieu chatLieu);

        Task<ChatLieu> UpdateChatLieu(ChatLieu chatLieu);

        Task<List<ChatLieu>> GetAllChatLieu();

        Task<ChatLieu?> GetChatLieuByChatLieuID(Guid ChatLieuID);

        Task<ChatLieu?> GetChatLieuByTenChatLieu(string TenChatLieu);

        Task<List<ChatLieu>> GetFilterdChatLieu(Expression<Func<ChatLieu, bool>> predicate);
    }
}
