using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.Transaction
{
    public class TransactionCreateViewModel
    {
        public decimal Price { get; set; }
        public int id_get { get; set; }
        public int AccountGameId { get; set; }
        public int UserId { get; set; }
    }
}
