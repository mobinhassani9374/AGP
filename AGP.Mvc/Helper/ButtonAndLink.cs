using AGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc.Helper
{
    public static class ButtonAndLink
    {
        /// <summary>
        /// دکمه نهایی کردن خرید
        /// </summary>
        /// <returns></returns>
        public static bool EnableBuyFinal(AccountGameState state,AccountGameBuyState buyState,bool isActive)
        {
            if (isActive && state == AccountGameState.Confirmed && (buyState == AccountGameBuyState.WaitingForBuy || buyState == AccountGameBuyState.FailRequest))
                return true;


           return false;
        }

        public static bool EnableCheckAndBuy(AccountGameBuyState buyState)
        {
            if (buyState == AccountGameBuyState.FailRequest || buyState == AccountGameBuyState.WaitingForBuy)
                return true;

            return false;
        }
    }
}
