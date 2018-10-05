using AGP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Mapper
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // id
            builder.HasKey(c=>c.Id);
            // userName
            builder.Property(c => c.UserName).IsRequired().HasMaxLength(100);
            builder.HasIndex(c => c.UserName).IsUnique(true);
            // password 
            builder.Property(c => c.Password).IsRequired().HasMaxLength(150);
            // serialNumber
            builder.Property(c => c.SerialNumber).IsRequired().HasMaxLength(250);
            // fullName
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(250);
            // relation
            builder.HasMany(c => c.LogServices).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
