using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Repositories
{
    public class UserAccountGameRepository
    {
        private readonly AppDbContext _context;
        public UserAccountGameRepository(AppDbContext context)
        {
            _context= context;
        }
    }
}
