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
        public DbSet<Code> Codes {get;set;}
        public DbSet<ControllerType> ControllerTypes {get;set;}
        public DbSet<Game> Games {get;set;}
        public DbSet<Platform> Platforms {get;set;}
        public DbSet<PlatformType> PlatformTypes {get;set;}
        public DbSet<Rating> Ratings {get;set;}
        public DbSet<Region> Regions {get;set;}

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            

            ModelBuilder.Entity<Code>().HasIndex(c => c.CodeString).IsUnique();

            ModelBuilder.Entity<GameAccount>().HasKey(ga => new { ga.GameId, ga.AccountId });
            ModelBuilder.Entity<GameControllerType>().HasKey(gc => new { gc.GameId, gc.ControllerTypeId });
            ModelBuilder.Entity<GamePlatform>().HasKey(gp => new { gp.GameId, gp.PlatformId });
            ModelBuilder.Entity<GameRating>().HasKey(gr => new { gr.GameId, gr.RatingId });

            ModelBuilder.Entity<Rating>().Property(r => r.RatingsSystem).HasConversion<string>();
            ModelBuilder.Entity<Rating>().Property(r => r.RatingsCountry).HasConversion<string>();

            base.OnModelCreating(ModelBuilder);

            // PlatformType
            ModelBuilder.Entity<PlatformType>().HasData(
                new PlatformType() { PlatformTypeId = 1, Name = "Game", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new PlatformType() { PlatformTypeId = 2, Name = "Other", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // Platform
            ModelBuilder.Entity<Platform>().HasData(
                new Platform() {PlatformId = 1, Name = "Steam", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 2, Name = "Microsoft Store", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 3, Name = "Windows", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 4, Name = "Android", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 5, Name = "Steam VR", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 6, Name = "Oculus", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 7, Name = "Origin", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 8, Name = "Uplay", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 9, Name = "Epic", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 10, Name = "Standalone", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 11, Name = "Maniaplenet", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 12, Name = "Play Station", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 13, Name = "BattleNet", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 14, Name = "Lego Mini Online", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 15, Name = "League of Legends", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 16, Name = "Intel Appup", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 17, Name = "Cryptic Studios", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 18, Name = "Amazon", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 19, Name = "McAfee LiveSafe", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 20, Name = "Eve Online", PlatformTypeId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 21, Name = "Apple", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 22, Name = "QQ", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 23, Name = "Media Accounts", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Platform() {PlatformId = 24, Name = "Twitch", PlatformTypeId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            );

            // ControllerType
            ModelBuilder.Entity<ControllerType>().HasData(
                new ControllerType() {ControllerTypeId = 1, Type = "Touch", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new ControllerType() {ControllerTypeId = 2, Type = "Keyboard & Mouse", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new ControllerType() {ControllerTypeId = 3, Type = "Xbox", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new ControllerType() {ControllerTypeId = 4, Type = "Steering Wheel", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            );

            // Event
            ModelBuilder.Entity<Event>().HasData(
                new Event() {EventId = 1, Name = "IEM", Location = "Chicago", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            );

            // Rating
            ModelBuilder.Entity<Rating>().HasData(
                new Rating() { RatingId = 1, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Early Childhood", Definition = "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 2, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Everyone", Definition = "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 3, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Everyone 10+", Definition = "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 4, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Teen", Definition = "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 5, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Mature", Definition = "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 6, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Adults Only 18+", Definition = "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 7, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Rating Pending", Definition = "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                
                new Rating() { RatingId = 8, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 3", Definition = "The content of games with a PEGI 3 rating is considered suitable for all age groups. The game should not contain any sounds or pictures that are likely to frighten young children. A very mild form of violence (in a comical context or a childlike setting) is acceptable. No bad language should be heard.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 9, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 7", Definition = "Game content with scenes or sounds that can possibly frightening to younger children should fall in this category. Very mild forms of violence (implied, non-detailed, or non-realistic violence) are acceptable for a game with a PEGI 7 rating.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 10, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 12", Definition = "Video games that show violence of a slightly more graphic nature towards fantasy characters or non-realistic violence towards human-like characters would fall in this age category. Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present (e.g. card games that in real life would be played for money).", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 11, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 16", Definition = "This rating is applied once the depiction of violence (or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol or illegal drugs can also be present.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 12, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 18", Definition = "The adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenceless characters. The glamorisation of the use of illegal drugs and explicit sexual activity should also fall into this age category.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                
                // https://commons.wikimedia.org/wiki/Category:RARS_classification_by_age
                new Rating() { RatingId = 13, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "0+", Definition = "Any age", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 14, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "6+", Definition = "The age 6 and older", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 15, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "12+", Definition = "The age 12 and older", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 16, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "16+", Definition = "The age 16 and older", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 17, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "18+", Definition = "The age 18 and older", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
    
                new Rating() { RatingId = 18, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Exempt from classification", Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 19, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "General", Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 20, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Parental Guidance", Definition = "Not recommended for viewing or playing by people under 15 without guidance from parents or guardians. Contains material that young viewers may find confusing or upsetting. The content is mild in impact.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 21, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Mature", Definition = "Recommended for people aged 15 years and over. People under 15 may legally access this material because it is an advisory category. This category contains material that may require a mature perspective, but is not deemed too strong for younger viewers. The content is moderate in impact, although the Moderate indicator prefix is no longer used in the consumer advice, eg. Moderate violence is referred to as Violence.", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 22, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Mature Accompanied", Definition = "", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 23, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Restricted R", Definition = "", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 24, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Restricted X", Definition = "", ImageLink = "Link to image", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },

            );
        }
    }
}