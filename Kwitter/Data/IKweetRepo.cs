using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public interface IKweetRepo
    {
        bool SaveChanges();

        IEnumerable<Kweet> GetAllKweets();
        Kweet GetKweetById(int id);
        User GetUserOfKweet(int id);    //get user of post by post id
        void CreateKweet(Kweet kweet);
        public ICollection<Comment> GetKweetByIdComments(int id);    //naming comes from GET kweet/{id}/comments
        public void AddLike(int id);

    }
}
