using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AGP.Domain.Entities;

namespace AGP.DataLayer.Repositories
{
    public class AdminExtraRepository
    {
        private readonly AppDbContext _context;
        public AdminExtraRepository(AppDbContext context)
        {
            _context = context;
        }
        public int CountWaitingAccount()
        {
            var count = _context
                 .AccountGames
                 .Where(c => c.State == AccountGameState.Waiting)
                 .Count();

            return count;
        }
    }
}
