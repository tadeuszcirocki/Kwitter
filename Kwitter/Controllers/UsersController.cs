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
        [HttpGet("{id}", Name = "GetUserById")]
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
            var userModel = _mapper.Map<User>(UserCreateDto);
            _repo.CreateUser(userModel);
            _repo.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { userReadDto.Id }, userReadDto);
        }

        //PUT api/Users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repo.GetUserById(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);

            _repo.UpdateUser(userModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        //PATCH api/Users/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModelFromRepo = _repo.GetUserById(id);
            if(userModelFromRepo == null)
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);

            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromRepo);

            _repo.UpdateUser(userModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        //DELETE api/Users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repo.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteUser(userModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        //GET api/Users/Login
        [HttpGet("Login")]
        public ActionResult<UserReadDto> GetUserLogin(UserLoginDto userLoginDto)
        {
            var user = _repo.GetUserLogin(userLoginDto);

            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}
