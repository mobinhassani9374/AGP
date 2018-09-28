using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGP.Domain.ViewModel.AccountGame
{
    public class AccountGameCreateViewModel
    {
        public string Level { get; set; }

        [Required(ErrorMessage = "توضیحات اکانت نمی تواند فاقد مقدار باشد")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int GameId { get; set; }

        public int UserId { get; set; }
      
    }
}
