using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CreateCategoryRequestDto
    {
        [Required]
        public string CategoryName { get; set; } = String.Empty;
        [Required]
        public string UserId { get; set; } = String.Empty;
    }
}