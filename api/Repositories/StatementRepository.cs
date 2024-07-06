using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private readonly ApplicationDbContext _context;

        public StatementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Statement> GeUserStatementAsync(string userId)
        {
            // return await _context.Statement
            var statement = await _context.Statement
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync();

            // if (statement == null)
            // {
            //     // Handle not found case, e.g., return null or throw an exception
            //     throw new KeyNotFoundException("Statement not found for user.");
            // }

            return statement;
        }

        public async Task<Statement> InitializeStatementAsync(string userId)
        {
            // Create a statement for the user
            var statement = new Statement
            {
                UserId = userId,
                TotalBalance = 0,
                TotalExpense = 0,
                TotalIncome = 0,
                ExpensePercentage =0,
            };

            // Save the statement to the database
            await _context.Statement.AddAsync(statement);
            var savedStatement = await _context.SaveChangesAsync();
            return statement;

        }
    }
}
