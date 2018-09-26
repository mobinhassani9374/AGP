using AGP.Domain.ViewModel.Game;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
    }
}
