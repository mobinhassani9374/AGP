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
        public DbSet<Entities.Game> Games { get; set; }
        public DbSet<Entities.ImageGame> ImageGames { get; set; }
        public DbSet<Entities.AccountGame> AccountGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // userMapper
            modelBuilder.ApplyConfiguration(new Mapper.UserMapper());
            modelBuilder.ApplyConfiguration(new Mapper.LogServiceMapper());
            modelBuilder.ApplyConfiguration(new Mapper.GameMapper());
            modelBuilder.ApplyConfiguration(new Mapper.ImageGameMapper());
            modelBuilder.ApplyConfiguration(new Mapper.AccountGameMapper());
        }
    }
}
