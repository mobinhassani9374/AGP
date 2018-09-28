using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AGP.Domain.ViewModel.Game;

namespace AGP.DataLayer.Repositories
{
    public class AccountGameRepository
    {
        private readonly AppDbContext _context;
        public AccountGameRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<GameViewModel> GetAllGames()
        {
            var model = _context.
                Games.
                Select(c => new GameViewModel
                {
                    DisplayName = c.DisplayName,
                    Id = c.Id,
                    Name = c.Name
                }).
                ToList();

            return model;

        }
    }
}
