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
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        User GetUserOfComment(int id);    //get user of comment by comment id
        void AddLike(int id);
    }
}
