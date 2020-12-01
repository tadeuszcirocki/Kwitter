using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public interface ICommentRepo
    {
        bool SaveChanges();

        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        void CreateComment(Comment comment);
    }
}
