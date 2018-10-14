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
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
    }
}