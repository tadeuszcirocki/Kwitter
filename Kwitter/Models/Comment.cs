using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/* TODO
 * how to handle foreign keys
 */

namespace Kwitter.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [DefaultValue(0)]
        public int LikeQuantity { get; set; }

        [Required]
        public Kweet FkKweet { get; set; }

        // I didn't use user as foreign key here
        // it's not necessary since kweet has it already
    }
}
