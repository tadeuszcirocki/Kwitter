using Kwitter.Models;
using System;


namespace Kwitter.DTOs
{
    public class CommentReadDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int LikeQuantity { get; set; }

        public DateTime? Created { get; set; }

        public virtual User User { get; set; }
        public virtual Kweet Kweet { get; set; }
    }
}