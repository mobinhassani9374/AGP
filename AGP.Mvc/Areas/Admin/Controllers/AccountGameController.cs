using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using AGP.Domain.ViewModel.AccountGame;
using AGP.Mvc.ExtensionMethods;

namespace AGP.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountGameController : Controller
    {
        private readonly AccountGameRepository _accountGameRepository;
        private readonly GameRepository _gameRepository;
        public AccountGameController(AccountGameRepository accountGameRepository,
            GameRepository gameRepository)
        {
            _accountGameRepository = accountGameRepository;
            _gameRepository = gameRepository;
        }
        public IActionResult Waiting()
        {
            var model = _accountGameRepository.Waiting();

            return View(model);
        }

        public IActionResult Check(int id)
        {
            var exist = _accountGameRepository.ExistById(id);

            if (!exist) return RedirectToAction(nameof(Waiting));

            if (!_accountGameRepository.AccountStateIsWaiting(id))
                return RedirectToAction(nameof(Waiting));

            var model = _accountGameRepository.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AccountGameEditViewModel model)
        {

            var result = _accountGameRepository.Update(model);

            TempData.AddResult(result);

            return RedirectToAction(nameof(Check), new { id = model.Id });
        }

        public IActionResult CancelAccount(int id)
        {
            var exist = _accountGameRepository.ExistById(id);

            if (!exist) return RedirectToAction(nameof(Waiting));

            if (!_accountGameRepository.AccountStateIsWaiting(id))
                return RedirectToAction(nameof(Waiting));

            ViewBag.AccountGameId = id;

            return View();
        }
        [HttpPost]
        public IActionResult CancelAccount(int accountGameId, string reason)
        {
            var result = _accountGameRepository.DoCancel(accountGameId, reason);
            TempData.AddResult(result);
            return Helper.FancyBox.CloseAndRedirect(Url.Action(nameof(Waiting)));
        }

        public IActionResult ConfirmedAccount(int id)
        {
            var exist = _accountGameRepository.ExistById(id);

            if (!exist) return RedirectToAction(nameof(Waiting));

            if (!_accountGameRepository.AccountStateIsWaiting(id))
                return RedirectToAction(nameof(Waiting));

            ViewBag.AccountGameId = id;

            var gameId = _accountGameRepository.GetGameId(id);

            ViewBag.Images = _gameRepository.GetImageNames(gameId);


            return View();
        }

        [HttpPost]
        public IActionResult ConfirmedAccount(int accountGameId, string imageName)
        {
            var result = _accountGameRepository.DoConfirmed(accountGameId, imageName);
            TempData.AddResult(result);
            return RedirectToAction(nameof(Waiting));
        }
    }
}