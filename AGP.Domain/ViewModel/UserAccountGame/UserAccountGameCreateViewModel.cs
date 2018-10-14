using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.UserAccountGame
{
    public class UserAccountGameCreateViewModel
    {
        public int UserId { get; set; }
        public int AccountGameId { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
