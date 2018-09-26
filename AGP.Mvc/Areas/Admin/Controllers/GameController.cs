using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AGP.Domain.ViewModel.Game;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AGP.DataLayer.Repositories;
using AGP.Mvc.ExtensionMethods;

namespace AGP.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private IConfigurationRoot Configuration { get; set; }
        private readonly IHostingEnvironment _env;
        private readonly GameRepository _gameRepository;
        public GameController(IConfigurationRoot configuration,
            IHostingEnvironment env,
            GameRepository gameRepository)
        {
            Configuration = configuration;
            _env = env;
            _gameRepository = gameRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.GameIamgeMaxFileSize = Configuration.GetValue<long>("GameIamgeMaxFileSize", 60);
            return View();
        }
        [HttpPost]
        public IActionResult Create(GameCreateViewModel model, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var gameIamgeMaxFileSize = Configuration.GetValue<long>("GameIamgeMaxFileSize", 60);
                // validation for Image
                var imageValid = true;
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i].Length > gameIamgeMaxFileSize)
                    {
                        imageValid = false;
                        break;
                    }
                }
                if (!imageValid) ModelState.AddModelError("imageSize", $"یک یا چند تا از عکس های انتخاب شده حجمشان بیش از {gameIamgeMaxFileSize} کیلو بایت است");
                else
                {
                    // upload images
                    List<string> imgagesName = new List<string>();

                    files.ForEach(c =>
                    {
                        var imageName = $"{Guid.NewGuid()}.{Path.GetExtension(c.FileName)}";

                        var path = Path.Combine(_env.WebRootPath, "Attachment", imageName);

                        var fileStream = new FileStream(path, FileMode.Create);

                        c.CopyTo(fileStream);

                        imgagesName.Add(imageName);
                    });
                    // insert db
                    // insert in db
                    var result = _gameRepository.Create(new GameViewModel
                    {
                        CreatDate = DateTime.Now,
                        DisplayName = model.DisplayName,
                        Name = model.Name,
                        Images = imgagesName.Select(cu => new ImageGameViewModel
                        {
                            ImageName = cu
                        }).ToList()
                    });

                    TempData.AddResult(result);

                    return RedirectToAction(nameof(Create));
                }

            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}