using AGP.Domain.ViewModel.Transaction;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Transactions;

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
            var entity = AutoMapper.Mapper.Map<Transaction>(model);
            _context.Update(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
    }
}
