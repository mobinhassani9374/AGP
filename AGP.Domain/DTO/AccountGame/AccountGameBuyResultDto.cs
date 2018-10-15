using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.DTO.AccountGame
{
    public class AccountGameBuyResultDto
    {
        public bool Conflict { get; set; }
        public string Message { get; set; }
        public static AccountGameBuyResultDto Error()
        {
            return new AccountGameBuyResultDto
            {
                Conflict = false,
                Message = "اکانت مورد نظر توسط کاربر دیگری در حال بررسی می باشد"
            };
        }
    }
}
