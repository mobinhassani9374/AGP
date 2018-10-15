using AGP.Domain.ViewModel.Transaction;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Transactions;
using System.Linq;

namespace AGP.DataLayer.Repositories
{
    public class TransacionRepository
    {
        private readonly AppDbContext _context;
        public TransacionRepository(AppDbContext context)
        {
            _context = context;
        }
        public ServiceResult Create(TransactionCreateViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<Domain.Entities.Transaction>(model);
            _context.Add(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
        public ServiceResult Update(TransactionEditViewModel model)
        {
            var oldEntity = _context.Transactions.FirstOrDefault(c => c.id_get.Equals(model.id_get));
            var entity = AutoMapper.Mapper.Map(model, oldEntity);
            _context.Update(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
        public int GetAccountGameId(int id_get)
        {
            var model = _context
                .Transactions
                .Where(c => c.id_get.Equals(id_get))
                .Select(c => c.AccountGameId)
                .FirstOrDefault();

            return model;
        }
        public void UpdateIsSuccess(int id_get, bool value)
        {
            var entity = _context.Transactions.FirstOrDefault(c => c.id_get.Equals(id_get));
            entity.IsSuccess = value;

            _context.Update(entity);

            _context.SaveChanges();
        }
    }
}
