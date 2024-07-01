using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetALL()
        {
            var users = await _context.User.ToListAsync();
            var usersDto = users.Select(s => s.ToUserDto());

            //returning usersDto to avoid any sensitive data if there's
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDTO();
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDto updateUserDto)
        {

            var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                return NotFound();

            }
            userModel.Email = updateUserDto.Email;
            userModel.Name = updateUserDto.Name;
            userModel.Mobile = updateUserDto.Mobile;

            await _context.SaveChangesAsync();
            return Ok(userModel.ToUserDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }
            _context.User.Remove(userModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}