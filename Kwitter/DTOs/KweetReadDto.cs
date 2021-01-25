using System;
using System.Collections.Generic;
using Kwitter.Models;

namespace Kwitter.DTOs
{
    public class KweetReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int LikeQuantity { get; set; }

        public string Created { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int UserId { get; set; }
    }
}
