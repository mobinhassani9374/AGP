using AGP.Domain.ViewModel.UserAccountGame;
using AGP.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AGP.DataLayer.Migrations;

namespace AGP.DataLayer.Repositories
{
    public class UserAccountGameRepository
    {
        private readonly AppDbContext _context;
        public UserAccountGameRepository(AppDbContext context)
        {
            _context = context;
        }
        public ServiceResult Create(UserAccountGameCreateViewModel model)
        {
            var entity = AutoMapper.Mapper.Map<Domain.Entities.UserAccountGame>(model);
            _context.Add(entity);
            var result = _context.SaveChanges();
            if (result > 0) return ServiceResult.Okay();
            return ServiceResult.Error();
        }
    }
}
