using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class SqlCommentRepo : ICommentRepo
    {
        private readonly DatabaseContext _context;

        public SqlCommentRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateComment(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            comment.Created = DateTime.Now;
            comment.LikeQuantity = 0;
            comment.User = _context.Users.FirstOrDefault(p => p.Id == comment.UserId);
            comment.Kweet = _context.Kweets.FirstOrDefault(p => p.Id == comment.KweetId);

            _context.Comments.Add(comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
