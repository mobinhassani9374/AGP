using AGP.Utility.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AGP.Domain.ViewModel.Account;

namespace AGP.DataLayer.Repositories
{
    public class UserManager
    {
        private readonly AppDbContext _context;
        public UserManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<RegisterResultViewModel> CreateAsync(string userName, string password, string fullName)
        {
            var result = new RegisterResultViewModel();
            var serialNumber = SerialNumberGenerator.Generate();
            var user = _context.Users.Add(new Entities.User
            {
                CreateDate = DateTime.Now,
                Email = userName,
                FullName = fullName,
                IsActive = true,
                IsAdmin = false,
                Password = PasswordHasher.Hash(password),
                UserName = userName,
                SerialNumber = serialNumber
            });
            if( await _context.SaveChangesAsync() > 0)
            {
                result.IsSuccess = true;
                result.SerialNumber = serialNumber;
                result.UserId = user.Entity.Id;
            }
            else
            {
                result.IsSuccess = false;
            }
            return result;
        }

        public bool ExistByUserName(string userName)
        {
            return _context.Users.Any(c => c.UserName == userName);
        }
    }
}
