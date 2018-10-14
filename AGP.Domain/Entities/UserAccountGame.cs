using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.Entities
{
    public class UserAccountGame
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public AccountGame AccountGame { get; set; }
        public int AccountGameId { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
