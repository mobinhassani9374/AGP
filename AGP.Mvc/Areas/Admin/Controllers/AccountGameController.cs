using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;

namespace AGP.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountGameController : Controller
    {
        private readonly AccountGameRepository _accountGameRepository;
        public AccountGameController(AccountGameRepository accountGameRepository)
        {
            _accountGameRepository = accountGameRepository;
        }
        public IActionResult Waiting()
        {
            var model = _accountGameRepository.Waiting();

            return View(model);
        }
        public IActionResult Check(int id)
        {

            return View();
        }
    }
}