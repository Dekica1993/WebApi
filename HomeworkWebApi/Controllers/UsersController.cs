using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeworkWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
       public IActionResult GetAll()
        {
            var response = StaticDb.Users;
            return Ok(response);
        }

        [HttpGet("GetOneUsers")]
        public IActionResult GetOneUser()
        {
            
            return Ok("Dejan");
        }
    }
}

