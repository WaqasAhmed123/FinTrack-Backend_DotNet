using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UpdateRequestDto
    {
        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Name { get; set; } = String.Empty;
    }
}