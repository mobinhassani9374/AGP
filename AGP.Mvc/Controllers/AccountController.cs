using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGP.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace AGP.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataLayer.Repositories.UserManager _userManager;
        private readonly IConfigurationRoot _Configuration;
        public AccountController(DataLayer.Repositories.UserManager userManager, IConfigurationRoot Configuration)
        {
            _userManager = userManager;
            _Configuration = Configuration;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Find(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("not found user", "کاربری یافت نشد");
                }
                else
                {
                    SignInAsync(userName: model.Email, userId: user.Id, serialNumber: user.SerialNumber);

                    return RedirectPermanent(string.IsNullOrEmpty(model.ReturnUrl) ? "/" : model.ReturnUrl);
                }
            }
            return View(model);
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

                    if (result.IsSuccess)
                    {
                        // ثبت نام با موفقیت انجام شد لاگین شود و بره به ایندکس
                        SignInAsync(userName: model.Email, userId: result.UserId, serialNumber: result.SerialNumber);

                        return RedirectPermanent(string.IsNullOrEmpty(model.ReturnUrl) ? "/" : model.ReturnUrl);
                    }
                    else ModelState.AddModelError("createUserFailed", "در انجام عملیات خطایی رخ داد مجددا تلاش کنید");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectPermanent("/");
        }

        private async void SignInAsync(string userName, int userId, string serialNumber, bool isPersistent = true)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.SerialNumber, serialNumber));
            claims.Add(new Claim(Security.ClaimTypes.UserId, userId.ToString()));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            var authenticationExpiresDay = _Configuration.GetValue<int>("AuthenticationExpiresDay", 30);

            await HttpContext.SignInAsync(principal, new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                ExpiresUtc = DateTimeOffset.Now.AddDays(authenticationExpiresDay),
            });
        }
    }
}