using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
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
        private readonly IUserRepository _userRepository;
        public UserController(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(s => s.ToUserDto());

            //returning usersDto to avoid any sensitive data if there's
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepository.GetByIdAsync(id: id);

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
            await _userRepository.CreateAsync(userModel: userModel);
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestDto updateUserDto)
        {
            var userModel = await _userRepository.UpdateAsync(id: id, updateUserDto: updateUserDto);

            if (userModel == null)
            {
                return NotFound();

            }

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userModel = await _userRepository.DeleteAsync(id: id);
            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}