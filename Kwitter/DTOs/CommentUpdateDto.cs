using System.ComponentModel.DataAnnotations;

namespace Kwitter.DTOs
{
    public class CommentUpdateDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int KweetId { get; set; }
    }
}
