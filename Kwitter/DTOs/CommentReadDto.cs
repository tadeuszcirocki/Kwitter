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

        public User User { get; set; }
        public Kweet Kweet { get; set; }
    }
}