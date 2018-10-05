using AGP.DataLayer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Mapper
{
    public class AccountGameMapper : IEntityTypeConfiguration<Domain.Entities.AccountGame>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.AccountGame> builder)
        {
            builder.HasKey(c=>c.Id);

            builder.
                HasOne(c => c.User).
                WithMany(c => c.AccountGames).
                HasForeignKey(c => c.UserId).
                OnDelete(DeleteBehavior
                .Cascade);

            builder.
                HasOne(c => c.Game).
                WithMany(c => c.AccountGames).
                HasForeignKey(c => c.GameId).
                OnDelete(DeleteBehavior
                .Cascade);
        }
    }
}
