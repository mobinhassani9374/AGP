using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGP.DataLayer.Entities;
using AGP.Domain.ViewModel.Game;
using AutoMapper;

namespace AGP.Mvc.Mapping
{
    public class GameProfile:Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel, Game>();
        }
    }
}
