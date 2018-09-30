using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AGP.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using AGP.Domain.ViewModel.AccountGame;
using AGP.Utility.Identity;
using AGP.Mvc.Security;
using AGP.Mvc.ExtensionMethods;

namespace AGP.Mvc.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class UserController : Controller
    {
        private readonly AccountGameRepository _accountGameRepository;
        public UserController(AccountGameRepository accountGameRepository)
        {
            _accountGameRepository = accountGameRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region  اکانت
        public IActionResult AddAccount()
        {
            var games = _accountGameRepository.GetAllGames();

            ViewBag.Games = games.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.DisplayName
            }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddAccount(AccountGameCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.GetUserId();

                var result = _accountGameRepository.Create(model);

                TempData.AddResult(result);

                return RedirectToAction(nameof(AddAccount));
            }
            var games = _accountGameRepository.GetAllGames();

            ViewBag.Games = games.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.DisplayName,
                Selected = model.GameId == c.Id ? true : false,
            }).ToList();
            return View(model);
        }

        public IActionResult AccountList()
        {
            var userId = User.GetUserId();

            var model = _accountGameRepository.GetAllByUserId(userId);


            return View(model);
        }

        public IActionResult AccountDetail(int id)
        {
            var userId = User.GetUserId();

            // ایا اکانت موجود می باشد
            var exist = _accountGameRepository.ExistById(id);

            if (!exist) return RedirectToAction(nameof(AccountList));

            // آیا اکانت توسط کاربر ایجاد شده است
            var isCreateByUser = _accountGameRepository.IsCreateByUser(userId, id);

            if(!isCreateByUser)
                return RedirectToAction(nameof(AccountList));

            var model = _accountGameRepository.GetById(id);

            return View(model);
        }
        #endregion
    }
}