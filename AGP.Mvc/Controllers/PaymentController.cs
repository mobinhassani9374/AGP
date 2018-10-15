using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using AGP.Payment.Bitpay;
using AGP.Domain.ViewModel.Transaction;
using AGP.Domain.ViewModel.UserAccountGame;
using AGP.Mvc.Security;

namespace AGP.Mvc.Controllers
{
    public class PaymentController : Controller
    {
        private readonly TransacionRepository _transacionRepository;
        private readonly PayService _payService;
        private readonly UserAccountGameRepository _userAccountGameRepository;
        public PaymentController(TransacionRepository transacionRepository,
            PayService payService,
            UserAccountGameRepository userAccountGameRepository)
        {
            _transacionRepository = transacionRepository;
            _payService = payService;
            _userAccountGameRepository = userAccountGameRepository;
        }
        /// <summary>
        /// نتیجه از سمت بیت پی
        /// </summary>
        /// <param name="trans_id"></param>
        /// <param name="id_get"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BitPayResponse(int trans_id, int id_get)
        {
            // زمانی که ازسمت بیت برگشت 
            var payResult = await _payService.Checkout(trans_id, id_get);

            _transacionRepository.Update(new
                TransactionEditViewModel
            {
                id_get = id_get,
                trans_id = trans_id,
                IsPaid = payResult.IsSuccess
            });

            if (payResult.IsSuccess)
            {
                var accountGameId = _transacionRepository.GetAccountGameId(id_get);
                // یک رکورد در درخواست های کاربر میزنیم UserAccountGame 
                _userAccountGameRepository.Create(new UserAccountGameCreateViewModel
                {
                    AccountGameId = accountGameId,
                    RequestTime = DateTime.Now,
                    UserId = User.GetUserId()
                });
            }
            else
            {
                // پرداختی صورت نگرفته است
                // نمایش ارور
            }
            // ابتدا باید چک شود پرداخت کرده یا نه
            // اگر پرداخت کرده بودISPAid آپدیت شود
            // State AccountGame= RequestBuy 
            // سپس یک رکورد در UserAccountGame بخورد 
            // تراکنش آپیدیت شود
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
    }
}