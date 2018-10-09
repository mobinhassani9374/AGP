using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc.Remark
{
    public static class RemarkUserId
    {
        public static string Build(int? userId)
        {
            if (userId == null) return "";
            return "مبین حسنی";
        }
    }
}
