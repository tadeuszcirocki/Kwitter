using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class CommentCreateDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int KweetId { get; set; }
    }
}
