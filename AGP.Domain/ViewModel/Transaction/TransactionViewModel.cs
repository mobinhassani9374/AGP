using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.Transaction
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionTime { get; set; }
        public bool IsPaid { get; set; }
        public int id_get { get; set; }
        public int trans_id { get; set; }
        public int AccountGameId { get; set; }
        public Domain.Entities.AccountGame AccountGame { get; set; }

    }
}
