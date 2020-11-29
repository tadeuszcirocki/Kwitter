using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


/* TODO
 * add a profile picture
 * encode password
 * permissions should be an enum, not sure where to declare it?
 */

namespace Kwitter.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

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

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Kweet> Kweets { get; set; }
    }
}
