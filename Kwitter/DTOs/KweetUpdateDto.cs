using System.ComponentModel.DataAnnotations;

namespace Kwitter.DTOs
{
    public class KweetUpdateDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
