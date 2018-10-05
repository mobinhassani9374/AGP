using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatDate { get; set; }
        public ICollection<ImageGame> Images { get; set; }

        public ICollection<AccountGame> AccountGames { get; set; }
    }
}
