using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

/* TODO
 * how to handle foreign keys
 */

namespace Kwitter.Models
{
    public class Kweet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [DefaultValue(0)]
        public int LikeQuantity { get; set; }

        [Required]
        public User FkUser { get; set; }

    }
}
