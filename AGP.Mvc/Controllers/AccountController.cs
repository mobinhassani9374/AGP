using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGP.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace AGP.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}