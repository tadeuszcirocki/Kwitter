using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class UserCreateDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public char Permissions { get; set; }   //seems edgy
        [MaxLength(500)]
        public string Bio { get; set; }
    }
}
