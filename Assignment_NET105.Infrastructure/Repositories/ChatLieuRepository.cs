using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Assignment_NET105.Infrastructure.DatabaseContext;

namespace Assignment_NET105.Repositories
{
    public class ChatLieuRepository : IChatLieuRepository
    {
        private readonly ApplicationDbContext _db;

        public ChatLieuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ChatLieu> AddChatLieu(ChatLieu chatLieu)
        {
            _db.ChatLieu.Add(chatLieu);
            await _db.SaveChangesAsync();
            return chatLieu;
        }

        public async Task<List<ChatLieu>> GetAllChatLieu()
        {
            return await _db.ChatLieu.ToListAsync();
        }

        public async Task<ChatLieu?> GetChatLieuByChatLieuID(Guid ChatLieuID)
        {
            return await _db.ChatLieu.FirstOrDefaultAsync(temp => temp.ID_ChatLieu == ChatLieuID);
        }

        public async Task<ChatLieu?> GetChatLieuByTenChatLieu(string TenChatLieu)
        {
            return await _db.ChatLieu.FirstOrDefaultAsync(temp => temp.TenChatLieu == TenChatLieu);
        }

        public async Task<List<ChatLieu>> GetFilterdChatLieu(Expression<Func<ChatLieu, bool>> predicate)
        {
            return await _db.ChatLieu.Where(predicate).ToListAsync();
        }

        public async Task<ChatLieu> UpdateChatLieu(ChatLieu chatLieu)
        {
            ChatLieu? matchingChatLieu = await _db.ChatLieu.FirstOrDefaultAsync(temp => temp.ID_ChatLieu == chatLieu.ID_ChatLieu);
            if (matchingChatLieu == null)
                return chatLieu;

            matchingChatLieu.TenChatLieu = chatLieu.TenChatLieu;
            matchingChatLieu.MoTa = chatLieu.MoTa;
            matchingChatLieu.TrangThai = chatLieu.TrangThai;

            int countUpdated = await _db.SaveChangesAsync();

            return matchingChatLieu;
        }
    }
}
