using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.User;
using api.Interfaces;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace api.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == loginDto.Email);

            if (user == null) return Unauthorized("Invalid Email");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Email not found and/or Password is incorrect");

            return Ok(new NewUserDto
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Mobile = user.Mobile,
                Token = _tokenService.CreateToken(user)
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    Mobile = registerDto.Mobile
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        try
                        {
                            var token = _tokenService.CreateToken(user);
                            return Ok(new NewUserDto
                            {
                                UserId = user.Id,
                                UserName = user.UserName,
                                Email = user.Email,
                                Mobile = user.Mobile,
                                Token = token
                            });
                        }
                        catch (Exception ex)
                        {
                            // Handle token generation errors
                            return StatusCode(500, new { Message = "Error generating token", Error = ex.Message });
                        }
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }

        }

    }
}