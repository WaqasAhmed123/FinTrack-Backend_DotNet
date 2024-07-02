using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Transaction
    {
        [ForeignKey("User")]
        public string UserId { get; set; } // Foreign key

        // [ForeignKey(nameof(UserId))]
        public User User { get; set; } // Navigation property

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public String Title { get; set; } = String.Empty;
        public String Date { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;

        [ForeignKey("Category")]
        public int CategoryId { get; set; } // Foreign key for Categories
        public Category Category { get; set; } // Navigation property
        public long Amount { get; set; }
        public bool IsIncome { get; set; }

    }
}