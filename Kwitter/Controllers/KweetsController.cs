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
    public class KweetsController : ControllerBase
    {
        private readonly IKweetRepo _repo;
        private readonly IMapper _mapper;

        public KweetsController(IKweetRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/Kweets
        [HttpGet]
        public ActionResult<IEnumerable<KweetReadDto>> GetAllKweets()
        {
            var kweets = _repo.GetAllKweets();

            return Ok(_mapper.Map<IEnumerable<KweetReadDto>>(kweets));
        }

        //GET api/Kweets/{id}
        [HttpGet("{id}", Name = "GetKweetById")]
        public ActionResult <KweetReadDto> GetKweetById(int id)
        {
            var kweet = _repo.GetKweetById(id);
            if(kweet != null)
            {
                return Ok(_mapper.Map<KweetReadDto>(kweet));
            }
            return NotFound();
        }

        //GET api/Kweets/{id}/Comments
        [HttpGet("{id}/Comments")]
        public ActionResult<IEnumerable<CommentReadDto>> GetKweetByIdComments(int id)
        {
            var comments = _repo.GetKweetByIdComments(id);
            
            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        //POST api/Kweets
        [HttpPost]
        public ActionResult<KweetReadDto> CreateKweet(KweetCreateDto kweetCreateDto)
        {
            var kweetModel = _mapper.Map<Kweet>(kweetCreateDto);
            _repo.CreateKweet(kweetModel);
            _repo.SaveChanges();

            var kweetReadDto = _mapper.Map<KweetReadDto>(kweetModel);

            return CreatedAtRoute(nameof(GetKweetById), new { kweetReadDto.Id }, kweetReadDto);
        }


    }
}
