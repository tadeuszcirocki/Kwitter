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

        public int UserId { get; set; }
    }
}
