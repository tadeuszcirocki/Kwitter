using System.ComponentModel.DataAnnotations;

namespace Kwitter.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public char Permissions { get; set; }   //seems edgy
        [MaxLength(500)]
        public string Bio { get; set; }
    }
}
