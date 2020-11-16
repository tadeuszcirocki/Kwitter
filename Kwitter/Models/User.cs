using System;
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

        // my idea is to make user login through an email
        // and set username visible to other users
        [Required]
        [MaxLength(20)]
        public string email { get; set; }

        [Required]
        [MaxLength(20)]
        public string username { get; set; }

        [Required]
        [MaxLength(20)]
        public string password { get; set; }

        [Required]
        public char permissions { get; set; }

        public string bio { get; set; }

    }
}
