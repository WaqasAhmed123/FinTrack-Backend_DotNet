using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/statement")]
    [ApiController]
    public class StatementController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IStatementRepository _statementRepository;

        public StatementController(ApplicationDbContext context, IStatementRepository statementRepository)
        {
            _context = context;
            _statementRepository = statementRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetStatementById(int id)
        {
            var statement = await _statementRepository.GetStatementByIdAsync(id: id);
            // var usersDto = statement.Select(s => s.ToUserDto());

            //returning usersDto to avoid any sensitive data if there's
            return Ok(statement);
        }


    }
}