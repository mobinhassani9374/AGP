using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc.Helper
{
    public static class FancyBox
    {
        public static ContentResult CloseAndRedirect(string url)
        {
            var script = 
                $"<script>window.parent.location.href = '{url}';parent.jQuery.fancybox.close(); </script>";

            return new ContentResult() { Content = script, ContentType = "text/html" };
        }
    }
}
