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
            var model = _gameRepository.GetAll();

            return View(model);
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

                        fileStream.Close();

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
            var exist = _gameRepository.ExistById(id);
            if (!exist)
            {
                TempData.AddResult(Utility.ServiceResult.Error("آی دی مربوطه وجود ندارد"));

                return RedirectToAction(nameof(Index));
            }
            ViewBag.GameIamgeMaxFileSize = Configuration.GetValue<long>("GameIamgeMaxFileSize", 60);
            var model = _gameRepository.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(GameViewModel model, List<IFormFile> files,
            List<int> deleteImages)
        {
            var gameIamgeMaxFileSize = Configuration.GetValue<long>("GameIamgeMaxFileSize", 60);
            var imageValid = true;
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Length > gameIamgeMaxFileSize)
                {
                    imageValid = false;
                    break;
                }
            }
            if (imageValid)
            {
                // حذف عکس ها 
                var imageGames = _gameRepository.GetImageGames(deleteImages);
                // حذف از دیسک
                imageGames.ForEach(c =>
                {
                    var path = Path.Combine(_env.WebRootPath, "Attachment", c.ImageName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                });
                // حذف از دیتابیس
                _gameRepository.DeleteImageGames(imageGames.Select(c => c.Id).ToList());

                // اضافه نمودن عکس های جدید
                // آپلود عکس های جدید
                List<string> imgagesName = new List<string>();
                files.ForEach(c =>
                {
                    var imageName = $"{Guid.NewGuid()}.{Path.GetExtension(c.FileName)}";

                    var path = Path.Combine(_env.WebRootPath, "Attachment", imageName);

                    var fileStream = new FileStream(path, FileMode.Create);

                    c.CopyTo(fileStream);

                    fileStream.Close();

                    imgagesName.Add(imageName);
                });


                _gameRepository.AddImageGames(model.Id, imgagesName);

                var result = _gameRepository.Update(model.Id, model.Name, model.DisplayName);

                TempData.AddResult(result);
            }
            else
            {
                TempData.AddResult(Utility.ServiceResult.Error($"یک یا چند تا از عکس های انتخاب شده حجمشان بیش از {gameIamgeMaxFileSize} کیلو بایت است"));
            }
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
        public IActionResult Delete(int id)
        {
            var exist = _gameRepository.ExistById(id);
            if (exist)
            {
                // دریافت عکس ها
                var images = _gameRepository.GetImageNames(id);
                // حذف عکس ها
                images.ForEach(c =>
                {
                    var path = Path.Combine(_env.WebRootPath, "Attachment", c);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                });
                var result = _gameRepository.Delete(id);
                TempData.AddResult(result);
            }
            else TempData.AddResult(Utility.ServiceResult.Error("آی دی مربوطه وجود ندارد"));

            return RedirectToAction(nameof(Index));
        }
    }
}