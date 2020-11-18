using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;


namespace Kwitter.Models
{
    public class Kweet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int LikeQuantity { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }
    }
}
