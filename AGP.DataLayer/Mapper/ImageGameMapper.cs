using System;
using System.Collections.Generic;
using System.Text;
using AGP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AGP.DataLayer.Mapper
{
    public class ImageGameMapper : IEntityTypeConfiguration<ImageGame>
    {
        public void Configure(EntityTypeBuilder<ImageGame> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
