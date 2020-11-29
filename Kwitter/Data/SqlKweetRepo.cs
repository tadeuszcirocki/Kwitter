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
        public IEnumerable<Kweet> GetAllKweets()
        {
            return _context.Kweets.ToList();
        }

        public Kweet GetKweetById(int id)
        {
            return _context.Kweets.FirstOrDefault(p => p.Id == id);
        }
    }
}
