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
    }
}
