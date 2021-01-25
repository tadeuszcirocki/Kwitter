using Kwitter.DTOs;
using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        public ICollection<Kweet> GetUserByIdKweets(int id);
        public ICollection<Comment> GetUserByIdComments(int id);
        void UpdateUser(User user);
        void DeleteUser(User user);

        User GetUserLogin(UserLoginDto userLoginDto);
    }
}
