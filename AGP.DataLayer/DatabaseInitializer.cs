using AGP.Utility.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AGP.DataLayer
{
    public class DatabaseInitializer
    {
        private readonly AppDbContext _context;
        public DatabaseInitializer(AppDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            if(!_context.Users.Any())
            {
                var user1 = new Entities.User
                {
                    CreateDate = DateTime.Now,
                    Email = "mobinhassani9374@gmail.com",
                    FullName = "مبین حسنی",
                    IsActive = true,
                    IsAdmin = true,
                    UserName = "mobin",
                    SerialNumber = SerialNumberGenerator.Generate(),
                    Password = PasswordHasher.Hash("2397423974"),
                };
                var user2 = new Entities.User
                {
                    CreateDate = DateTime.Now,
                    Email = "mahdihassani9374@gmail.com",
                    FullName = "مهدی حسنی",
                    IsActive = true,
                    IsAdmin = true,
                    UserName = "mahdi",
                    SerialNumber = SerialNumberGenerator.Generate(),
                    Password = PasswordHasher.Hash("2397423974"),
                };
                _context.Users.Add(user1);
                _context.Users.Add(user2);
                _context.SaveChanges();
            }
        }
    }
}
