using Kwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public interface IKweetRepo
    {
        IEnumerable<Kweet> GetAllKweets();
        Kweet GetKweetById(int id);
    }
}
