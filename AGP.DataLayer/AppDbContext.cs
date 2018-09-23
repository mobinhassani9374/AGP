using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AGP.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.LogService> LogServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // userMapper
            modelBuilder.ApplyConfiguration(new Mapper.UserMapper());
        }
    }
}
