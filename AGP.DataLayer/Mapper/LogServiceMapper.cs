using System;
using System.Collections.Generic;
using System.Text;
using AGP.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AGP.DataLayer.Mapper
{
    public class LogServiceMapper : IEntityTypeConfiguration<Entities.LogService>
    {
        public void Configure(EntityTypeBuilder<LogService> builder)
        {
            builder.HasKey(c=>c.Id);
            builder.Property(c => c.Method).HasMaxLength(10);
        }
    }
}
