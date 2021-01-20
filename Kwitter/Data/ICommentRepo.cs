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
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        Comment GetCommentById(int id);
        void CreateComment(Comment comment);
        User GetUserOfComment(int id);    //get user of comment by comment id

    }
}
