using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TransactionDto
{
    public  class  TransactionDto
    {
        public int TransactionId { get; set; }
        public String Title { get; set; } = String.Empty;
        public String Date { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public string CategoryName { get; set; } = String.Empty;
        // public int CategoryName { get; set; } 
        public long Amount { get; set; }
        public bool IsIncome { get; set; }
    }
}