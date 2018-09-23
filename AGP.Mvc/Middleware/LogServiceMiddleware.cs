using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AGP.Domain.ViewModel.LogService;
using Microsoft.AspNetCore.Http;
using AGP.Mvc.Security;
using AGP.DataLayer.Repositories;

namespace AGP.Mvc.Middleware
{
    public class LogServiceMiddleware
    {
        private readonly RequestDelegate Next;
        public LogServiceMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task Invoke(HttpContext context, LogServiceRepository logServiceRepository)
        {
            int? userId = null;
            LogServiceViewModel logModel = new LogServiceViewModel();
            logModel.RelativePath = context.Request.Path.Value.ToLower();
            logModel.Method = context.Request.Method;
            logModel.QueryString = context.Request.QueryString.Value;
            logModel.RequestContentLength = context.Request.ContentLength;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await Next(context);
            stopwatch.Stop();
            logModel.Elapsed = stopwatch.Elapsed;
            logModel.ResponseContentLength = context.Response.ContentLength;
            logModel.StatusCode = context.Response.StatusCode;
            logModel.RequestIp = context.Connection.RemoteIpAddress.ToString();
            if (context.User.Identity.IsAuthenticated)
                userId = context.User.GetUserId();

            logModel.UserId = userId;
            logServiceRepository.Log(logModel);
        }
    }
}
