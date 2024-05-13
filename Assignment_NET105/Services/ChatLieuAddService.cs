using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Repositories;
using Assignment_NET105.RepositoryContracts;
using Assignment_NET105.ServiceContracts;

namespace Assignment_NET105.Services
{
    public class ChatLieuAddService : IChatLieuAddService
    {
        private readonly IChatLieuRepository _chatLieuRepository;

        public ChatLieuAddService(IChatLieuRepository chatLieuRepository)
        {
            _chatLieuRepository = chatLieuRepository;
        }

        public async Task<ChatLieuResponse> AddChatLieu(ChatLieuAddRequest? chatLieuAddRequest)
        {
            //Validation: chatLieuAddRequest ko được null
            if(chatLieuAddRequest == null) 
                throw new ArgumentNullException(nameof(chatLieuAddRequest));

            //Validation: Tên chất liệu ko được null
            if(chatLieuAddRequest.TenChatLieu == null)
                throw new ArgumentNullException(nameof(chatLieuAddRequest.TenChatLieu));

            //Validation: Tên chất liệu ko được trùng
            if(await _chatLieuRepository.GetChatLieuByTenChatLieu(chatLieuAddRequest.TenChatLieu) != null)
            {
                throw new ArgumentException("Tên chất liệu đã tồn tại !");
            }

            ChatLieu chatLieu = chatLieuAddRequest.ToChatLieu();

            chatLieu.ID_ChatLieu = Guid.NewGuid();

            await _chatLieuRepository.AddChatLieu(chatLieu);

            return chatLieu.ToChatLieuResponse();
        }
    }
}
