using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Account> Accounts {get;set;}
        public DbSet<AccountProfile> AccountProfiles {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<GameAccount> GameAccounts {get;set;}
        public DbSet<AccountPlatform> AccountPlatforms {get;set;}
        public DbSet<Code> Codes {get;set;}
        public DbSet<Event> Events {get;set;}
        public DbSet<ControllerType> ControllerTypes {get;set;}
        public DbSet<GameControllerType> GameControllerTypes {get;set;}
        public DbSet<Platform> Platforms {get;set;}
        public DbSet<Rating> Ratings {get;set;}
        public DbSet<GameRating> GameRatings {get;set;}

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            // Create All Keys for Manay to Many tables
            ModelBuilder.Entity<GameAccount>().HasKey(ga => new { ga.GameId, ga.AccountId });
            ModelBuilder.Entity<GameControllerType>().HasKey(gc => new { gc.GameId, gc.ControllerTypeId });
            ModelBuilder.Entity<GameRating>().HasKey(gr => new { gr.GameId, gr.RatingId });
            ModelBuilder.Entity<AccountPlatform>().HasKey(ap => new { ap.AccountId, ap.PlatformId });

            // Change Enum vaule to strings
            ModelBuilder.Entity<Rating>().Property(r => r.RatingsSystem).HasConversion<string>();
            ModelBuilder.Entity<Rating>().Property(r => r.RatingsCountry).HasConversion<string>();

            // Create base model
            base.OnModelCreating(ModelBuilder);

            // Use static class for seeded data
            ModelBuilder.SeedGeneralData();
            ModelBuilder.SeedSensitiveData();
        }
    }
}