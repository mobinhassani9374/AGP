using System;
using System.Collections.Generic;
using System.Text;
using AGP.Domain.Entities;
using AGP.Domain.ViewModel.AccountGame;
using AutoMapper;

namespace AGP.Infrastructure.Mapping
{
    public class AccountGameProfile : Profile
    {
        public AccountGameProfile()
        {
            CreateMap<AccountGame, AccountGameViewModel>();
        }
    }
}
