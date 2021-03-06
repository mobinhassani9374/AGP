﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AGP.Domain.ViewModel.Game;
using AGP.Domain.ViewModel.AccountGame;
using Microsoft.EntityFrameworkCore;
using AGP.Utility;
using AutoMapper.QueryableExtensions;
using AGP.Domain.Entities;
using AGP.Domain.DTO.AccountGame;

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
            _context.AccountGames.Add(new AccountGame
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                GameId = model.GameId,
                IsActive = true,
                Level = model.Level,
                Price = model.Price,
                State = AccountGameState.Waiting,
                BuyState = AccountGameBuyState.WaitingForBuy,
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
                      BuyState = c.BuyState,
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
                      State = c.State,
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
                .Where(c => c.State == AccountGameState.Waiting)
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

        public bool ExistById(int id)
        {
            var exist = _context.
                AccountGames.
                Any(c => c.Id.Equals(id));

            return exist;
        }

        public bool AccountStateIsWaiting(int id)
        {
            return _context.AccountGames.Any(c => c.Id.Equals(id) && c.State == AccountGameState.Waiting);
        }

        public Utility.ServiceResult Update(AccountGameEditViewModel model)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id == model.Id);

            entity.Description = model.Description;
            entity.Level = model.Level;
            entity.Price = model.Price;

            _context.Update(entity);
            var result = _context.SaveChanges();

            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();

        }

        public AccountGameViewModel GetById(int id)
        {
            var model = _context
               .AccountGames
               .Include(c => c.User)
               .Include(c => c.Game)
               .Where(c => c.Id.Equals(id))
               .ProjectTo<AccountGameViewModel>()
               .FirstOrDefault();

            return model;
        }

        public int GetGameId(int id)
        {
            var gameId = _context.
                  AccountGames.
                  Where(c => c.Id.Equals(id)).
                  Select(c => c.GameId).
                  FirstOrDefault();

            return gameId;
        }

        public ServiceResult DoCancel(int id, string reason)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id == id);
            entity.ReasonForCancel = reason;
            entity.State = AccountGameState.Cancel;

            _context.Update(entity);
            var result = _context.SaveChanges();

            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }

        public ServiceResult DoConfirmed(int id, string imageName)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id == id);
            entity.ImageName = imageName;
            entity.State = AccountGameState.Confirmed;

            _context.Update(entity);
            var result = _context.SaveChanges();

            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }

        public bool IsCreateByUser(int userId, int accountGameId)
        {
            var isCreated = _context.
                AccountGames.
                Any(c => c.UserId == userId && c.Id == accountGameId);

            return isCreated;
        }

        public bool PermisionForDelete(int id)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id.Equals(id));

            var isPermision = true;

            switch (entity.State)
            {
                case AccountGameState.Waiting:
                    {
                        isPermision = false;
                        break;
                    }

                case AccountGameState.Confirmed:
                    {
                        if (entity.BuyState == AccountGameBuyState.Buied && entity.BuyState == AccountGameBuyState.ExistRequest)
                        {
                            isPermision = false;
                        }
                        else
                        {
                            isPermision = true;
                        }
                        break;
                    }
                case AccountGameState.Cancel:
                    {
                        isPermision = true;
                        break;
                    }
            }

            return isPermision;
        }

        public ServiceResult Delete(int id)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id.Equals(id));
            _context.Remove(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }

        public List<AccountGameViewModel> GetAllConfirmed(int pageNumber, int pageSize = 12)
        {
            var model = _context
                .AccountGames
                .Where(c => c.State == AccountGameState.Confirmed)
                .Where(c => c.IsActive)
                .ProjectTo<AccountGameViewModel>()
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return model;
        }

        public int CountConfirmed()
        {
            var count = _context.AccountGames.Where(c => c.State ==
               AccountGameState.Confirmed)
               .Count();

            return count;
        }
        public decimal GetPrice(int id)
        {
            var price = _context.AccountGames.Where(c => c.Id.Equals(id))
                .Select(c => c.Price)
                .FirstOrDefault();

            return price;
        }

        public AccountGameBuyResultDto SetRequestBuy(int id,int userId)
        {
            var entity = _context.AccountGames.FirstOrDefault(c => c.Id == id);
            entity.UserBuyerId = userId;
            entity.BuyState = AccountGameBuyState.ExistRequest;

            _context.Entry(entity).Property(c => c.RowVersion).OriginalValue = entity.RowVersion;

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return AccountGameBuyResultDto.Okay();
            }
            catch
            {
                return AccountGameBuyResultDto.Error();
            }
        }
    }
}
