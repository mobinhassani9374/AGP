using AGP.Domain.ViewModel.Game;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AGP.DataLayer.Repositories
{
    public class GameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public ServiceResult Create(GameViewModel model)
        {
            var entity = new Entities.Game
            {
                CreatDate = model.CreatDate,
                DisplayName = model.DisplayName,
                Name = model.Name,
                Images = model.Images.Select(c => new Entities.ImageGame
                {
                    ImageName = c.ImageName
                }).ToList()
            };
            _context.Add(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();

        }
        public List<GameViewModel> GetAll()
        {
            var model = _context.
                Games.
                Include(c => c.Images).
                Select(c => new GameViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DisplayName = c.DisplayName,
                    CreatDate = c.CreatDate,
                    Images = c.Images.Select(cu => new ImageGameViewModel
                    {
                        Id = cu.Id,
                        ImageName = cu.ImageName
                    }).ToList()
                }).
                OrderByDescending(c => c.Id).
                ToList();

            return model;
        }
        public GameViewModel GetById(int id)
        {
            var model = _context.
                Games.
                Include(c => c.Images).
                Select(c => new GameViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DisplayName = c.DisplayName,
                    CreatDate = c.CreatDate,
                    Images = c.Images.Select(cu => new ImageGameViewModel
                    {
                        Id = cu.Id,
                        ImageName = cu.ImageName
                    }).ToList()
                }).
                OrderByDescending(c => c.Id).
                FirstOrDefault(c => c.Id == id);

            return model;
        }
        public ServiceResult Delete(int id)
        {
            var entity = _context.Games.Include(c => c.Images).FirstOrDefault(c => c.Id == id);
            _context.Remove(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
        public bool ExistById(int id)
        {
            var exist = _context.Games.Any(c => c.Id == id);

            return exist;
        }
        public List<string> GetImages(int id)
        {
            var model = _context.
                ImageGames.
                Where(c => c.GameId == id).
                Select(c=>c.ImageName).
                ToList();

            return model;
        }
    }
}
