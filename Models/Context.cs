using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AccountAPI.SeedData;

namespace AccountAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Account> Accounts {get;set;}
        public DbSet<Code> Codes {get;set;}
        public DbSet<EmailAccount> EmailAccounts {get;set;}
        public DbSet<Event> Events {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<Platform> Platforms {get;set;}

        // Extra
        // public DbSet<Rating> Ratings {get;set;}
        // public DbSet<GameRating> GameRatings {get;set;}


        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            // Make sure each Email is unique
            ModelBuilder.Entity<EmailAccount>().HasIndex(ea => ea.Email).IsUnique();

            // Create All Keys for Manay to Many tables
            // ModelBuilder.Entity<Account>().Property(a => a.AccountId).ValueGeneratedOnAdd();
            ModelBuilder.Entity<Account>().HasKey(a => new { a.EmailAccountId, a.PlatformId });

            // ModelBuilder.Entity<GameRating>().HasKey(gr => new { gr.GameId, gr.RatingId });


            // Change Enum vaule to strings
            // ModelBuilder.Entity<Rating>().Property(r => r.RatingsSystem).HasConversion<string>();
            // ModelBuilder.Entity<Rating>().Property(r => r.RatingsCountry).HasConversion<string>();

            // Create base model
            base.OnModelCreating(ModelBuilder);

            // Use static class for seeded data
            ModelBuilder.AccountSeedData();
            ModelBuilder.CodeSeedData();
            ModelBuilder.EmailAccountSeedData();
            ModelBuilder.EventSeedData();
            ModelBuilder.GameSeedData();
            ModelBuilder.PlatformSeedData();
            // ModelBuilder.RatingSeedData();
            // ModelBuilder.GameRatingSeedData();
        }
    }
}