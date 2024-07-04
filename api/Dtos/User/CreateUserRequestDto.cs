using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Mobile number must be exactly 11 digits.")]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = String.Empty;
    }
}