using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>?> GetAllTransactions(int id);
    }
}