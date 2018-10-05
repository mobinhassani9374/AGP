using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string SerialNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<LogService> LogServices { get; set; }

        public ICollection<AccountGame> AccountGames { get; set; }
    }
}
