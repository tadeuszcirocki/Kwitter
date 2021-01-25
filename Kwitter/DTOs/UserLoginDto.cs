using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
