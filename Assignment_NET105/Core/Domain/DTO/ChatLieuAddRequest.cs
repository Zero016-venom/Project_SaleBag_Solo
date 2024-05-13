using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment_NET105.Core.Domain.DTO
{
    /// <summary>
    /// DTO class để thêm 1 chất liệu mới
    /// </summary>
    public class ChatLieuAddRequest
    {
        [Required(ErrorMessage = "Tên chất liệu không được để trống !")]
        public string? TenChatLieu { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái !")]
        public StatusOptions? TrangThai { get; set; }

        public ChatLieu ToChatLieu()
        {
            return new ChatLieu()
            {
                TenChatLieu = TenChatLieu,
                MoTa = MoTa,
                TrangThai = TrangThai.ToString()
            };
        }

    }
}
