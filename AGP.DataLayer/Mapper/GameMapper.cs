﻿using System;
using System.Collections.Generic;
using System.Text;
using AGP.DataLayer.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AGP.DataLayer.Mapper
{
    public class GameMapper : IEntityTypeConfiguration<Domain.Entities.Game>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Game> builder)
        {
            builder.HasKey(c => c.Id);
            // relation
            builder.
                HasMany(c => c.Images).
                WithOne(c => c.Game).
                HasForeignKey(c => c.GameId).
                OnDelete(DeleteBehavior.Cascade);
            //
        }
    }
}
