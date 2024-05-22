using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChatLieuUpdateRequest
    {
        [Required(ErrorMessage = "ID chất liệu không được để trống !")]
        public Guid ID_ChatLieu { get; set; }

        [Required(ErrorMessage = "Tên chất liệu không được để trống !")]
        public string? TenChatLieu { get; set; }
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống !")]
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
