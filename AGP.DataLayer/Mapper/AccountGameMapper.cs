using AGP.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Mapper
{
    public class AccountGameMapper : IEntityTypeConfiguration<Entities.AccountGame>
    {
        public void Configure(EntityTypeBuilder<AccountGame> builder)
        {
            builder.HasKey(c=>c.Id);


        }
    }
}
