using Assignment_NET105.Core.Domain.DTO;
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Core.ServiceContracts;
using Assignment_NET105.RepositoryContracts;
using Assignment_NET105.ServiceContracts;

namespace Assignment_NET105.Services
{
    public class ChatLieuUpdateService : IChatLieuUpdateService
    {
        private readonly IChatLieuRepository _chatLieuRepository;

        public ChatLieuUpdateService(IChatLieuRepository chatLieuRepository)
        {
            _chatLieuRepository = chatLieuRepository;
        }

        public async Task<ChatLieuResponse> UpdateChatLieu(ChatLieuUpdateRequest? chatLieuUpdateRequest)
        {
            if(chatLieuUpdateRequest == null)
                throw new ArgumentNullException(nameof(chatLieuUpdateRequest));

            //Validation
            //ValidationHelper.ModelValidation(chatLieuUpdateRequest);

            //Tìm chat liệu hợp lệ để cập nhật
            ChatLieu? matchingChatLieu = await _chatLieuRepository.GetChatLieuByChatLieuID(chatLieuUpdateRequest.ID_ChatLieu);
            if (matchingChatLieu == null)
                throw new ArgumentException("ID Chất liệu không tồn tại");

            matchingChatLieu.TenChatLieu = chatLieuUpdateRequest.TenChatLieu;
            matchingChatLieu.MoTa = chatLieuUpdateRequest.MoTa;
            matchingChatLieu.TrangThai = chatLieuUpdateRequest.TrangThai.ToString();

            await _chatLieuRepository.UpdateChatLieu(matchingChatLieu);
            return matchingChatLieu.ToChatLieuResponse();
        }
    }
}
