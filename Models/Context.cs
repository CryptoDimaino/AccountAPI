using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Account> Accounts {get;set;}
        // public DbSet<AccountProfile> AccountProfiles {get;set;}
        public DbSet<Code> Codes {get;set;}
        public DbSet<ControllerType> ControllerTypes {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<Platform> Platforms {get;set;}
        public DbSet<Rating> Ratings {get;set;}
        public DbSet<RatingType> RatingTypes {get;set;}
        public DbSet<Region> Regions {get;set;}

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);
        }
    }
}