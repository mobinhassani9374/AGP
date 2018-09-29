using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AGP.Domain.ViewModel.Game;
using AGP.Domain.ViewModel.AccountGame;
using Microsoft.EntityFrameworkCore;

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
        public Utility.ServiceResult Create(AccountGameCreateViewModel model)
        {
            _context.AccountGames.Add(new Entities.AccountGame
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                GameId = model.GameId,
                IsActive = true,
                Level = model.Level,
                Price = model.Price,
                State = Entities.AccountGameState.Waiting,
                BuyState = Entities.AccountGameBuyState.WaitingForBuy,
                UserId = model.UserId
            });
            var result = _context.SaveChanges();
            if (result > 0) return Utility.ServiceResult.Okay();
            return Utility.ServiceResult.Error();
        }

        public List<AccountGameViewModel> GetAllByUserId(int userId)
        {
            var model = _context.
                  AccountGames.
                  Include(c => c.Game).
                  Where(c => c.UserId.Equals(userId)).
                  Select(c => new AccountGameViewModel
                  {
                      BuyDate = c.BuyDate,
                      BuyState = (int)c.BuyState,
                      CreateDate = c.CreateDate,
                      Description = c.Description,
                      Id = c.Id,
                      IsActive = c.IsActive,
                      IsDone = c.IsDone,
                      Level = c.Level,
                      Price = c.Price,
                      IsDeActiveByAdmin = c.IsDeActiveByAdmin,
                      ReasonForCancel = c.ReasonForCancel,
                      ReasonForDeActiveByAdmin = c.ReasonForDeActiveByAdmin,
                      State = (int)c.State,
                      RequestDate = c.RequestDate,
                      GameDisplayName = c.Game.DisplayName,
                      GameId = c.GameId,
                      GameName = c.Game.Name
                  }).
                  ToList();

            return model;
        }

        public List<AccountGameViewModel> Waiting()
        {
            var model = _context
                .AccountGames
                .Include(c => c.User)
                .Include(c => c.Game)
                .Where(c => c.State == Entities.AccountGameState.Waiting)
                .Select(c => new AccountGameViewModel
                {
                    Id = c.Id,
                    CreateDate = c.CreateDate,
                    Description = c.Description,
                    GameDisplayName = c.Game.DisplayName,
                    GameName = c.Game.Name,
                    GameId = c.GameId,
                    IsActive = c.IsActive,
                    Level = c.Level,
                    Price = c.Price,
                    UserId = c.UserId,
                    UserFullName = c.User.FullName
                })
                .ToList();

            return model;
        }
    }
}
