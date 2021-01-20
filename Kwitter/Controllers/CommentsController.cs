using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kwitter.Data;
using Kwitter.DTOs;
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
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<CommentReadDto>> GetAllComments()
        {
            var comments = _repo.GetAllComments();

            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        //GET api/Comments/{id}
        [HttpGet("{id}", Name ="GetCommentById")]
        public ActionResult <CommentReadDto> GetCommentById(int id)
        {
            var comment = _repo.GetCommentById(id);
            if (comment != null)
            {
                return Ok(_mapper.Map<CommentReadDto>(comment));
            }
            return NotFound();
        }

        //GET api/Comments/Post/{id}
        [HttpGet("Post/{id}")]
        public ActionResult<IEnumerable<CommentReadDto>> GetCommentsByPostId(int id)
        {
            var comments = _repo.GetCommentsByPostId(id);

            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        //POST api/Comments
        [HttpPost]
        public ActionResult <CommentReadDto> CreateComment(CommentCreateDto commentCreateDto)
        {
            var commentModel = _mapper.Map<Comment>(commentCreateDto);
            _repo.CreateComment(commentModel);
            _repo.SaveChanges();

            var commentReadDto = _mapper.Map<CommentReadDto>(commentModel);

            return CreatedAtRoute(nameof(GetCommentById), new { commentReadDto.Id }, commentReadDto);
        }
    }
}
