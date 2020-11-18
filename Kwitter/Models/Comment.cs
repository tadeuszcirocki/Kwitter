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
        public int Id { get; set; }
        public string Content { get; set; }
        public int LikeQuantity { get; set; }
        public DateTime? Created { get; set; }

        public virtual User User { get; set; }
        public virtual Kweet Kweet { get; set; }

    }
}