using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AccountAPI;
using AccountAPI.Models;

namespace AccountAPI
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder ModelBuilder)
        {
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
                new Event() {EventId = 1, Name = "IEM", Location = "Chicago", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Event() {EventId = 2, Name = "IEM", Location = "Austraila", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Event() {EventId = 3, Name = "IEM", Location = "China", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                new Event() {EventId = 4, Name = "IEM", Location = "Poland", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            );

            // Rating
            ModelBuilder.Entity<Rating>().HasData(
                new Rating() { RatingId = 1, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Early Childhood", Age = 3, Definition = "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.", ImageLink = "client/images/ESRB/eC.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 2, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Everyone", Age = 6, Definition = "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.", ImageLink = "client/images/ESRB/E.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 3, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Everyone 10+", Age = 10, Definition = "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.", ImageLink = "client/images/ESRB/E10.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 4, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Teen", Age = 13, Definition = "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.", ImageLink = "client/images/ESRB/T.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 5, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Mature", Age = 17, Definition = "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", ImageLink = "client/images/ESRB/M.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 6, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Adults Only 18+", Age = 18, Definition = "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", ImageLink = "client/images/ESRB/Ao.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 7, RatingsSystem = Rating.RatingSystem.ESRB, RatingsCountry = Rating.Country.USA, Name = "Rating Pending", Age = -1, Definition = "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)", ImageLink = "client/images/ESRB/RP.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 8, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 3", Age = 3, Definition = "The content of games with a PEGI 3 rating is considered suitable for all age groups. The game should not contain any sounds or pictures that are likely to frighten young children. A very mild form of violence (in a comical context or a childlike setting) is acceptable. No bad language should be heard.", ImageLink = "client/images/PEGI/3.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 9, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 7", Age = 7, Definition = "Game content with scenes or sounds that can possibly frightening to younger children should fall in this category. Very mild forms of violence (implied, non-detailed, or non-realistic violence) are acceptable for a game with a PEGI 7 rating.", ImageLink = "client/images/PEGI/7.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 10, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 12", Age = 12, Definition = "Video games that show violence of a slightly more graphic nature towards fantasy characters or non-realistic violence towards human-like characters would fall in this age category. Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present (e.g. card games that in real life would be played for money).", ImageLink = "client/images/PEGI/12.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 11, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 16", Age = 16, Definition = "This rating is applied once the depiction of violence (or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol or illegal drugs can also be present.", ImageLink = "client/images/PEGI/16.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 12, RatingsSystem = Rating.RatingSystem.PEGI, RatingsCountry = Rating.Country.EU, Name = "PEGI 18", Age = 18, Definition = "The adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenceless characters. The glamorisation of the use of illegal drugs and explicit sexual activity should also fall into this age category.", ImageLink = "client/images/PEGI/18.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },           
                new Rating() { RatingId = 13, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "0+", Age = 0, Definition = "Any age", ImageLink = "client/images/RARS/0+.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 14, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "6+", Age = 6, Definition = "The age 6 and older", ImageLink = "client/images/RARS/6+.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 15, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "12+", Age = 12, Definition = "The age 12 and older", ImageLink = "client/images/RARS/12+.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 16, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "16+", Age = 16, Definition = "The age 16 and older", ImageLink = "client/images/RARS/16+.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 17, RatingsSystem = Rating.RatingSystem.RARS, RatingsCountry = Rating.Country.Russia, Name = "18+", Age = 18, Definition = "The age 18 and older", ImageLink = "client/images/RARS/18+.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 18, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Exempt from classification", Age = 0, Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", ImageLink = "client/images/ACB/E.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 19, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "General", Age = 0, Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", ImageLink = "client/images/ACB/General.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 20, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Parental Guidance", Age = 8, Definition = "Not recommended for viewing or playing by people under 15 without guidance from parents or guardians. Contains material that young viewers may find confusing or upsetting. The content is mild in impact.", ImageLink = "client/images/ACB/PG.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 21, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Mature", Age = 15, Definition = "Recommended for people aged 15 years and over. People under 15 may legally access this material because it is an advisory category. This category contains material that may require a mature perspective, but is not deemed too strong for younger viewers. The content is moderate in impact, although the Moderate indicator prefix is no longer used in the consumer advice, eg. Moderate violence is referred to as Violence.", ImageLink = "client/images/ACB/M.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 22, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Mature Accompanied", Age = 15, Definition = "Contains material that is considered unsuitable for exhibition by persons under the age of 15. People under 15 may legally purchase, rent, exhibit or view such content only under the supervision of a parent or adult guardian. A person may be asked to show proof of age before renting or purchasing an MA 15+ film or computer game. The content is strong in impact.", ImageLink = "client/images/ACB/MA.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 23, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Restricted R", Age = 18, Definition = "Contains material that is considered unsuitable for exhibition to persons under the age of 18. People under 18 may not legally buy, rent, exhibit or view R 18+ classified content. A person may be asked for proof of their age before purchasing, hiring or viewing an R 18+ film or computer game at a retail store or cinema. Some material classified R 18+ may be offensive to sections of the adult community. The content is high in impact.", ImageLink = "client/images/ACB/R18.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 24, RatingsSystem = Rating.RatingSystem.ACB, RatingsCountry = Rating.Country.Australia, Name = "Restricted X", Age = 18, Definition = "Contains material that is pornographic in nature. People under 18 may not legally buy, rent, possess, exhibit or view these films. The exhibition or sale of these films to people under the age of 18 years is a criminal offence carrying a maximum fine of $5,500. Films classified as X 18+ are banned (via state government legislation) from being sold or rented in all Australian states (but are legal to possess except in certain parts of the Northern Territory) and are legally available to purchase only in the Australian Capital Territory and the Northern Territory. Importing X 18+ material from these territories to any other state is legal (as the Australian Constitution forbids any restrictions on trade between the states and territories). The content is sexually explicit, and the rating does not exist for video games.", ImageLink = "client/images/ACB/X18.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 25, RatingsSystem = Rating.RatingSystem.USK, RatingsCountry = Rating.Country.Germany, Name = "0", Age = 0, Definition = "Approved without age restriction in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games without age restriction are games which are directly aimed at children and young persons as well as at an adult buyer group.", ImageLink = "client/images/USK/0.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 26, RatingsSystem = Rating.RatingSystem.USK, RatingsCountry = Rating.Country.Germany, Name = "6", Age = 6, Definition = "Approved for children aged 6 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games mostly involve family-friendly games which may be more exciting and competitive (e.g. via faster game speeds and more complex tasks).", ImageLink = "client/images/USK/6.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 27, RatingsSystem = Rating.RatingSystem.USK, RatingsCountry = Rating.Country.Germany, Name = "12", Age = 12, Definition = "Approved for children aged 12 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games feature much more of a competitive edge. Game scenarios contain little violence, enabling players to distance themselves sufficiently from events.", ImageLink = "client/images/USK/12.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 28, RatingsSystem = Rating.RatingSystem.USK, RatingsCountry = Rating.Country.Germany, Name = "16", Age = 16, Definition = "Approved for children aged 16 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games approved for children aged 16 and above may include acts of violence. This means that it is also natural for adults to buy them.", ImageLink = "client/images/USK/16.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Rating() { RatingId = 29, RatingsSystem = Rating.RatingSystem.USK, RatingsCountry = Rating.Country.Germany, Name = "18", Age = 18, Definition = "Not approved for anyone under 18 in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games almost always involve violent game concepts and frequently generate a dark and threatening atmosphere. This makes them suitable for adults only. These games often contain brutal, strong bloody violence and/or glorify war and/or human rights violations.", ImageLink = "client/images/USK/18.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );
        
            // Game
            ModelBuilder.Entity<Game>().HasData(
                new Game() { GameId = 1, Name = "Virtua Tennis 4", ConnectionType = 2, ReleaseDate = new DateTime(2011, 4, 29), URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 },
                new Game() { GameId = 2, Name = "Portal 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 },
                new Game() { GameId = 3, Name = "Rage", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 4, Name = "F1 Racing 2011", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 5, Name = "Shogun 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 6, Name = "Operation Flashpoint Red River", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 7, Name = "Batman Arkham City", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 8, Name = "Modern Warfare 3", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 9, Name = "Skyrim", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 10, Name = "Renegade Ops", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 11, Name = "Defense Grid", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 12, Name = "Limbo", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 13, Name = "Call of Duty: Black Ops 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 14, Name = "Dishonored", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 15, Name = "Deep Black: Reloaded", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 16, Name = "Civilization 5", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 17, Name = "Command & Conquer 4: Tiberian Twilight", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 18, Name = "Lego: The Lord of the Rings", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 19, Name = "Transformers: Fal of Cybertron", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 20, Name = "Grid 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 21, Name = "Sega and Sonic All Stars Transformed", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 22, Name = "Sega and Sonic All Stars Transformed", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 23, Name = "Civilization 5: Brave New World", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 24, Name = "ArmA3", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 25, Name = "Broken Age", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 26, Name = "Shadowrun Returns", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 27, Name = "Shadowrun: Dragonfall", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 28, Name = "Trine 2 Complete", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 29, Name = "Grid Autosport", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 30, Name = "Beat Buddy: Tale of te Guardians", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 31, Name = "Transistor", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 32, Name = "Borderlands: The Pre-Sequel Preorder", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 33, Name = "Alien Isolation", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 34, Name = "Counter Strike: Global Offensive", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 35, Name = "Lara Croft Temple of Osiris", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 36, Name = "Tomb Raider (2013)", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 37, Name = "F1 2015", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 38, Name = "Homeworld Remastered Collection", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 39, Name = "Euro Truck Simulator", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 40, Name = "Project Cars", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 41, Name = "Just Cause 3", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 42, Name = "NBA2K16", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 43, Name = "Rocket League", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 44, Name = "Warhammer Vermintide", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 45, Name = "Tom Clancy's Rainbow Six Siege", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 46, Name = "Grey Goo", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 47, Name = "PES 2017", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 48, Name = "Project Cars 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 49, Name = "PUBG", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 50, Name = "Total War: Warhammer 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 51, Name = "Lego Marvel Super Heroes 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 52, Name = "Call of Duty World War II", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 53, Name = "Warrhammer: Vermintide 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 54, Name = "Cuphead", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 55, Name = "Yooka Laylee", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 56, Name = "NBA 2K18", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 57, Name = "Sinner: BETA Testing", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 58, Name = "NBA 2k19", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 59, Name = "Hitman 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 60, Name = "Just Cause 4", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 61, Name = "Ring of Elysium", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 62, Name = "Street Fighter 5", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 63, Name = "Resident Evil 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 64, Name = "Outward", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 65, Name = "Tekken 7", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 66, Name = "Soul Calibur 6", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 67, Name = "Dragon Ball FighterZ", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 68, Name = "DOTA 2", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 69, Name = "Ace Combat 7: Skies Unknown", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
                new Game() { GameId = 70, Name = "Sekiro: Shadows Die Twice", ConnectionType = 2, ReleaseDate = DateTime.Now, URLToDocumentation = "Location to Doc", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PlatformId = 1 }
            );
            // Account
            ModelBuilder.Entity<Account>().HasData(
                new Account() { AccountId = 1, Name = "Demodepotna01", Password = "Password1", CheckedOutStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EventId = 1 },
                new Account() { AccountId = 2, Name = "Demodepotna02", Password = "Password1", CheckedOutStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EventId = 1 },
                new Account() { AccountId = 3, Name = "Demodepotna03", Password = "Password1", CheckedOutStatus = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, EventId = 2 }
            );
            // Code
            ModelBuilder.Entity<Code>().HasData(
                new Code() { CodeId = 1, CodeString = "Some Code 1", UsedStatus = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = 1, GameId = 1 },
                new Code() { CodeId = 2, CodeString = "Some Code 2", UsedStatus = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = 1, GameId = 2},
                new Code() { CodeId = 3, CodeString = "Some Code 3", UsedStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = null, GameId = 1 },
                new Code() { CodeId = 4, CodeString = "Some Code 4", UsedStatus = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = 2, GameId = 1 },
                new Code() { CodeId = 5, CodeString = "Some Code 5", UsedStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = null, GameId = 2 },
                new Code() { CodeId = 6, CodeString = "Some Code 6", UsedStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = null, GameId = 3 },
                new Code() { CodeId = 7, CodeString = "Some Code 7", UsedStatus = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = 3, GameId = 3 },
                new Code() { CodeId = 8, CodeString = "Some Code 8", UsedStatus = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, AccountId = null, GameId = 1 }
            );

            // Account Profile
            ModelBuilder.Entity<AccountProfile>().HasData(
                new AccountProfile() { AccountProfileId = 1, FirstName = "Demo", LastName = "Depot", Email = "aaosd@daosp.asd", Password = "asd", Birthday = DateTime.Now, PhoneNumber = "", Address = null, SecretQuestion1 = null, SecretQuestion2 = null, SecretQuestion3 = null, SecretAnswer1 = null, SecretAnswer2 = null, SecretAnswer3 = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new AccountProfile() { AccountProfileId = 2, FirstName = "Demo 1", LastName = "Depot", Email = "aaosd@daosp.asd", Password = "asd", Birthday = DateTime.Now, PhoneNumber = "", Address = null, SecretQuestion1 = null, SecretQuestion2 = null, SecretQuestion3 = null, SecretAnswer1 = null, SecretAnswer2 = null, SecretAnswer3 = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new AccountProfile() { AccountProfileId = 3, FirstName = "Demo 2", LastName = "Depot", Email = "aaosd@daosp.asd", Password = "asd", Birthday = DateTime.Now, PhoneNumber = "", Address = null, SecretQuestion1 = null, SecretQuestion2 = null, SecretQuestion3 = null, SecretAnswer1 = null, SecretAnswer2 = null, SecretAnswer3 = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );


            // Game Controller Type
            ModelBuilder.Entity<GameControllerType>().HasData(
                new GameControllerType() { GameId = 1, ControllerTypeId = 1 },
                new GameControllerType() { GameId = 1, ControllerTypeId = 2 },
                new GameControllerType() { GameId = 2, ControllerTypeId = 1 },
                new GameControllerType() { GameId = 2, ControllerTypeId = 2 },
                new GameControllerType() { GameId = 2, ControllerTypeId = 3 },
                new GameControllerType() { GameId = 3, ControllerTypeId = 1 }
            );


            // Game Rating
            ModelBuilder.Entity<GameRating>().HasData(
                new GameRating() { GameId = 1, RatingId = 1 },
                new GameRating() { GameId = 1, RatingId = 4 },
                new GameRating() { GameId = 2, RatingId = 8 },
                new GameRating() { GameId = 2, RatingId = 10 },
                new GameRating() { GameId = 2, RatingId = 2 }
            );


            // Account Platform
            ModelBuilder.Entity<AccountPlatform>().HasData(
                new AccountPlatform() { AccountId = 1, PlatformId = 1 },
                new AccountPlatform() { AccountId = 1, PlatformId = 2 },
                new AccountPlatform() { AccountId = 1, PlatformId = 3 },
                new AccountPlatform() { AccountId = 2, PlatformId = 4 },
                new AccountPlatform() { AccountId = 2, PlatformId = 5 }
            );

            // Game Account
            ModelBuilder.Entity<GameAccount>().HasData(
                new GameAccount() { GameId = 1, AccountId = 1 },
                new GameAccount() { GameId = 2, AccountId = 1 },
                new GameAccount() { GameId = 3, AccountId = 1 },
                new GameAccount() { GameId = 3, AccountId = 2 },
                new GameAccount() { GameId = 1, AccountId = 2 },
                new GameAccount() { GameId = 2, AccountId = 2 }
            );
        }
    }
}