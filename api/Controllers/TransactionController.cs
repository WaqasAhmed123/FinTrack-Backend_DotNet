using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Transaction;
using api.Dtos.TransactionDto;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;
        public TransactionController(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)

        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost("add")]
        // [Authorize]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransactionRequestDto createTransactionRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transaction = await createTransactionRequestDto.ToTransactionFromCreateDTOAsync(_categoryRepository);
                var addedTransaction = await _transactionRepository.Add(transaction);

                return Ok("Transaction Added");
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] string userId)
        {
            var transactions = await _transactionRepository.GetAllTransactions(userId);

            if (transactions == null)
                return NotFound();

            var transactionsDto = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                transactionsDto.Add(await transaction.ToTransactionDto(_categoryRepository));
            }

            return Ok(transactionsDto);
        }

        [HttpGet("byType")]
        public async Task<IActionResult> GetAllTransactionsByType([FromQuery] string userId, bool isIncome)
        {
            var transactions = await _transactionRepository.GetAllTransactionsByType(userId, isIncome);

            if (transactions == null)
                return NotFound();

            var transactionsDto = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                transactionsDto.Add(await transaction.ToTransactionDto(_categoryRepository));
            }

            return Ok(transactionsDto);
        }
    }
}