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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        //GET api/Users/{id}
        [HttpGet("{id}")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var user = _repo.GetUserById(id);
            if(user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();

        }

        //GET api/Users/{id}/Comments
        [HttpGet("{id}/Comments")]
        public ActionResult<IEnumerable<CommentReadDto>> GetUserByIdComments(int id)
        {
            var comments = _repo.GetUserByIdComments(id);

            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        //GET api/Users/{id}/Kweets
        [HttpGet("{id}/Kweets")]
        public ActionResult<IEnumerable<KweetReadDto>> GetUserByIdKweets(int id)
        {
            var comments = _repo.GetUserByIdKweets(id);

            return Ok(_mapper.Map<IEnumerable<KweetReadDto>>(comments));
        }

        //POST api/Users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto UserCreateDto)
        {
            var UserModel = _mapper.Map<User>(UserCreateDto);
            _repo.CreateUser(UserModel);
            _repo.SaveChanges();

            return Ok(UserModel);
        }
    }
}
