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
        private readonly DataLayer.Repositories.UserManager _userManager;
        public AccountController(DataLayer.Repositories.UserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // آیا کاربر با این یوزرنیم وجود دارد؟
                if (_userManager.ExistByUserName(model.Email))
                {
                    ModelState.AddModelError("ExistUserByUserName", "ایمیل وارد شده تکراری می باشد");
                }
                else
                {
                    // create User
                    var result = await _userManager.CreateAsync(userName: model.Email, password: model.Password, fullName: model.FullName);

                    if (result)
                    {
                        // ثبت نام با موفقیت انجام شد لاگین شود و بره به ایندکس
                    }
                    else ModelState.AddModelError("createUserFailed", "در انجام عملیات خطایی رخ داد مجددا تلاش کنید");
                }
            }
            return View(model);
        }

        private void SignIn(string userName, int userId, string serialNumber)
        {

        }
    }
}