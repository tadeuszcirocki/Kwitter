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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UsersController(IUserRepo repo)
        {
            _repo = repo;
        }

        //GET api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repo.GetAllUsers();

            return Ok(users);
        }

        //GET api/Users/{id}
        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id)
        {
            var user = _repo.GetUserById(id);

            return Ok(user);
        }
    }
}
