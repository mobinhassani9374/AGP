using AGP.Domain.ViewModel.LogService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AGP.DataLayer.Repositories
{
    public class LogServiceRepository
    {
        private readonly AppDbContext _context;
        public LogServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Log(LogServiceViewModel model)
        {
            var entity = new Entities.LogService
            {
                Method = model.Method,
                QueryString = model.QueryString,
                RelativePath = model.RelativePath,
                RequestContentLength = model.RequestContentLength,
                ResponseContentLength = model.ResponseContentLength,
                RequestIp = model.RequestIp,
                StatusCode = model.StatusCode,
                UserId = model.UserId,
                Elapsed = model.Elapsed,
            };
            _context.LogServices.Add(entity);
            _context.SaveChanges();
        }
    }
}
