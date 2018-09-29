using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGP.Domain.ViewModel.AccountGame
{
    public class AccountGameEditViewModel
    {
        public int Id { get; set; }
        public string Level { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
      
    }
}
