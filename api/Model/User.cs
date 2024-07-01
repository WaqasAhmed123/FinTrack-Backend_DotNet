using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = String.Empty;

        // // Navigation property
        // public ICollection<Statement> Statements { get; set; } = new List<Statement>();
    }
}
