using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Statement
{
    public class CreateStatementDto
    {
        public string UserId { get; set; } // Foreign key and primary key
        public long TotalBalance { get; set; }
        public long TotalExpense { get; set; }
        public long TotalIncome { get; set; }
        public long ExpensePercentage { get; set; }
        
    }
}