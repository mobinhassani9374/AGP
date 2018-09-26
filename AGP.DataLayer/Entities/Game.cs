using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatDate { get; set; }
        public ICollection<ImageGame> Images { get; set; }
    }
}
