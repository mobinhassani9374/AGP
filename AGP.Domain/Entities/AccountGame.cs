using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AGP.Domain.Entities
{
    public class AccountGame
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public AccountGameState State { get; set; }
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
        public AccountGameBuyState BuyState { get; set; }
        public bool IsDeActiveByAdmin { get; set; }
        public string ReasonForDeActiveByAdmin { get; set; }
        public string ImageName { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Game Game { get; set; }
        public int GameId { get; set; }
        public int? UserBuyerId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<UserAccountGame> Users { get; set; }
        public ICollection<Transaction> Transactions { get; set; }


    }
    public enum AccountGameState
    {
        [Display(Name = "در حال بررسی")]
        Waiting = 1,

        [Display(Name = "تایید شده")]
        Confirmed = 2,

        [Display(Name = "رد شده است")]
        Cancel = 3
    }
    public enum AccountGameBuyState
    {
        [Display(Name ="هنوز به فروش نرسیده است")]
        WaitingForBuy = 1,

        [Display(Name = "یک درخواست خرید برای اکانت وجود دارد")]
        ExistRequest = 2,

        [Display(Name = "درخواست خرید ناموفق")]
        FailRequest = 3,

        [Display(Name = "به فروش رسید")]
        Buied = 4
    }
}
