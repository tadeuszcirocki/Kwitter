using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kwitter.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int LikeQuantity { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("KweetId")]
        public Kweet Kweet { get; set; }
        public int KweetId { get; set; }
    }
}