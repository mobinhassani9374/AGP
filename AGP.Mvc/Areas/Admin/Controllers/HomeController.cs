using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGP.DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGP.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AdminExtraRepository _adminExtraRepository;
        public HomeController(AdminExtraRepository adminExtraRepository)
        {
            _adminExtraRepository = adminExtraRepository;
        }
        public IActionResult Index()
        {
            ViewBag.CountWaitingAccount = _adminExtraRepository.CountWaitingAccount();

            return View();
        }
    }
}