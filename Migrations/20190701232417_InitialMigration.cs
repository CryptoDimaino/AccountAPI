using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountAPI.Migrations
{
    public partial class InitialMigration : Migration
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
                    { 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(4630), "Touch", new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(4936) },
                    { 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5238), "Keyboard & Mouse", new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5243) },
                    { 3, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5254), "Xbox", new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5257) },
                    { 4, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5265), "Steering Wheel", new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(5267) }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreatedAt", "Location", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(7436), "Chicago", "IEM", new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(7727) });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "PlatformTypeId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 1, 16, 24, 17, 294, DateTimeKind.Local).AddTicks(6570), "Game", new DateTime(2019, 7, 1, 16, 24, 17, 294, DateTimeKind.Local).AddTicks(6917) },
                    { 2, new DateTime(2019, 7, 1, 16, 24, 17, 294, DateTimeKind.Local).AddTicks(7243), "Other", new DateTime(2019, 7, 1, 16, 24, 17, 294, DateTimeKind.Local).AddTicks(7249) }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Age", "CreatedAt", "Definition", "ImageLink", "Name", "RatingsCountry", "RatingsSystem", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(1597), "Titles rated EC (Early Childhood) have content that may be suitable for ages 3 and older. Contains no material that parents would find inappropriate.", "Link to image", "Early Childhood", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(1889) },
                    { 2, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2194), "Titles rated E (Everyone) have content that is generally suitable for all ages. May contain minimal cartoon, fantasy or mild violence and/or infrequent use of mild language.", "Link to image", "Everyone", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2199) },
                    { 3, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2211), "Titles rated E10+ (Everyone 10 and older) have content that is generally suitable for ages 10 and up. May contain more cartoon, fantasy or mild violence, mild language and/or minimal suggestive themes.themes.", "Link to image", "Everyone 10+", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2214) },
                    { 4, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2222), "Titles rated T (Teen) have content that is generally suitable for ages 13 and up. May contain violence, suggestive themes, crude humor, minimal blood, simulated gambling, and/or infrequent use of strong language.", "Link to image", "Teen", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2225) },
                    { 5, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2235), "Titles rated M (Mature) have content that is generally suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "Link to image", "Mature", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2237) },
                    { 6, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2245), "Titles rated AO (Adults Only) have content that is only suitable for persons ages 17 and up. May contain intense violence, blood and gore, sexual content and/or strong language.", "Link to image", "Adults Only 18+", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2248) },
                    { 7, 0, new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2256), "Titles listed as RP (Rating Pending) have not yet been assigned a final ESRB rating. (This symbol appears only in advertising and promotional materials prior to a game's release, and will be replaced by a game’s rating once it has been assigned.)", "Link to image", "Rating Pending", "USA", "ESRB", new DateTime(2019, 7, 1, 16, 24, 17, 296, DateTimeKind.Local).AddTicks(2258) }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "CreatedAt", "Name", "PlatformTypeId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(1217), "Steam", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(1529) },
                    { 22, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2259), "QQ", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2262) },
                    { 21, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2249), "Apple", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2251) },
                    { 19, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2228), "McAfee LiveSafe", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2230) },
                    { 18, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2217), "Amazon", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2220) },
                    { 20, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2238), "Eve Online", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2241) },
                    { 17, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2207), "Cryptic Studios", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2209) },
                    { 16, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2196), "Intel Appup", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2199) },
                    { 15, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2186), "League of Legends", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2189) },
                    { 14, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2175), "Lego Mini Online", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2178) },
                    { 13, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2165), "BattleNet", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2167) },
                    { 12, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2154), "Play Station", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2157) },
                    { 11, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2144), "Maniaplenet", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2146) },
                    { 10, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2134), "Standalone", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2136) },
                    { 9, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2123), "Epic", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2126) },
                    { 8, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2113), "Uplay", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2115) },
                    { 7, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2102), "Origin", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2105) },
                    { 6, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2091), "Oculus", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2094) },
                    { 5, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2081), "Steam VR", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2083) },
                    { 4, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2070), "Android", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2073) },
                    { 3, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2060), "Windows", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2062) },
                    { 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2043), "Microsoft Store", 1, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2048) },
                    { 23, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2271), "Media Accounts", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2273) },
                    { 24, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2281), "Twitch", 2, new DateTime(2019, 7, 1, 16, 24, 17, 295, DateTimeKind.Local).AddTicks(2283) }
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
