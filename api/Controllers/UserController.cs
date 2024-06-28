using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetALL()
        {
            var user = _context.User.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if(user==null){
                return NotFound();
            }
            
            return Ok(user);

        }

        [HttpPost]
        public IActionResult Create ([FromBody] )

    }
}