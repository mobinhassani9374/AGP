using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Infrastructure.Mapping
{
    public static class Initialize
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AccountGameProfile>();
                cfg.AddProfile<TransactionProfile>();
            });
        }
    }
}
