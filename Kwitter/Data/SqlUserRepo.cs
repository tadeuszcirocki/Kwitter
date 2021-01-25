using Kwitter.DTOs;
using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;

        public SqlUserRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if(!_context.Users.Any(p => p.Username == user.Username))
            {
                _context.Users.Add(user);
            }
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserLogin(UserLoginDto userLoginDto)
        {
            return _context.Users.FirstOrDefault(p => p.Username == userLoginDto.Username && p.Password == userLoginDto.Password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Comment> GetUserByIdComments(int id)
        {
            User user = _context.Users.FirstOrDefault(p => p.Id == id);
            return _context.Comments.Where(p => p.UserId == user.Id).ToList();
        }

        public ICollection<Kweet> GetUserByIdKweets(int id)
        {
            User user = _context.Users.FirstOrDefault(p => p.Id == id);
            return _context.Kweets.Where(p => p.UserId == user.Id).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            //Nothing
        }
    }
}
