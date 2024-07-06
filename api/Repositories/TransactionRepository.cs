using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>?> GetAllTransactions(string userId)
        {
            return await _context.Transaction
                                 .Where(t => t.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<List<Transaction>?> GetAllTransactionsByType(string userId, bool isIncome)
        {
            return await _context.Transaction
                                 .Where(t => t.UserId == userId && t.IsIncome == isIncome)
                                 .ToListAsync();
        }
    }
}