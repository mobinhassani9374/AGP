﻿using AGP.Utility.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AGP.DataLayer.Repositories
{
    public class UserManager
    {
        private readonly AppDbContext _context;
        public UserManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(string userName, string password, string fullName)
        {
            _context.Users.Add(new Entities.User
            {
                CreateDate = DateTime.Now,
                Email = userName,
                FullName = fullName,
                IsActive = true,
                IsAdmin = false,
                Password = PasswordHasher.Hash(password),
                UserName = userName,
                SerialNumber = SerialNumberGenerator.Generate()
            });
            return await _context.SaveChangesAsync() > 0;
        }

        public bool ExistByUserName(string userName)
        {
            return _context.Users.Any(c => c.UserName == userName);
        }
    }
}
