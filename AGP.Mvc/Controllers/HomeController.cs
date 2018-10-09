using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AGP.DataLayer.Repositories;
using System.Net.Http;
using Microsoft.Extensions.Options;
using AGP.Domain.DTO;

namespace AGP.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountGameRepository _accountGameRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<BitPayConfig> _bitPayConfig;
        public HomeController(AccountGameRepository accountGameRepository)
        {
            _accountGameRepository = accountGameRepository;

        }
        public IActionResult Index(int page = 1)
        {
            var model = _accountGameRepository.GetAllConfirmed(page, 12);

            var countAll = _accountGameRepository.CountConfirmed();

            ViewBag.CurrentPage = page;

            var totalPages = countAll / 12;
            if (countAll % 12 != 0) totalPages++;

            if (page <= 0 || page > totalPages)
                ViewBag.CurrentPage = 1;

            ViewBag.TotalPages = totalPages;

            return View(model);
        }

        public IActionResult AboutUs()
        {

            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}