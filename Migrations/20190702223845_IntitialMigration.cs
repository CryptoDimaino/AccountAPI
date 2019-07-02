using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountAPI.Migrations
{
    public partial class IntitialMigration : Migration
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
                name: "Events",
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
                    table.PrimaryKey("PK_Events", x => x.EventId);
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
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CheckedOutStatus = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
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
                name: "AccountProfiles",
                columns: table => new
                {
                    AccountProfileId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
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
                name: "AccountPlatforms",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPlatforms", x => new { x.AccountId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_AccountPlatforms_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ConnectionType = table.Column<byte>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    URLToDocumentation = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
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
                    AccountId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.CodeId);
                    table.ForeignKey(
                        name: "FK_Codes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Codes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameAccounts",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccounts", x => new { x.GameId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_GameAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameAccounts_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameControllerTypes",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    ControllerTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameControllerTypes", x => new { x.GameId, x.ControllerTypeId });
                    table.ForeignKey(
                        name: "FK_GameControllerTypes_ControllerTypes_ControllerTypeId",
                        column: x => x.ControllerTypeId,
                        principalTable: "ControllerTypes",
                        principalColumn: "ControllerTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameControllerTypes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRatings",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRatings", x => new { x.GameId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_GameRatings_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRatings_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ControllerTypes",
                columns: new[] { "ControllerTypeId", "CreatedAt", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(7034), "Touch", new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(7895) },
                    { 2, new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8728), "Keyboard & Mouse", new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8744) },
                    { 3, new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8778), "Xbox", new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8785) },
                    { 4, new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8810), "Steering Wheel", new DateTime(2019, 7, 2, 15, 38, 45, 88, DateTimeKind.Local).AddTicks(8817) }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreatedAt", "Location", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(4149), "Chicago", "IEM", new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(5254) },
                    { 2, new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6184), "Austraila", "IEM", new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6200) },
                    { 3, new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6235), "China", "IEM", new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6242) },
                    { 4, new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6266), "Poland", "IEM", new DateTime(2019, 7, 2, 15, 38, 45, 89, DateTimeKind.Local).AddTicks(6273) }
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 2, 15, 38, 45, 86, DateTimeKind.Local).AddTicks(4563), "Game", new DateTime(2019, 7, 2, 15, 38, 45, 86, DateTimeKind.Local).AddTicks(5821) },
                    { 2, new DateTime(2019, 7, 2, 15, 38, 45, 86, DateTimeKind.Local).AddTicks(6793), "Other", new DateTime(2019, 7, 2, 15, 38, 45, 86, DateTimeKind.Local).AddTicks(6809) }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Age", "CreatedAt", "Definition", "ImageLink", "Name", "RatingsCountry", "RatingsSystem", "UpdatedAt" },
                values: new object[,]
                {
                    { 17, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8942), "The age 18 and older", "client/images/RARS/18+.png", "18+", "Russia", "RARS", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8945) },
                    { 18, 0, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8954), "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", "client/images/ACB/E.png", "Exempt from classification", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8958) },
                    { 19, 0, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8967), "Contains material available for general viewing. This category does not necessarily designate a children's film or game. Although not mandatory at this category, the Board may provide consumer information. Consumer advice at G classification usually relates to impacts on very young children. The content is very mild in impact.", "client/images/ACB/General.png", "General", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8970) },
                    { 20, 8, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8979), "Not recommended for viewing or playing by people under 15 without guidance from parents or guardians. Contains material that young viewers may find confusing or upsetting. The content is mild in impact.", "client/images/ACB/PG.png", "Parental Guidance", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8982) },
                    { 21, 15, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8992), "Recommended for people aged 15 years and over. People under 15 may legally access this material because it is an advisory category. This category contains material that may require a mature perspective, but is not deemed too strong for younger viewers. The content is moderate in impact, although the Moderate indicator prefix is no longer used in the consumer advice, eg. Moderate violence is referred to as Violence.", "client/images/ACB/M.png", "Mature", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8995) },
                    { 26, 6, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9054), "Approved for children aged 6 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games mostly involve family-friendly games which may be more exciting and competitive (e.g. via faster game speeds and more complex tasks).", "client/images/USK/6.png", "6", "Germany", "USK", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9057) },
                    { 23, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9017), "Contains material that is considered unsuitable for exhibition to persons under the age of 18. People under 18 may not legally buy, rent, exhibit or view R 18+ classified content. A person may be asked for proof of their age before purchasing, hiring or viewing an R 18+ film or computer game at a retail store or cinema. Some material classified R 18+ may be offensive to sections of the adult community. The content is high in impact.", "client/images/ACB/R18.png", "Restricted R", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9020) },
                    { 24, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9030), "Contains material that is pornographic in nature. People under 18 may not legally buy, rent, possess, exhibit or view these films. The exhibition or sale of these films to people under the age of 18 years is a criminal offence carrying a maximum fine of $5,500. Films classified as X 18+ are banned (via state government legislation) from being sold or rented in all Australian states (but are legal to possess except in certain parts of the Northern Territory) and are legally available to purchase only in the Australian Capital Territory and the Northern Territory. Importing X 18+ material from these territories to any other state is legal (as the Australian Constitution forbids any restrictions on trade between the states and territories). The content is sexually explicit, and the rating does not exist for video games.", "client/images/ACB/X18.png", "Restricted X", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9033) },
                    { 25, 0, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9042), "Approved without age restriction in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games without age restriction are games which are directly aimed at children and young persons as well as at an adult buyer group.", "client/images/USK/0.png", "0", "Germany", "USK", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9045) },
                    { 16, 16, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8929), "The age 16 and older", "client/images/RARS/16+.png", "16+", "Russia", "RARS", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8932) },
                    { 27, 12, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9067), "Approved for children aged 12 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games feature much more of a competitive edge. Game scenarios contain little violence, enabling players to distance themselves sufficiently from events.", "client/images/USK/12.png", "12", "Germany", "USK", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9070) },
                    { 22, 15, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9005), "Contains material that is considered unsuitable for exhibition by persons under the age of 15. People under 15 may legally purchase, rent, exhibit or view such content only under the supervision of a parent or adult guardian. A person may be asked to show proof of age before renting or purchasing an MA 15+ film or computer game. The content is strong in impact.", "client/images/ACB/MA.png", "Mature Accompanied", "Australia", "ACB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9007) },
                    { 15, 12, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8917), "The age 12 and older", "client/images/RARS/12+.png", "12+", "Russia", "RARS", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8920) },
                    { 10, 12, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8855), "Video games that show violence of a slightly more graphic nature towards fantasy characters or non-realistic violence towards human-like characters would fall in this age category. Sexual innuendo or sexual posturing can be present, while any bad language in this category must be mild. Gambling as it is normally carried out in real life in casinos or gambling halls can also be present (e.g. card games that in real life would be played for money).", "client/images/PEGI/12.png", "PEGI 12", "EU", "PEGI", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8858) },
                    { 13, 0, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8892), "Any age", "client/images/RARS/0+.png", "0+", "Russia", "RARS", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8895) },
                    { 12, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8880), "The adult classification is applied when the level of violence reaches a stage where it becomes a depiction of gross violence, apparently motiveless killing, or violence towards defenceless characters. The glamorisation of the use of illegal drugs and explicit sexual activity should also fall into this age category.", "client/images/PEGI/18.png", "PEGI 18", "EU", "PEGI", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8882) },
                    { 11, 16, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8867), "This rating is applied once the depiction of violence (or sexual activity) reaches a stage that looks the same as would be expected in real life. The use of bad language in games with a PEGI 16 rating can be more extreme, while games of chance, and the use of tobacco, alcohol or illegal drugs can also be present.", "client/images/PEGI/16.png", "PEGI 16", "EU", "PEGI", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8870) },
                    { 28, 16, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9079), "Approved for children aged 16 and above in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  Games approved for children aged 16 and above may include acts of violence. This means that it is also natural for adults to buy them.", "client/images/USK/16.png", "16", "Germany", "USK", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9082) },
                    { 9, 7, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8842), "Game content with scenes or sounds that can possibly frightening to younger children should fall in this category. Very mild forms of violence (implied, non-detailed, or non-realistic violence) are acceptable for a game with a PEGI 7 rating.", "client/images/PEGI/7.png", "PEGI 7", "EU", "PEGI", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8845) },
                    { 8, 3, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8830), "The content of games with a PEGI 3 rating is considered suitable for all age groups. The game should not contain any sounds or pictures that are likely to frighten young children. A very mild form of violence (in a comical context or a childlike setting) is acceptable. No bad language should be heard.", "client/images/PEGI/3.png", "PEGI 3", "EU", "PEGI", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8833) },
                    { 7, -1, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8817), "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)", "client/images/ESRB/RP.png", "Rating Pending", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8820) },
                    { 6, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8805), "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "client/images/ESRB/Ao.png", "Adults Only 18+", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8808) },
                    { 5, 17, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8792), "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "client/images/ESRB/M.png", "Mature", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8795) },
                    { 4, 13, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8780), "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.", "client/images/ESRB/T.png", "Teen", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8783) },
                    { 3, 10, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8767), "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.", "client/images/ESRB/E10.png", "Everyone 10+", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8770) },
                    { 2, 6, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8747), "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.", "client/images/ESRB/E.png", "Everyone", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8753) },
                    { 1, 3, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(7909), "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.", "client/images/ESRB/eC.png", "Early Childhood", "USA", "ESRB", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8320) },
                    { 14, 6, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8905), "The age 6 and older", "client/images/RARS/6+.png", "6+", "Russia", "RARS", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(8908) },
                    { 29, 18, new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9092), "Not approved for anyone under 18 in accordance with Art. 14 German Children and Young Persons Protection Act (JuSchG).  These games almost always involve violent game concepts and frequently generate a dark and threatening atmosphere. This makes them suitable for adults only. These games often contain brutal, strong bloody violence and/or glorify war and/or human rights violations.", "client/images/USK/18.png", "18", "Germany", "USK", new DateTime(2019, 7, 2, 15, 38, 45, 90, DateTimeKind.Local).AddTicks(9095) }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "CheckedOutStatus", "CreatedAt", "EventId", "Name", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(9252), 1, "Demodepotna01", "Password1", new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(9632) },
                    { 2, false, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(330), 1, "Demodepotna02", "Password1", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(336) },
                    { 3, true, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(353), 2, "Demodepotna03", "Password1", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(356) }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "CreatedAt", "Name", "PlatformTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 22, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9887), "QQ", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9894) },
                    { 21, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9856), "Apple", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9864) },
                    { 19, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9795), "McAfee LiveSafe", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9803) },
                    { 18, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9765), "Amazon", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9772) },
                    { 20, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9826), "Eve Online", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9833) },
                    { 17, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9735), "Cryptic Studios", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9742) },
                    { 16, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9705), "Intel Appup", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9712) },
                    { 15, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9675), "League of Legends", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9682) },
                    { 14, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9644), "Lego Mini Online", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9652) },
                    { 13, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9614), "BattleNet", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9621) },
                    { 12, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9584), "Play Station", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9591) },
                    { 11, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9553), "Maniaplenet", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9561) },
                    { 10, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9523), "Standalone", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9530) },
                    { 9, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9493), "Epic", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9500) },
                    { 8, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9462), "Uplay", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9470) },
                    { 7, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9432), "Origin", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9439) },
                    { 6, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9401), "Oculus", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9409) },
                    { 5, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9371), "Steam VR", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9378) },
                    { 4, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9339), "Android", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9347) },
                    { 3, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(8916), "Windows", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(8923) },
                    { 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(8865), "Microsoft Store", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(8881) },
                    { 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(7160), "Steam", 1, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(8016) },
                    { 23, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9917), "Media Accounts", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9924) },
                    { 24, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9947), "Twitch", 2, new DateTime(2019, 7, 2, 15, 38, 45, 87, DateTimeKind.Local).AddTicks(9955) }
                });

            migrationBuilder.InsertData(
                table: "AccountPlatforms",
                columns: new[] { "AccountId", "PlatformId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountProfiles",
                columns: new[] { "AccountProfileId", "Address", "Birthday", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "SecretAnswer1", "SecretAnswer2", "SecretAnswer3", "SecretQuestion1", "SecretQuestion2", "SecretQuestion3", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(7162), new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(9819), "aaosd@daosp.asd", "Demo", "Depot", "asd", "", null, null, null, null, null, null, new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(169) },
                    { 2, null, new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(549), new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(589), "aaosd@daosp.asd", "Demo 1", "Depot", "asd", "", null, null, null, null, null, null, new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(595) },
                    { 3, null, new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(603), new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(608), "aaosd@daosp.asd", "Demo 2", "Depot", "asd", "", null, null, null, null, null, null, new DateTime(2019, 7, 2, 15, 38, 45, 93, DateTimeKind.Local).AddTicks(612) }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "ConnectionType", "CreatedAt", "Name", "PlatformId", "ReleaseDate", "URLToDocumentation", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, (byte)0, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(4728), "Game 1", 1, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(3972), "Location to Doc", new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(5267) },
                    { 3, (byte)2, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6423), "Game 3", 1, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6420), "Location to Doc", new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6426) },
                    { 2, (byte)1, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6396), "Game 2", 2, new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6386), "Location to Doc", new DateTime(2019, 7, 2, 15, 38, 45, 91, DateTimeKind.Local).AddTicks(6402) }
                });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "CodeId", "AccountId", "CodeString", "CreatedAt", "GameId", "UpdatedAt", "UsedStatus" },
                values: new object[,]
                {
                    { 1, 1, "Some Code 1", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(2478), 1, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(2852), true },
                    { 3, null, "Some Code 3", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4167), 1, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4170), false },
                    { 4, 2, "Some Code 4", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4180), 1, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4183), true },
                    { 8, null, "Some Code 8", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4229), 1, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4232), false },
                    { 5, null, "Some Code 5", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4192), 2, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4195), false },
                    { 2, 1, "Some Code 2", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4140), 2, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4147), true },
                    { 7, 3, "Some Code 7", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4217), 3, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4220), true },
                    { 6, null, "Some Code 6", new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4205), 3, new DateTime(2019, 7, 2, 15, 38, 45, 92, DateTimeKind.Local).AddTicks(4208), false }
                });

            migrationBuilder.InsertData(
                table: "GameAccounts",
                columns: new[] { "GameId", "AccountId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 3, 1 },
                    { 1, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "GameControllerTypes",
                columns: new[] { "GameId", "ControllerTypeId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "GameRatings",
                columns: new[] { "GameId", "RatingId" },
                values: new object[,]
                {
                    { 2, 10 },
                    { 1, 1 },
                    { 2, 8 },
                    { 1, 4 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPlatforms_PlatformId",
                table: "AccountPlatforms",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EventId",
                table: "Accounts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_AccountId",
                table: "Codes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_GameId",
                table: "Codes",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameAccounts_AccountId",
                table: "GameAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameControllerTypes_ControllerTypeId",
                table: "GameControllerTypes",
                column: "ControllerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRatings_RatingId",
                table: "GameRatings",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformId",
                table: "Games",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_PlatformTypeId",
                table: "Platforms",
                column: "PlatformTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPlatforms");

            migrationBuilder.DropTable(
                name: "AccountProfiles");

            migrationBuilder.DropTable(
                name: "Codes");

            migrationBuilder.DropTable(
                name: "GameAccounts");

            migrationBuilder.DropTable(
                name: "GameControllerTypes");

            migrationBuilder.DropTable(
                name: "GameRatings");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ControllerTypes");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "PlatformTypes");
        }
    }
}
