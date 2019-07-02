using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountAPI.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControllerTypes",
                columns: table => new
                {
                    ControllerTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerTypes", x => x.ControllerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ConnectionType = table.Column<bool>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    URLToDocumentation = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "PlatformTypes",
                columns: table => new
                {
                    PlatformTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypes", x => x.PlatformTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RatingsSystem = table.Column<string>(nullable: false),
                    RatingsCountry = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Definition = table.Column<string>(nullable: false),
                    ImageLink = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EmailPassword = table.Column<string>(nullable: false),
                    CheckedOutStatus = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeString = table.Column<string>(nullable: false),
                    UsedStatus = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.CodeId);
                    table.ForeignKey(
                        name: "FK_Codes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameControllerType",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    ControllerTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameControllerType", x => new { x.GameId, x.ControllerTypeId });
                    table.ForeignKey(
                        name: "FK_GameControllerType_ControllerTypes_ControllerTypeId",
                        column: x => x.ControllerTypeId,
                        principalTable: "ControllerTypes",
                        principalColumn: "ControllerTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameControllerType_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    PlatformTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                    table.ForeignKey(
                        name: "FK_Platforms_PlatformTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "PlatformTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRating",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRating", x => new { x.GameId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_GameRating_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRating_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountProfiles",
                columns: table => new
                {
                    AccountProfileId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SecretQuestion1 = table.Column<string>(nullable: true),
                    SecretQuestion2 = table.Column<string>(nullable: true),
                    SecretQuestion3 = table.Column<string>(nullable: true),
                    SecretAnswer1 = table.Column<string>(nullable: true),
                    SecretAnswer2 = table.Column<string>(nullable: true),
                    SecretAnswer3 = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProfiles", x => x.AccountProfileId);
                    table.ForeignKey(
                        name: "FK_AccountProfiles_Accounts_AccountProfileId",
                        column: x => x.AccountProfileId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameAccount",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccount", x => new { x.GameId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_GameAccount_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameAccount_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ControllerTypes",
                columns: new[] { "ControllerTypeId", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(9609), "Touch", new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(9828) },
                    { 2, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(45), "Keyboard & Mouse", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(49) },
                    { 3, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(57), "Xbox", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(59) },
                    { 4, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(66), "Steering Wheel", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(68) }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreatedAt", "Location", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(1547), "Chicago", "IEM", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(3936), "Game", new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(4184) },
                    { 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(4430), "Other", new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(4434) }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Age", "CreatedAt", "Definition", "ImageLink", "Name", "RatingsCountry", "RatingsSystem", "UpdatedAt" },
                values: new object[,]
                {
                    { 17, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5063), "The age 18 and older", "client/images/RARS/18+.png", "18+", "Russia", "RARS", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5065) },
                    { 18, 0, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5071), "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", "client/images/ACB/E.png", "Exempt from classification", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5074) },
                    { 19, 0, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5080), "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", "client/images/ACB/General.png", "General", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5082) },
                    { 20, 8, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5089), "Not recommended for viewing or playing by people under 15 without guidance from parents or guardians. Contains material that young viewers may find confusing or upsetting. The content is mild in impact.", "client/images/ACB/PG.png", "Parental Guidance", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5091) },
                    { 21, 15, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5098), "Recommended for people aged 15 years and over. People under 15 may legally access this material because it is an advisory category. This category contains material that may require a mature perspective, but is not deemed too strong for younger viewers. The content is moderate in impact, although the Moderate indicator prefix is no longer used in the consumer advice, eg. Moderate violence is referred to as Violence.", "client/images/ACB/M.png", "Mature", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5100) },
                    { 25, 0, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5133), "Approved without age restriction in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games without age restriction are games which are directly aimed at children and young persons as well as at an adult buyer group.", "client/images/USK/0.png", "0", "Germany", "USK", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5135) },
                    { 23, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5115), "Contains material that is considered unsuitable for exhibition to persons under the age of 18. People under 18 may not legally buy, rent, exhibit or view R 18+ classified content. A person may be asked for proof of their age before purchasing, hiring or viewing an R 18+ film or computer game at a retail store or cinema. Some material classified R 18+ may be offensive to sections of the adult community. The content is high in impact.", "client/images/ACB/R18.png", "Restricted R", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5117) },
                    { 24, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5124), "Contains material that is pornographic in nature. People under 18 may not legally buy, rent, possess, exhibit or view these films. The exhibition or sale of these films to people under the age of 18 years is a criminal offence carrying a maximum fine of $5,500. Films classified as X 18+ are banned (via state government legislation) from being sold or rented in all Australian states (but are legal to possess except in certain parts of the Northern Territory) and are legally available to purchase only in the Australian Capital Territory and the Northern Territory. Importing X 18+ material from these territories to any other state is legal (as the Australian Constitution forbids any restrictions on trade between the states and territories). The content is sexually explicit, and the rating does not exist for video games.", "client/images/ACB/X18.png", "Restricted X", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5126) },
                    { 16, 16, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5054), "The age 16 and older", "client/images/RARS/16+.png", "16+", "Russia", "RARS", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5056) },
                    { 26, 6, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5142), "Approved for children aged 6 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games mostly involve family-friendly games which may be more exciting and competitive (e.g. via faster game speeds and more complex tasks).", "client/images/USK/6.png", "6", "Germany", "USK", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5144) },
                    { 27, 12, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5151), "Approved for children aged 12 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games feature much more of a competitive edge. Game scenarios contain little violence, enabling players to distance themselves sufficiently from events.", "client/images/USK/12.png", "12", "Germany", "USK", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5153) },
                    { 22, 15, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5107), "Contains material that is considered unsuitable for exhibition by persons under the age of 15. People under 15 may legally purchase, rent, exhibit or view such content only under the supervision of a parent or adult guardian. A person may be asked to show proof of age before renting or purchasing an MA 15+ film or computer game. The content is strong in impact.", "client/images/ACB/MA.png", "Mature Accompanied", "Australia", "ACB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5109) },
                    { 15, 12, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5045), "The age 12 and older", "client/images/RARS/12+.png", "12+", "Russia", "RARS", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5047) },
                    { 11, 16, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5009), "This rating is applied once the depiction of violence (or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol or illegal drugs can also be present.", "client/images/PEGI/16.png", "PEGI 16", "EU", "PEGI", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5011) },
                    { 13, 0, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5028), "Any age", "client/images/RARS/0+.png", "0+", "Russia", "RARS", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5030) },
                    { 12, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5019), "The adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenceless characters. The glamorisation of the use of illegal drugs and explicit sexual activity should also fall into this age category.", "client/images/PEGI/18.png", "PEGI 18", "EU", "PEGI", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5021) },
                    { 28, 16, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5159), "Approved for children aged 16 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games approved for children aged 16 and above may include acts of violence. This means that it is also natural for adults to buy them.", "client/images/USK/16.png", "16", "Germany", "USK", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5161) },
                    { 10, 12, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4993), "Video games that show violence of a slightly more graphic nature towards fantasy characters or non-realistic violence towards human-like characters would fall in this age category. Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present (e.g. card games that in real life would be played for money).", "client/images/PEGI/12.png", "PEGI 12", "EU", "PEGI", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4995) },
                    { 9, 7, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4984), "Game content with scenes or sounds that can possibly frightening to younger children should fall in this category. Very mild forms of violence (implied, non-detailed, or non-realistic violence) are acceptable for a game with a PEGI 7 rating.", "client/images/PEGI/7.png", "PEGI 7", "EU", "PEGI", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4986) },
                    { 8, 3, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4975), "The content of games with a PEGI 3 rating is considered suitable for all age groups. The game should not contain any sounds or pictures that are likely to frighten young children. A very mild form of violence (in a comical context or a childlike setting) is acceptable. No bad language should be heard.", "client/images/PEGI/3.png", "PEGI 3", "EU", "PEGI", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4977) },
                    { 7, -1, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4966), "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)", "client/images/ESRB/RP.png", "Rating Pending", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4968) },
                    { 6, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4958), "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "client/images/ESRB/Ao.png", "Adults Only 18+", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4960) },
                    { 5, 17, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4948), "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "client/images/ESRB/M.png", "Mature", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4951) },
                    { 4, 13, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4940), "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.", "client/images/ESRB/T.png", "Teen", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4942) },
                    { 3, 10, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4930), "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.", "client/images/ESRB/E10.png", "Everyone 10+", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4933) },
                    { 2, 6, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4917), "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.", "client/images/ESRB/E.png", "Everyone", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4921) },
                    { 1, 3, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4486), "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.", "client/images/ESRB/eC.png", "Early Childhood", "USA", "ESRB", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(4696) },
                    { 14, 6, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5037), "The age 6 and older", "client/images/RARS/6+.png", "6+", "Russia", "RARS", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5039) },
                    { 29, 18, new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5168), "Not approved for anyone under 18 in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games almost always involve violent game concepts and frequently generate a dark and threatening atmosphere. This makes them suitable for adults only. These games often contain brutal, strong bloody violence and/or glorify war and/or human rights violations.", "client/images/USK/18.png", "18", "Germany", "USK", new DateTime(2019, 7, 1, 21, 48, 29, 323, DateTimeKind.Local).AddTicks(5170) }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "CreatedAt", "Name", "PlatformTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7207), "Steam", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7427) },
                    { 22, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7831), "QQ", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7833) },
                    { 21, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7822), "Apple", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7824) },
                    { 19, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7806), "McAfee LiveSafe", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7808) },
                    { 18, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7797), "Amazon", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7799) },
                    { 20, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7814), "Eve Online", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7816) },
                    { 17, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7789), "Cryptic Studios", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7791) },
                    { 16, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7780), "Intel Appup", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7782) },
                    { 15, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7772), "League of Legends", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7774) },
                    { 14, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7763), "Lego Mini Online", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7766) },
                    { 13, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7755), "BattleNet", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7757) },
                    { 12, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7747), "Play Station", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7749) },
                    { 11, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7738), "Maniaplenet", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7740) },
                    { 10, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7730), "Standalone", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7732) },
                    { 9, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7721), "Epic", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7723) },
                    { 8, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7712), "Uplay", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7714) },
                    { 7, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7703), "Origin", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7705) },
                    { 6, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7694), "Oculus", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7696) },
                    { 5, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7685), "Steam VR", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7688) },
                    { 4, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7677), "Android", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7679) },
                    { 3, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7667), "Windows", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7670) },
                    { 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7654), "Microsoft Store", 1, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7659) },
                    { 23, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7839), "Media Accounts", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7841) },
                    { 24, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7848), "Twitch", 2, new DateTime(2019, 7, 1, 21, 48, 29, 322, DateTimeKind.Local).AddTicks(7850) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EventId",
                table: "Accounts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_CodeString",
                table: "Codes",
                column: "CodeString",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Codes_GameId",
                table: "Codes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccount_AccountId",
                table: "GameAccount",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameControllerType_ControllerTypeId",
                table: "GameControllerType",
                column: "ControllerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformId",
                table: "GamePlatform",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRating_RatingId",
                table: "GameRating",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformTypeId",
                table: "Platforms",
                column: "PlatformTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProfiles");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "GameAccount");

            migrationBuilder.DropTable(
                name: "GameControllerType");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GameRating");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ControllerTypes");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "PlatformTypes");
        }
    }
}
