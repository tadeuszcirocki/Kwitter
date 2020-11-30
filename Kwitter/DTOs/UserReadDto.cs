using Kwitter.Models;
using System;
using System.Collections.Generic;


namespace Kwitter.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public char Permissions { get; set; }   //seems edgy

        public string Bio { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Kweet> Kweets { get; set; }
    }
}
