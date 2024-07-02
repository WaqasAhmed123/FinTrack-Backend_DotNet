using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace api.Model
{
    public class User: IdentityUser
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int UserId { get; set; }

        // [Required]
        // [StringLength(100)]
        // public string Email { get; set; } = string.Empty;

        // [Required]
        // [StringLength(15)]
        public string Mobile { get; set; } = string.Empty;

        // [Required]
        // [StringLength(100)]
        // public string Name { get; set; } = String.Empty;

         // Navigation property for Statement
        public Statement Statement { get; set; }

        // Navigation property for Transactions
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
