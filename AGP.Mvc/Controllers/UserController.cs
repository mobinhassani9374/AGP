using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AGP.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        #region اضافه نمودن اکانت
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
        #endregion
    }
}