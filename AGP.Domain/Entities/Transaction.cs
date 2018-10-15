using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionTime { get; set; }
        public bool IsPaid { get; set; }
        public int id_get { get; set; }
        public int trans_id { get; set; }
        public int AccountGameId { get; set; }
        public AccountGame AccountGame { get; set; }

        /// <summary>
        /// آیا به دست کاربر رسیده است این اکانت یا اینکه به مشگل خورده
        /// </summary>
        public bool IsSuccess { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
