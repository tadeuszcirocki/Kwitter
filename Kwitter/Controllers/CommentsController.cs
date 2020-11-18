﻿using System;
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

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAllComments()
        {
            var comments = _repo.GetAllComments();

            return Ok(comments);
        }
    }
}