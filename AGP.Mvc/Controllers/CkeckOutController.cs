using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AGP.Mvc.Controllers
{
    public class CkeckOutController : Controller
    {
        public IActionResult Index(int id)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectPermanent("/");


            ViewBag.AccountGameId = id;
            return View();
        }
    }
}