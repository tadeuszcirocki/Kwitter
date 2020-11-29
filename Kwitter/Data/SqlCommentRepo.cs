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

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(p => p.Id == id);
        }
    }
}
