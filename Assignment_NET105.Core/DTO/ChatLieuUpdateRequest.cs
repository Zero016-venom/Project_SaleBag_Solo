using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChatLieuUpdateRequest
    {
        [Required(ErrorMessage = "ID Chất liệu không được để trống !")]
        public Guid ID_ChatLieu { get; set; }

        [Required(ErrorMessage = "Tên chất liệu không được để trống !")]
        public string? TenChatLieu { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public ChatLieu ToChatLieu()
        {
            return new ChatLieu()
            {
                ID_ChatLieu = ID_ChatLieu,
                TenChatLieu = TenChatLieu,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }
    }
}
