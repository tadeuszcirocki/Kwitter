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

        public virtual User User { get; set; }
        public virtual Kweet Kweet { get; set; }
    }
}
