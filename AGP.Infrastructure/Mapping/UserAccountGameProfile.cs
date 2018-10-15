using System;
using System.Collections.Generic;
using System.Text;
using AGP.DataLayer.Migrations;
using AGP.Domain.ViewModel.UserAccountGame;
using AutoMapper;

namespace AGP.Infrastructure.Mapping
{
    public class UserAccountGameProfile:Profile
    {
        public UserAccountGameProfile()
        {
            CreateMap<UserAccountGameCreateViewModel, Domain.Entities.UserAccountGame>();
        }
    }
}
