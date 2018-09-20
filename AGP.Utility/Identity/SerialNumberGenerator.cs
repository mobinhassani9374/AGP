using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Utility.Identity
{
    public static class SerialNumberGenerator
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
