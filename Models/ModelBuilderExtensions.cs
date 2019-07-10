using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AccountAPI;
using AccountAPI.Models;

namespace AccountAPI 
{
    	public static class ModelBuilderExtensions 
        {
		public static void SeedGeneralData(this ModelBuilder ModelBuilder) 
        {
			// Platform
			ModelBuilder.Entity<Platform>().HasData(
			new Platform() 
            {
				PlatformId = 1,
				Name = "Steam",
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Steam Installation and Setup - BKM.docx",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 2,
				Name = "Microsoft Store",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 3,
				Name = "Android",
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Android/Android Game Installation Guide BKM.docx",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 4,
				Name = "Steam VR",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 5,
				Name = "Oculus",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 6,
				Name = "Origin",
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/Game Client Installation and Usage Guide - Origin Software.docx",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 7,
				Name = "Uplay",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 8,
				Name = "Epic",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 9,
				Name = "Standalone",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 10,
				Name = "Playsation",
				URLToDocumentation = null,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 11,
				Name = "BattleNet",
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Battle Net Client - BKM.docx",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Platform() 
            {
				PlatformId = 12,
				Name = "Intel Appup",
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Install and Use Guide - Intel AppUp.docx",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			});

			// ControllerType
			ModelBuilder.Entity<ControllerType>().HasData(
			new ControllerType() 
            {
				ControllerTypeId = 1,
				Type = "Touch",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new ControllerType() 
            {
				ControllerTypeId = 2,
				Type = "Keyboard & Mouse",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new ControllerType() 
            {
				ControllerTypeId = 3,
				Type = "Xbox",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new ControllerType() 
            {
				ControllerTypeId = 4,
				Type = "Steering Wheel",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			});

			// Event
			ModelBuilder.Entity<Event>().HasData(
			new Event() 
            {
				EventId = 1,
				Name = "IEM",
				Location = "Chicago",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Event() 
            {
				EventId = 2,
				Name = "IEM",
				Location = "Austraila",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Event() 
            {
				EventId = 3,
				Name = "IEM",
				Location = "China",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Event() 
            {
				EventId = 4,
				Name = "IEM",
				Location = "Poland",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			});

			// Rating
			ModelBuilder.Entity<Rating>().HasData(
			new Rating() 
            {
				RatingId = 1,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Early Childhood",
				Age = 3,
				Definition = "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.",
				ImageLink = "client/images/ESRB/eC.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 2,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Everyone",
				Age = 6,
				Definition = "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.",
				ImageLink = "client/images/ESRB/E.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 3,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Everyone 10+",
				Age = 10,
				Definition = "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.",
				ImageLink = "client/images/ESRB/E10.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 4,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Teen",
				Age = 13,
				Definition = "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.",
				ImageLink = "client/images/ESRB/T.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 5,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Mature",
				Age = 17,
				Definition = "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.",
				ImageLink = "client/images/ESRB/M.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 6,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Adults Only 18+",
				Age = 18,
				Definition = "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.",
				ImageLink = "client/images/ESRB/Ao.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 7,
				RatingsSystem = Rating.RatingSystem.ESRB,
				RatingsCountry = Rating.Country.USA,
				Name = "Rating Pending",
				Age = -1,
				Definition = "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)",
				ImageLink = "client/images/ESRB/RP.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 8,
				RatingsSystem = Rating.RatingSystem.PEGI,
				RatingsCountry = Rating.Country.EU,
				Name = "PEGI 3",
				Age = 3,
				Definition = "The content of games with a PEGI 3 rating is considered suitable for all age groups. The game should not contain any sounds or pictures that are likely to frighten young children. A very mild form of violence (in a comical context or a childlike setting) is acceptable. No bad language should be heard.",
				ImageLink = "client/images/PEGI/3.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 9,
				RatingsSystem = Rating.RatingSystem.PEGI,
				RatingsCountry = Rating.Country.EU,
				Name = "PEGI 7",
				Age = 7,
				Definition = "Game content with scenes or sounds that can possibly frightening to younger children should fall in this category. Very mild forms of violence (implied, non-detailed, or non-realistic violence) are acceptable for a game with a PEGI 7 rating.",
				ImageLink = "client/images/PEGI/7.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 10,
				RatingsSystem = Rating.RatingSystem.PEGI,
				RatingsCountry = Rating.Country.EU,
				Name = "PEGI 12",
				Age = 12,
				Definition = "Video games that show violence of a slightly more graphic nature towards fantasy characters or non-realistic violence towards human-like characters would fall in this age category. Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present (e.g. card games that in real life would be played for money).",
				ImageLink = "client/images/PEGI/12.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 11,
				RatingsSystem = Rating.RatingSystem.PEGI,
				RatingsCountry = Rating.Country.EU,
				Name = "PEGI 16",
				Age = 16,
				Definition = "This rating is applied once the depiction of violence (or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol or illegal drugs can also be present.",
				ImageLink = "client/images/PEGI/16.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 12,
				RatingsSystem = Rating.RatingSystem.PEGI,
				RatingsCountry = Rating.Country.EU,
				Name = "PEGI 18",
				Age = 18,
				Definition = "The adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenceless characters. The glamorisation of the use of illegal drugs and explicit sexual activity should also fall into this age category.",
				ImageLink = "client/images/PEGI/18.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 13,
				RatingsSystem = Rating.RatingSystem.RARS,
				RatingsCountry = Rating.Country.Russia,
				Name = "0+",
				Age = 0,
				Definition = "Any age",
				ImageLink = "client/images/RARS/0+.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 14,
				RatingsSystem = Rating.RatingSystem.RARS,
				RatingsCountry = Rating.Country.Russia,
				Name = "6+",
				Age = 6,
				Definition = "The age 6 and older",
				ImageLink = "client/images/RARS/6+.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 15,
				RatingsSystem = Rating.RatingSystem.RARS,
				RatingsCountry = Rating.Country.Russia,
				Name = "12+",
				Age = 12,
				Definition = "The age 12 and older",
				ImageLink = "client/images/RARS/12+.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 16,
				RatingsSystem = Rating.RatingSystem.RARS,
				RatingsCountry = Rating.Country.Russia,
				Name = "16+",
				Age = 16,
				Definition = "The age 16 and older",
				ImageLink = "client/images/RARS/16+.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 17,
				RatingsSystem = Rating.RatingSystem.RARS,
				RatingsCountry = Rating.Country.Russia,
				Name = "18+",
				Age = 18,
				Definition = "The age 18 and older",
				ImageLink = "client/images/RARS/18+.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 18,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Exempt from classification",
				Age = 0,
				Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.",
				ImageLink = "client/images/ACB/E.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 19,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "General",
				Age = 0,
				Definition = "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.",
				ImageLink = "client/images/ACB/General.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 20,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Parental Guidance",
				Age = 8,
				Definition = "Not recommended for viewing or playing by people under 15 without guidance from parents or guardians. Contains material that young viewers may find confusing or upsetting. The content is mild in impact.",
				ImageLink = "client/images/ACB/PG.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 21,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Mature",
				Age = 15,
				Definition = "Recommended for people aged 15 years and over. People under 15 may legally access this material because it is an advisory category. This category contains material that may require a mature perspective, but is not deemed too strong for younger viewers. The content is moderate in impact, although the Moderate indicator prefix is no longer used in the consumer advice, eg. Moderate violence is referred to as Violence.",
				ImageLink = "client/images/ACB/M.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 22,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Mature Accompanied",
				Age = 15,
				Definition = "Contains material that is considered unsuitable for exhibition by persons under the age of 15. People under 15 may legally purchase, rent, exhibit or view such content only under the supervision of a parent or adult guardian. A person may be asked to show proof of age before renting or purchasing an MA 15+ film or computer game. The content is strong in impact.",
				ImageLink = "client/images/ACB/MA.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 23,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Restricted R",
				Age = 18,
				Definition = "Contains material that is considered unsuitable for exhibition to persons under the age of 18. People under 18 may not legally buy, rent, exhibit or view R 18+ classified content. A person may be asked for proof of their age before purchasing, hiring or viewing an R 18+ film or computer game at a retail store or cinema. Some material classified R 18+ may be offensive to sections of the adult community. The content is high in impact.",
				ImageLink = "client/images/ACB/R18.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 24,
				RatingsSystem = Rating.RatingSystem.ACB,
				RatingsCountry = Rating.Country.Australia,
				Name = "Restricted X",
				Age = 18,
				Definition = "Contains material that is pornographic in nature. People under 18 may not legally buy, rent, possess, exhibit or view these films. The exhibition or sale of these films to people under the age of 18 years is a criminal offence carrying a maximum fine of $5,500. Films classified as X 18+ are banned (via state government legislation) from being sold or rented in all Australian states (but are legal to possess except in certain parts of the Northern Territory) and are legally available to purchase only in the Australian Capital Territory and the Northern Territory. Importing X 18+ material from these territories to any other state is legal (as the Australian Constitution forbids any restrictions on trade between the states and territories). The content is sexually explicit, and the rating does not exist for video games.",
				ImageLink = "client/images/ACB/X18.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 25,
				RatingsSystem = Rating.RatingSystem.USK,
				RatingsCountry = Rating.Country.Germany,
				Name = "0",
				Age = 0,
				Definition = "Approved without age restriction in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games without age restriction are games which are directly aimed at children and young persons as well as at an adult buyer group.",
				ImageLink = "client/images/USK/0.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 26,
				RatingsSystem = Rating.RatingSystem.USK,
				RatingsCountry = Rating.Country.Germany,
				Name = "6",
				Age = 6,
				Definition = "Approved for children aged 6 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games mostly involve family-friendly games which may be more exciting and competitive (e.g. via faster game speeds and more complex tasks).",
				ImageLink = "client/images/USK/6.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 27,
				RatingsSystem = Rating.RatingSystem.USK,
				RatingsCountry = Rating.Country.Germany,
				Name = "12",
				Age = 12,
				Definition = "Approved for children aged 12 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games feature much more of a competitive edge. Game scenarios contain little violence, enabling players to distance themselves sufficiently from events.",
				ImageLink = "client/images/USK/12.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 28,
				RatingsSystem = Rating.RatingSystem.USK,
				RatingsCountry = Rating.Country.Germany,
				Name = "16",
				Age = 16,
				Definition = "Approved for children aged 16 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games approved for children aged 16 and above may include acts of violence. This means that it is also natural for adults to buy them.",
				ImageLink = "client/images/USK/16.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			},
			new Rating() 
            {
				RatingId = 29,
				RatingsSystem = Rating.RatingSystem.USK,
				RatingsCountry = Rating.Country.Germany,
				Name = "18",
				Age = 18,
				Definition = "Not approved for anyone under 18 in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games almost always involve violent game concepts and frequently generate a dark and threatening atmosphere. This makes them suitable for adults only. These games often contain brutal, strong bloody violence and/or glorify war and/or human rights violations.",
				ImageLink = "client/images/USK/18.png",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now
			});

			// Game
			ModelBuilder.Entity<Game>().HasData(
			// Steam - 1
			new Game() 
            {
				GameId = 1,
				Name = "Virtua Tennis 4",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 4, 29),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 2,
				Name = "Portal 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 4, 19),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 3,
				Name = "Rage",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 11, 18),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 4,
				Name = "F1 Racing 2011",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 23),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 5,
				Name = "Shogun 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 3, 15),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 6,
				Name = "Operation Flashpoint Red River",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 4, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 7,
				Name = "Batman Arkham City",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 10, 18),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 8,
				Name = "Modern Warfare 3",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 11, 8),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 9,
				Name = "Skyrim",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 11, 11),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 10,
				Name = "Renegade Ops",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 13),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 11,
				Name = "Defense Grid",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2008, 12, 8),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 12,
				Name = "Limbo",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 7, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 13,
				Name = "Call of Duty: Black Ops 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 11, 13),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 14,
				Name = "Dishonored",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 10, 9),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 15,
				Name = "Deep Black: Reloaded",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 4, 18),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 16,
				Name = "Civilization 5",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 10, 9),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 17,
				Name = "Command & Conquer 4: Tiberian Twilight",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 3, 16),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 18,
				Name = "Lego: The Lord of the Rings",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 10, 30),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 19,
				Name = "Transformers: Fal of Cybertron",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 8, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 20,
				Name = "Grid 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 8, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 21,
				Name = "Sega and Sonic All Stars Transformed",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 11, 16),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 22,
				Name = "Sega and Sonic All Stars Transformed",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 11, 16),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 23,
				Name = "Civilization 5: Brave New World",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 7, 9),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 24,
				Name = "ARMA 3",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 9, 12),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 25,
				Name = "Broken Age",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 1, 14),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 26,
				Name = "Shadowrun Returns",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 7, 25),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 27,
				Name = "Shadowrun: Dragonfall",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 2, 27),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 28,
				Name = "Trine 2 Complete",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 12, 7),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 29,
				Name = "Grid Autosport",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 6, 24),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 30,
				Name = "Beatbuddy: Tale of the Guardians",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 8, 6),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Beatbuddy",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 31,
				Name = "Transistor",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 5, 20),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Transistor",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 32,
				Name = "Borderlands: The Pre-Sequel Preorder",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 10, 14),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Borderlands,The Pre Sequel",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 33,
				Name = "Alien Isolation",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 10, 7),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Alien Isolation",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 34,
				Name = "Counter Strike: Global Offensive",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 8, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Counter Strike - Global Offensive",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 35,
				Name = "Lara Croft Temple of Osiris",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 12, 9),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Lara Croft and the Temple of Osiris",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 36,
				Name = "Tomb Raider (2013)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 3, 5),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Tomb Raider",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 37,
				Name = "F1 2015",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 7, 10),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 38,
				Name = "Homeworld Remastered Collection",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 2, 25),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 39,
				Name = "Euro Truck Simulator 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 10, 19),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Euro Truck Simulator 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 40,
				Name = "Project Cars",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 5, 6),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Project CARS",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 41,
				Name = "Just Cause 3",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 12, 1),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Just Cause 3",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 42,
				Name = "NBA2K16",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 9, 29),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/NBA2K16",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 43,
				Name = "Rocket League",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 7, 7),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Rocket League",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 44,
				Name = "Warhammer Vermintide - CHECK",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 10, 23),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Warhammer - End Times - Vermintide",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 45,
				Name = "Tom Clancy's Rainbow Six Siege",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 12, 1),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Rainbow6Siege",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 46,
				Name = "Grey Goo",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 1, 23),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Grey Goo",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 47,
				Name = "PES 2017",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 9, 13),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/PES 2017",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 48,
				Name = "Project Cars 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 9, 22),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Project Cars 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 49,
				Name = "PUBG",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 12, 20),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/PUBG",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 50,
				Name = "Total War: Warhammer 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 9, 28),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Total War - Warhammer II",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 51,
				Name = "Lego Marvel Super Heroes 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 8, 2),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Lego - Marvel Super Heroes 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 52,
				Name = "Call of Duty World War II",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 11, 3),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Call of Duty - WWII",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 53,
				Name = "Warhammer: Vermintide 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 3, 8),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Warhammer- Vermintide 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 54,
				Name = "Cuphead",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 9, 29),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Cuphead",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 55,
				Name = "Yooka Laylee",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 4, 11),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Yooka Laylee",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 56,
				Name = "NBA 2K18",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 9, 19),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/NBA 2K18",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 57,
				Name = "SINNER: Sacrifice for Redemption",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 10, 22),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/SINNER Sacrifice for Redemption",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 58,
				Name = "NBA 2k19",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 9, 11),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 59,
				Name = "Hitman 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 11, 13),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Hitman 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 60,
				Name = "Just Cause 4",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 12, 4),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Just Cause 4",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 61,
				Name = "Ring of Elysium",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 9, 19),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Ring of Elysium",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 62,
				Name = "Street Fighter 5",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 2, 16),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Street Fighter V",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 63,
				Name = "Resident Evil 2 Remake",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 1, 25),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Resident Evil 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 64,
				Name = "Outward",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 3, 26),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Outward",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game()
            {
				GameId = 65,
				Name = "Tekken 7",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 3, 18),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Tekken 7",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game(){
				GameId = 66,
				Name = "Soul Calibur 6",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 10, 19),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/SOULCALIBUR VI",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 67,
				Name = "Dragon Ball FighterZ",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 1, 26),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Dragon Ball FighterZ",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 68,
				Name = "DOTA 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 7, 9),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/DOTA 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game() 
            {
				GameId = 69,
				Name = "Ace Combat 7: Skies Unknown",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 1, 18),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/Ace Combat 7 - Skies Unknown",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},
			new Game()
            {
				GameId = 70,
				Name = "Sekiro: Shadows Die Twice",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 3, 22),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 1
			},

			// Microsftstore - 2
			new Game() 
            {
				GameId = 71,
				Name = "Superhot VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 5),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/SUPERHOT",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 2
			},
			new Game() 
            {
				GameId = 72,
				Name = "Gears of War 4",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 10, 11),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Windows Store/Gears of War 4",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 2
			},
			new Game() 
            {
				GameId = 73,
				Name = "Ghostbusters VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 10, 12),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 2
			},
			new Game() 
            {
				GameId = 74,
				Name = "Arizona Sunshine",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 6),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 2
			},
			new Game() 
            {
				GameId = 75,
				Name = "Halo Wars",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 2, 26),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 2
			},

			// Android - 3
			new Game() 
            {
				GameId = 76,
				Name = "Marvel Run Jump Smash",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 1, 30),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 77,
				Name = "Angry Birds (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2009, 10, 19),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Angry Birds",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 78,
				Name = "Angry Birds Space (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 3, 22),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 79,
				Name = "Candy Crush Saga (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 4, 12),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 80,
				Name = "Fruit Ninja (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 4, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Fruit Ninja HD",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 81,
				Name = "Jetpack Joyride (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 82,
				Name = "Plants vs Zombies 2 (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 83,
				Name = "Tap the Frog (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 2, 12),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 84,
				Name = "Tiny Dice Dungeon",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 11, 11),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 85,
				Name = "Fractal Combat X (FCX) (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 1, 8),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 86,
				Name = "GT Racing 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 11, 13),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Windows Store/GT Racing 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 87,
				Name = "Shadowrun Returns",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 7, 25),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 88,
				Name = "Hitman GO",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 4, 17),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Android/Hitman Go",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 89,
				Name = "Sonic Dash",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 3, 7),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Android/Sonic Dash",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 90,
				Name = "Blitz Brigade (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 5, 9),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 91,
				Name = "Assassin's Creed Pirates (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 12, 4),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 92,
				Name = "Jetpack Joyride",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 1),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Windows Store/Jetpack Joyride",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},
			new Game() 
            {
				GameId = 93,
				Name = "Yo-kai Watch Wibble Wobble (Free)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 10, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 3
			},

			// Steam VR - 4
			new Game()
            {
				GameId = 94,
				Name = "The Gallery - Episode 1: Call of the Starseed",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 95,
				Name = "Arizona Sunshine",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 6),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 96,
				Name = "Budget Cuts",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 6, 14),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 97,
				Name = "The LAB",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 98,
				Name = "Raw Data",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 10, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 99,
				Name = "Raw Data (Demo)",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 10, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 100,
				Name = "theBlu",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 101,
				Name = "Tilt Brush",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 102,
				Name = "A-10 VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 103,
				Name = "Job Simulator",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 104,
				Name = "Fantastic Contraption",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 105,
				Name = "Balloon Chair Death Match",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 7, 13),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 106,
				Name = "Serious Sam VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 3, 30),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 107,
				Name = "Warhammer: End Times - Vermintide - CHECK",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 10, 23),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 108,
				Name = "Blue Effect VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 9, 29),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 109,
				Name = "Bullet Sorrow VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 4, 17),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 110,
				Name = "Fruit Ninja VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 7, 7),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Fruit Ninja HD",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 111,
				Name = "NBA 2KVR Experience",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 11, 21),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 112,
				Name = "SportsBar VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 6, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 113,
				Name = "Evasion",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 10, 9),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 114,
				Name = "Sprint Vector",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 2, 8),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 115,
				Name = "Mortal Blitz",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 7, 19),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 116,
				Name = "Onward",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 8, 29),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 117,
				Name = "Space Pirate Trainer",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 4, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 118,
				Name = "Archangel: Hellfire",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 8, 2),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 119,
				Name = "Beatsaber",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 5, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 120,
				Name = "The Gold Club VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 9, 25),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
			new Game() 
            {
				GameId = 121,
				Name = "Creed - Rise to Glory",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 9, 25),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},
            new Game() 
            { 
                GameId = 122, 
                Name = "Creed - Rise to Glory \"Arcade\"", 
                ConnectionType = 2, 
                ReleaseDate = new DateTime(2018, 9, 25), 
                URLToDocumentation = "Location to Doc", 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now, 
                PlatformId = 4 
            },
			new Game() 
            {
				GameId = 123,
				Name = "Audica",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2019, 3, 7),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 4
			},

			// Oculus - 5
			new Game() 
            {
				GameId = 124,
				Name = "Superhot VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 5),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Steam Client Games/SUPERHOT",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 125,
				Name = "Rock Band VR",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 3, 20),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 126,
				Name = "Robo Recall",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 3, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 127,
				Name = "Unspoken",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 128,
				Name = "Dead and Buried",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 12, 5),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 129,
				Name = "Sprint Vector",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 2, 8),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 130,
				Name = "Lone Echo",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 7, 20),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 131,
				Name = "Luna",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 10, 17),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},
			new Game() 
            {
				GameId = 132,
				Name = "Echo Arena",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 7, 20),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 5
			},

			// Origin - 6
			new Game() 
            {
				GameId = 133,
				Name = "Battlefield 3",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 10, 25),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/Battlefield 3",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 134,
				Name = "Fifa Soccer 12",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 27),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/FIFA Soccer 12",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 135,
				Name = "Fifa Soccer 13",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 9, 25),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/FIFA Soccer 13",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 136,
				Name = "Fifa Soccer 14",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 9, 23),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/FIFA Soccer 14",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 137,
				Name = "Titanfall",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 3, 11),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/Titanfall",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 138,
				Name = "Fifa Soccer 15",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 9, 23),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/FIFA Soccer 15",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 139,
				Name = "The SIMS 4",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 9, 2),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/The SIMS 4",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game()
            {
				GameId = 140,
				Name = "Titanfall 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 10, 28),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/Titanfall 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},
			new Game() 
            {
				GameId = 141,
				Name = "Battlefield 1",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 10, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Origin Client Games/Battlefield 1",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 6
			},

			// Uplay - 7
			new Game() 
            {
				GameId = 142,
				Name = "Tom Clany's Raimbow Six Siege",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 12, 1),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 7
			},
			new Game() 
            {
				GameId = 143,
				Name = "Assassin's Creed Origins",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 10, 27),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Assassin's Creed - Origins",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 7
			},

			// Epic - 8
			new Game() 
            {
				GameId = 144,
				Name = "Fortnite",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2017, 7, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Fortnite",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 8
			},
			new Game() 
            {
				GameId = 145,
				Name = "Unreal Tournament",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1999, 11, 30),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 8
			},

			// Standalone - 9
			new Game() 
            {
				GameId = 146,
				Name = "Lost Planet 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 4, 28),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Lost Planet2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 147,
				Name = "DnD Daggerdale",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 6, 24),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/DnD Daggerdale",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 148,
				Name = "Need For Speed World",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 7, 20),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 149,
				Name = "DarkSpore",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 4, 26),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Darkspore",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 150,
				Name = "Might & Magic Heroes VI",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 10, 13),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/Might and Magic Heroes VI",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},

			new Game() 
            {
				GameId = 151,
				Name = "LEGO Mini Figures Online",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 10, 29),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Independent/LEGO Minifigures Online",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},

			new Game() 
            {
				GameId = 152,
				Name = "TrackMania 2 - Canyon",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 14),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/ManiaPlanet/TrackMania 2 - Canyon",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 153,
				Name = "ShootMania",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 4, 10),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/ManiaPlanet/ShootMania Storm",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 154,
				Name = "Trackmania - Valley",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 7, 4),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/ManiaPlanet/Trackmania 2 - Valley",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},
			new Game() 
            {
				GameId = 155,
				Name = "Trackmania - Stadium",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 9, 14),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/ManiaPlanet/Trackmania 2 - Stadium",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},

			new Game() 
            {
				GameId = 156,
				Name = "Star Trek Online",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 2, 2),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 9
			},

			// Playstation - 10
			new Game() 
            {
				GameId = 157,
				Name = "Planetside 2",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 11, 20),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Sony Station/Planetside 2",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 10
			},
			new Game() 
            {
				GameId = 158,
				Name = "Dragons Prophet",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 9, 18),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Sony Station/Dragons Prophet",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 10
			},

			// Battlenet - 11
			new Game() 
            {
				GameId = 159,
				Name = "Call of Duty: BO4",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2018, 10, 12),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Call of Duty Black Ops 4",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 160,
				Name = "World of Warcraft",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2004, 11, 23),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 161,
				Name = "Starcraft 2: Wings of Liberty",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 7, 27),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Starcraft II",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 162,
				Name = "Starcraft 2: Heart of the Swarm",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2013, 3, 12),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Starcraft II",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 163,
				Name = "Starcraft 2: Legacy of the Void",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 11, 10),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Starcraft II",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 164,
				Name = "Starcraft 2: Nova Convert Ops",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 3, 29),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Starcraft II",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 165,
				Name = "Hearthstone",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2014, 3, 11),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Hearthstone",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 166,
				Name = "Overwatch",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2016, 5, 24),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Overwatch",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 167,
				Name = "Heroes of the Storm",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2015, 6, 2),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Battlenet/Heroes of the Storm",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
			new Game() 
            {
				GameId = 168,
				Name = "Starcraft",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1998, 3, 31),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 11
			},
            new Game() 
            {
				GameId = 169,
				Name = "Angry Birds",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2009, 12, 11),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Angry Birds",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 170,
				Name = "Top Shot",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 3, 12),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Top Shot",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 171,
				Name = "Angry Birds Rio",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2011, 3, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Angry Birds Rio",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 172,
				Name = "Fruit Ninja",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2010, 4, 21),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Fruit Ninja HD",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 173,
				Name = "Pac-Man",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1980, 5, 22),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/Pac-Man",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 174,
				Name = "Dr. Robotnik's Mean Bean Machine",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1993, 11, 26),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/SEGA Classics - Dr Robotniks MBM",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 175,
				Name = "Sonic 3D Blast",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1996, 11, 1),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/SEGA Classics - Sonic 3D Blast",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 176,
				Name = "Sonic the Hedgehog Spinball",
				ConnectionType = 2,
				ReleaseDate = new DateTime(1993, 11, 15),
				URLToDocumentation = "http://ddc.intel.com/Production/loancenter/DDLC Prep Documents/Games and Entertainment/Video Games/Intel AppUp/SEGA Classics - Sonic Spinball",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			},
            new Game() 
            {
				GameId = 177,
				Name = "Sonic & All-Stars Racing Transformed",
				ConnectionType = 2,
				ReleaseDate = new DateTime(2012, 11, 16),
				URLToDocumentation = "Location to Doc",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
				PlatformId = 12
			});

			// Game Controller Type
			ModelBuilder.Entity<GameControllerType>().HasData(
			new GameControllerType() 
            {
				GameId = 1,
				ControllerTypeId = 1
			},
			new GameControllerType() 
            {
				GameId = 1,
				ControllerTypeId = 2
			},
			new GameControllerType() 
            {
				GameId = 2,
				ControllerTypeId = 1
			},
			new GameControllerType() 
            {
				GameId = 2,
				ControllerTypeId = 2
			},
			new GameControllerType() 
            {
				GameId = 2,
				ControllerTypeId = 3
			},
			new GameControllerType() 
            {
				GameId = 3,
				ControllerTypeId = 1
			});

			// Game Rating
			// 1 - Ec
			// 2 - E
			// 3 - E10
			// 4 - T
			// 5 - M
			// 6 - Ao

			// 7 - RP
			// 8 - PEGI 3
			// 9 - PEGI 7
			// 10 - PEGI 12
			// 11 - PEGI 16
			// 12 - PEGI 18

			// RARS
			// 13 - 0+
			// 14 - 6+
			// 15 - 12+
			// 16 - 16+
			// 17 - 18+

			// ACB
			// 18 - Excepmt
			// 19 - General
			// 20 - PArental Guidance
			// 21 -  Mature
			// 22 - Mature Accompanied
			// 23 - Restricted R
			// 24 - Restricted X

			// 25 - 0
			// 26 - 6
			// 27 - 12
			// 28 - 16
			// 29 - 18


			ModelBuilder.Entity<GameRating>().HasData(
			new GameRating() 
            {
				GameId = 1,
				RatingId = 2
			},
			new GameRating() 
            {
				GameId = 1,
				RatingId = 8
			},
			new GameRating() 
            {
				GameId = 1,
				RatingId = 13
			},
			new GameRating() 
            {
				GameId = 1,
				RatingId = 19
			},
			new GameRating() 
            {
				GameId = 1,
				RatingId = 25
			},
			new GameRating() 
            {
				GameId = 2,
				RatingId = 3
			},
			new GameRating() 
            {
				GameId = 2,
				RatingId = 10
			},
			new GameRating() 
            {
				GameId = 2,
				RatingId = 15
			},
			new GameRating() 
            {
				GameId = 2,
				RatingId = 19
			},
			new GameRating() 
            {
				GameId = 2,
				RatingId = 27
			},
			new GameRating() 
            {
				GameId = 3,
				RatingId = 5
			},
			new GameRating() 
            {
				GameId = 3,
				RatingId = 12
			},
			new GameRating() 
            {
				GameId = 3,
				RatingId = 17
			},
			new GameRating() 
            {
				GameId = 3,
				RatingId = 22
			},
			new GameRating() 
            {
				GameId = 3,
				RatingId = 29
			},
			new GameRating() 
            {
				GameId = 4,
				RatingId = 2
			},
			new GameRating() 
            {
				GameId = 4,
				RatingId = 8
			},
			new GameRating() 
            {
				GameId = 4,
				RatingId = 13
			},
			new GameRating() 
            {
				GameId = 4,
				RatingId = 19
			},
			new GameRating() 
            {
				GameId = 4,
				RatingId = 25
			},
			new GameRating() 
            {
				GameId = 5,
				RatingId = 4
			},
			new GameRating() 
            {
				GameId = 5,
				RatingId = 11
			},
			new GameRating() 
            {
				GameId = 5,
				RatingId = 15
			},
			new GameRating() 
            {
				GameId = 5,
				RatingId = 20
			},
			new GameRating() 
            {
				GameId = 5,
				RatingId = 27
			}

			);

			// Account Platform
			ModelBuilder.Entity<AccountPlatform>().HasData(
			new AccountPlatform() 
            {
				AccountId = 1,
				PlatformId = 1
			},
			new AccountPlatform() 
            {
				AccountId = 1,
				PlatformId = 2
			},
			new AccountPlatform() 
            {
				AccountId = 1,
				PlatformId = 3
			},
			new AccountPlatform() 
            {
				AccountId = 2,
				PlatformId = 4
			},
			new AccountPlatform() 
            {
				AccountId = 2,
				PlatformId = 5
			});

			// Game Account
			ModelBuilder.Entity<GameAccount>().HasData(
			new GameAccount()
            {
				GameId = 1,
				AccountId = 1
			},
			new GameAccount() 
            {
				GameId = 2,
				AccountId = 1
			},
			new GameAccount() 
            {
				GameId = 3,
				AccountId = 1
			},
			new GameAccount() 
            {
				GameId = 3,
				AccountId = 2
			},
			new GameAccount() 
            {
				GameId = 1,
				AccountId = 2
			},
			new GameAccount() 
            {
				GameId = 2,
				AccountId = 2
			});
		}
	}
}