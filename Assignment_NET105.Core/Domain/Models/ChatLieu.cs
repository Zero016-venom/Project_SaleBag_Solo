using System.ComponentModel.DataAnnotations;

namespace Assignment_NET105.Core.Domain.Models
{
    public class ChatLieu
    {
        [Key]
        public Guid ID_ChatLieu { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên chất liệu từ 3 đến 50 ký tự")]
        public string? TenChatLieu { get; set; }

        [StringLength(100, ErrorMessage = "Mô tả dưới 100 ký tự")]
        public string? MoTa { get; set; }

        [StringLength(50)]
        public string? TrangThai { get; set; }

        public virtual ICollection<SanPham>? SanPhams { get; set; }
    }
}