using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public int Mobile { get; set; }

        public string Name { get; set; } = String.Empty;

    }
}