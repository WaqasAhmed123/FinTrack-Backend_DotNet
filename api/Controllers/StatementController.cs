using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Statement;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    // [Route("api/statement")]
    [Route("api/statement")]
    [ApiController]
    public class StatementController : ControllerBase
    {

        private readonly IStatementRepository _statementRepository;
        private readonly UserManager<User> _userManager;


        public StatementController(IStatementRepository statementRepository, UserManager<User> userManager)
        {
            _statementRepository = statementRepository;
            _userManager = userManager;
        }

        // [HttpGet("statement")]
        // [Authorize]
        // public async Task<IActionResult> GetUserStatement()
        // {
        //     var email = User.GetEmail();
        //     var user = await _userManager.FindByEmailAsync(email);
        //     var statement = await _statementRepository.GeUsertStatementAsync(user: user);
        //     if(statement==null)return BadRequest("statement null");
        //     Console.WriteLine("statement is", statement);
        //     return Ok(statement);
        // }

        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetUserStatement([FromQuery] string userId)
        {
            // var email = User.GetEmail();
            // if (string.IsNullOrEmpty(email))
            // {
            //     return Unauthorized("Email claim is missing.");
            // }
            // var email = "user@example.com";
            var statement = await _statementRepository.GeUserStatementAsync(userId);

            // var user = await _userManager.FindByEmailAsync();

            // if (user == null)
            // {
            //     return NotFound("User not found.");
            // }

            // var statement = await _statementRepository.GeUserStatementAsync(user);

            if (statement == null)
            {
                return NotFound("Statement not found.");
            }

            // return Ok(new StatementDto
            // {


            // });

            return Ok(StatementMapper.ToStatementDto(statement));
        }


    }
}