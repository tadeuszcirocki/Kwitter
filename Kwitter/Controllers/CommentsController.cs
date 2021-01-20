using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kwitter.Data;
using Kwitter.DTOs;
using Kwitter.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        //PUT api/Comments/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateComment(int id, CommentUpdateDto commentUpdateDto)
        {
            var commentModelFromRepo = _repo.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commentUpdateDto, commentModelFromRepo);

            _repo.UpdateComment(commentModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        //PATCH api/Comments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommentUpdate(int id, JsonPatchDocument<CommentUpdateDto> patchDoc)
        {
            var commentModelFromRepo = _repo.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }
            
            var commentToPatch = _mapper.Map<CommentUpdateDto>(commentModelFromRepo);
            patchDoc.ApplyTo(commentToPatch, ModelState);

            if (!TryValidateModel(commentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commentToPatch, commentModelFromRepo);

            _repo.UpdateComment(commentModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/Comments/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            var commentModelFromRepo = _repo.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteComment(commentModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }
    }
}
