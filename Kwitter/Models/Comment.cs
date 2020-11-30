﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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

        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Kweet Kweet { get; set; }
        public int KweetId { get; set; }
    }
}