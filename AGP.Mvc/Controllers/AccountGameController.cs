using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using AGP.Domain.Entities;

namespace AGP.Mvc.Controllers
{
    public class AccountGameController : Controller
    {
        private readonly AccountGameRepository _accountGameRepository;
        public AccountGameController(AccountGameRepository accountGameRepository)
        {
            _accountGameRepository = accountGameRepository;
        }
        public IActionResult Detail(int id)
        {
            var exist = _accountGameRepository.ExistById(id);
            if (!exist) return RedirectPermanent("/");

            var model = _accountGameRepository.GetById(id);
            if (model.State == AccountGameState.Confirmed)
                return View(model);
            else return RedirectPermanent("/");
        }
    }
}