using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AGP.Mvc.Controllers
{
    public class PaymentController : Controller
    {
        /// <summary>
        /// نتیجه از سمت بیت پی
        /// </summary>
        /// <param name="trans_id"></param>
        /// <param name="id_get"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BitPayResponse(int trans_id, int id_get)
        {
            // زمانی که ازسمت بیت برگشت 
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