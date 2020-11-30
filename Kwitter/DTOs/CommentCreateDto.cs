using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class CommentCreateDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int KweetId { get; set; }
    }
}
