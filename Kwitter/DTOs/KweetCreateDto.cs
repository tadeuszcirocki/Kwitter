using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class KweetCreateDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }
    }
}
