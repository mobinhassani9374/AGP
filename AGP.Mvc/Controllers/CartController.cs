using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using AGP.Payment.Bitpay;
using AGP.Domain.ViewModel.Transaction;
using AGP.Mvc.Security;

namespace AGP.Mvc.Controllers
{
    public class CartController : Controller
    {

        private readonly TransacionRepository _transacionRepository;
        private readonly PayService _payService;
        private readonly AccountGameRepository _accountGameRepository;
        public CartController(TransacionRepository transacionRepository,
            PayService payService,
             AccountGameRepository accountGameRepository)
        {
            _transacionRepository = transacionRepository;
            _payService = payService;
            _accountGameRepository = accountGameRepository;
        }
        /// <summary>
        /// نمایش فاکتور و پرداخت نهایی
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int id)
        {
            // به دست آوردن جزییات تراکنش
            return View();
        }
        /// <summary>
        ///  از بیت پی آی دی گت رو دریافت میکنیم و یک رکورذ ذر تراکنش ها میزنیم
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Add(int id)
        {
            // به دست آوردن قیمت اکانت بازی
            var price = _accountGameRepository.GetPrice(id);

            // به دست آوردن آی دی گت از بیت پی
            var result = await _payService.Pay(price);

            // یک رکورد در تراکنش ها
            _transacionRepository.Create(new TransactionCreateViewModel
            {
                AccountGameId = id,
                id_get = result.id_get,
                Price = price,
                UserId = User.GetUserId()
            });

            return RedirectToAction(nameof(Index), new { id =result.id_get});

        }
    }
}