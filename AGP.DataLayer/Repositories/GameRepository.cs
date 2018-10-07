using AGP.Domain.ViewModel.Game;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AGP.Domain.Entities;

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
            var entity = new Game
            {
                CreatDate = model.CreatDate,
                DisplayName = model.DisplayName,
                Name = model.Name,
                Images = model.Images.Select(c => new ImageGame
                {
                    ImageName = c.ImageName
                }).ToList()
            };
            _context.Add(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay("یک بازی با موفقیت اضافه شد");
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
            if (result > 0) return ServiceResult.Okay("یک بازی با موفقیت حذف شد");
            return ServiceResult.Error();
        }
        public bool ExistById(int id)
        {
            var exist = _context.Games.Any(c => c.Id == id);

            return exist;
        }
        public List<string> GetImageNames(int id)
        {
            var model = _context.
                ImageGames.
                Where(c => c.GameId == id).
                Select(c => c.ImageName).
                ToList();

            return model;
        }
        public List<ImageGameViewModel> GetImageGames(List<int> imageGameIds)
        {
            var model = _context.
                ImageGames.
                Where(c => imageGameIds.Contains(c.Id)).
                Select(c => new ImageGameViewModel
                {
                    Id = c.Id,
                    ImageName = c.ImageName,
                }).
                ToList();

            return model;
        }
        public ServiceResult DeleteImageGames(List<int> imageGameIds)
        {
            var data = _context.ImageGames.Where(c => imageGameIds.Contains(c.Id)).ToList();

            data.ForEach(c =>
            {
                _context.Remove(c);
            });
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
        public void AddImageGames(int id, List<string> imageNames)
        {
            imageNames.ForEach(c =>
            {
                _context.ImageGames.Add(new ImageGame
                {
                    GameId = id,
                    ImageName = c
                });
            });
            _context.SaveChanges();
        }
        public ServiceResult Update(int id, string name, string displayName)
        {
            var entity = _context.Games.FirstOrDefault(c => c.Id == id);
            entity.Name = name;
            entity.DisplayName = displayName;
            _context.Update(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay("یک بازی با موفقیت ویرایش شد");
            return ServiceResult.Error();
        }
        public List<ImageByCountUseViewModel> GetImagesByCountUse()
        {
            var data = _context.
                AccountGames.
                Where(c => c.State == AccountGameState.Confirmed)
                .GroupBy(c => c.ImageName).
                Select(c => new ImageByCountUseViewModel
                {
                    Count = c.Count(),
                    ImageName = c.Key
                }).
                ToList();

            return data;

        }
    }
}
