using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AGP.Mvc.Middleware
{
    public class LogServiceMiddleware
    {
        private readonly RequestDelegate Next;
        public LogServiceMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await Next(context);
        }
    }
}
