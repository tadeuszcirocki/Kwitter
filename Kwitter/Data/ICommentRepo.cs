using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwitter.Data
{
    public interface ICommentRepo
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById();
    }
}
