using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string UserName { get; set; } = String.Empty;

    }
}