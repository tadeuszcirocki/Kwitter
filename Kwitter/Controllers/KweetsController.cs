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
    public class KweetsController : ControllerBase
    {
        private readonly IKweetRepo _repo;

        public KweetsController(IKweetRepo repo)
        {
            _repo = repo;
        }

        //GET api/Kweets
        [HttpGet]
        public ActionResult<IEnumerable<Kweet>> GetAllKweets()
        {
            var kweets = _repo.GetAllKweets();

            return Ok(kweets);
        }

        //GET api/Kweets/{id}
        [HttpGet("{id}")]
        public ActionResult <Kweet> GetKweetById(int id)
        {
            var kweet = _repo.GetKweetById(id);

            return Ok(kweet);
        }


    }
}
