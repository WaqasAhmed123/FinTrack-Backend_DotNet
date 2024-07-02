using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Statement
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; } // Foreign key and primary key

        // [ForeignKey(nameof(UserId))]
        public User User { get; set; } // Navigation property


        public long TotalBalance { get; set; }
        public long TotalExpense { get; set; }
        public long TotalIncome { get; set; }
        public long ExpensePercentage { get; set; }


    }
}