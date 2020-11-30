using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public char Permissions { get; set; }   //seems edgy

        public string Bio { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Kweet> Kweets { get; set; }
    }
}
