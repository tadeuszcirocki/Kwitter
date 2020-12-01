using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class SqlKweetRepo : IKweetRepo
    {
        private readonly DatabaseContext _context;

        public SqlKweetRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateKweet(Kweet kweet)
        {
            if (kweet == null)
            {
                throw new ArgumentNullException(nameof(kweet));
            }
            kweet.Created = DateTime.Now;
            kweet.LikeQuantity = 0;

            _context.Kweets.Add(kweet);
        }

        public IEnumerable<Kweet> GetAllKweets()
        {
            return _context.Kweets.ToList();
        }

        public Kweet GetKweetById(int id)
        {
            return _context.Kweets.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ICollection<Comment> GetKweetByIdComments(int id)    //naming comes from GET kweet/{id}/comments
        {
            Kweet kweet = _context.Kweets.FirstOrDefault(p => p.Id == id);
            kweet.Comments = _context.Comments.Where(p => p.KweetId == kweet.Id).ToList();
            return kweet.Comments;
        }
    }
}
