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
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public char Permissions { get; set; }   //seems edgy
        public string Bio { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Kweet> Kweets { get; set; }
    }
}
