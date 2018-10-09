using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace AGP.Mvc.Remark
{
    public static class RemarkUserId
    {
        public static string Build(int? userId)
        {
            if (userId == null) return "";
            var query = $"SELECT [FullName] FROM [Users] WHERE Id={userId}";
            var result = AppSettingProvider.SqlConnection.Query<string>(query).FirstOrDefault();
            return result;
        }
    }
}
