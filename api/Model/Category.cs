using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
 // Foreign key to User
        // [Required]
        // public string UserId { get; set; }

        // // Navigation property to User
        // public User User { get; set; }
    }
}
