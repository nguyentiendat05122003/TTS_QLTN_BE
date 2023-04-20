using System;
using System.Collections.Generic;

namespace APIPCHY.Models
{
    public partial class Account
    {
        public string AccountId { get; set; } = null!;

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }
    }

}

