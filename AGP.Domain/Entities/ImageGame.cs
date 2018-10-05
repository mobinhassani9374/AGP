using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.Entities
{
    public class ImageGame
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
