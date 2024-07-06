using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> Add(Transaction transaction);
        Task<List<Transaction>?> GetAllTransactions(string userId);
        Task<List<Transaction>?> GetAllTransactionsByType(string userId,bool IsIncome);
        
    }
}