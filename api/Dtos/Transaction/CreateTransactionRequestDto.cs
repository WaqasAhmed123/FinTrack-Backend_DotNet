using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Transaction
{
    public class CreateTransactionRequestDto
    {
        public string UserId { get; set; }
        public String Title { get; set; } = String.Empty;
        public String Date { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public String CategoryName { get; set; }
        public long Amount { get; set; }
        public bool IsIncome { get; set; }
    }
}