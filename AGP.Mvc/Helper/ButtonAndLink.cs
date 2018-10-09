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
        public static bool EnableBuyFinal(AccountGameState state,AccountGameBuyState buyState)
        {
            if(state== AccountGameState.Confirmed)
            {
                if(buyState== AccountGameBuyState.Buied || buyState== AccountGameBuyState.ExistRequest)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
