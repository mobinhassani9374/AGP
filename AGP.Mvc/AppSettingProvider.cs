using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc
{
    public static class AppSettingProvider
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection SqlConnection = new SqlConnection(ConnectionString);
    }
}
