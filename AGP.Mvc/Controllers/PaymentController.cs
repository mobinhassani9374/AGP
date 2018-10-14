using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using AGP.Payment.Bitpay;
using AGP.Domain.ViewModel.Transaction;

namespace AGP.Mvc.Controllers
{
    public class PaymentController : Controller
    {
        private readonly TransacionRepository _transacionRepository;
        private readonly PayService _payService;
        public PaymentController(TransacionRepository transacionRepository,
            PayService payService)
        {
            _transacionRepository = transacionRepository;
            _payService = payService;
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
            if(payResult.IsSuccess)
            {

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