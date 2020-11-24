using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;


namespace Kwitter.Models
{
    public class Kweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public int LikeQuantity { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }
    }
}
