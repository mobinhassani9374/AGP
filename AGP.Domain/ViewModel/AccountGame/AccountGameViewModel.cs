using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGP.Domain.ViewModel.AccountGame
{
    public class AccountGameViewModel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public int State { get; set; }
        /// <summary>
        /// دلیل رد اکانت
        /// </summary>
        public string ReasonForCancel { get; set; }
        /// <summary>
        /// تاریخ درخواست خرید
        /// </summary>
        public DateTime? RequestDate { get; set; }
        public DateTime? BuyDate { get; set; }
        public bool IsDone { get; set; }
        public int BuyState { get; set; }
        public bool IsDeActiveByAdmin { get; set; }
        public string ReasonForDeActiveByAdmin { get; set; }

        public string GameName { get; set; }
        public string GameDisplayName { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
