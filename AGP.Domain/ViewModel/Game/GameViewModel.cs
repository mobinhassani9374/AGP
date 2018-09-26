using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.Game
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatDate { get; set; }
        public List<ImageGameViewModel> Images { get; set; }
    }
}
