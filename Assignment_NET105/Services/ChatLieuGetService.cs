using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.RepositoryContracts;
using Assignment_NET105.ServiceContracts;
using Azure;

namespace Assignment_NET105.Services
{
    public class ChatLieuGetService : IChatLieuGetService
    {
        private readonly IChatLieuRepository _chatLieuRepository;

        public ChatLieuGetService(IChatLieuRepository chatLieuRepository)
        {
            _chatLieuRepository = chatLieuRepository;
        }

        public virtual async Task<List<ChatLieuResponse>> GetAllChatLieu()
        {
            List<ChatLieu> chatLieus = await _chatLieuRepository.GetAllChatLieu();

            return chatLieus.Select(temp => temp.ToChatLieuResponse()).ToList();
        }

        public virtual async Task<ChatLieuResponse?> GetChatLieuByChatLieuID(Guid? chatLieuID)
        {
            if (chatLieuID == null)
                return null;

            ChatLieu? chatLieu = await _chatLieuRepository.GetChatLieuByChatLieuID(chatLieuID.Value);

            if (chatLieu == null)
                return null;

            return chatLieu.ToChatLieuResponse();
        }

        public virtual async Task<List<ChatLieuResponse>> GetFilteredChatLieus(string searchBy, string? searchString)
        {
            List<ChatLieu> chatLieus;

            chatLieus = searchBy switch
            {
                nameof(ChatLieuResponse.TenChatLieu) =>
                await _chatLieuRepository.GetFilterdChatLieu(temp => temp.TenChatLieu.Contains(searchString)),

                nameof(ChatLieuResponse.MoTa) =>
                await _chatLieuRepository.GetFilterdChatLieu(temp => temp.MoTa.Contains(searchString)),

                nameof(ChatLieuResponse.TrangThai) =>
                await _chatLieuRepository.GetFilterdChatLieu(temp => temp.TrangThai.Contains(searchString)),

                _ => await _chatLieuRepository.GetAllChatLieu()
            };

            return chatLieus.Select(temp => temp.ToChatLieuResponse()).ToList();
        }
    }
}
