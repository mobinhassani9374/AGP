using System;
using System.Collections.Generic;
using System.Text;
using AGP.Domain.ViewModel.Transaction;
using AutoMapper;

namespace AGP.Infrastructure.Mapping
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionCreateViewModel, Domain.Entities.Transaction>();
        }
    }
}
