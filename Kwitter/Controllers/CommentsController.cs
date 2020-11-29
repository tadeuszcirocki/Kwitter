using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kwitter.Data;
using Kwitter.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kwitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepo _repo;

        public CommentsController(ICommentRepo repo)
        {
            _repo = repo;
        }

        //GET api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAllComments()
        {
            var comments = _repo.GetAllComments();

            return Ok(comments);
        }

        //Get api/Comments/{id}
        [HttpGet("{id}")]
        public ActionResult <Comment> GetCommentById(int id)
        {
            var comment = _repo.GetCommentById(id);

            return Ok(comment);
        }
    }
}
