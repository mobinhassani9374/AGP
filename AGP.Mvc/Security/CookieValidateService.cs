using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace AGP.Mvc.Security
{
    public class CookieValidateService
    {
        public async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            var serialNumber = userPrincipal.FindFirst(System.Security.Claims.ClaimTypes.SerialNumber);

            if(serialNumber==null)
            {
                await handleUnauthorizedRequest(context);
                return;
            }
        }
        private Task handleUnauthorizedRequest(CookieValidatePrincipalContext context)
        {
            context.RejectPrincipal();

            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
