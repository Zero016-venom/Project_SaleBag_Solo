using Assignment_NET105.Core.Domain.Enums;
using Assignment_NET105.Core.Domain.Models;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class ChatLieuResponse
    {
        public Guid ID_ChatLieu { get; set; }
        public string? TenChatLieu { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;

            if (obj.GetType() != typeof(ChatLieuResponse)) return false;

            ChatLieuResponse chatLieu = (ChatLieuResponse)obj;

            return ID_ChatLieu == chatLieu.ID_ChatLieu
                && TenChatLieu == chatLieu.TenChatLieu
                && MoTa == chatLieu.MoTa
                && TrangThai == chatLieu.TrangThai;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ChatLieuUpdateRequest ToChatLieuUpdateRequest()
        {
            return new ChatLieuUpdateRequest()
            {
                ID_ChatLieu = ID_ChatLieu,
                TenChatLieu = TenChatLieu,
                MoTa = MoTa,
                TrangThai = (StatusOptions)Enum.Parse(typeof(StatusOptions), TrangThai, true)
            };
        }
    }

    public static class ChatLieuExtensions
    {
        public static ChatLieuResponse ToChatLieuResponse(this ChatLieu chatLieu)
        {
            return new ChatLieuResponse ()
            {
                ID_ChatLieu = chatLieu.ID_ChatLieu,
                TenChatLieu = chatLieu.TenChatLieu,
                MoTa = chatLieu.MoTa,
                TrangThai = chatLieu.TrangThai
            };
        }
    }
}
