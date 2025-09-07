using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoCivique = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Province = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borne",
                columns: table => new
                {
                    BorneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeConnecteur = table.Column<int>(type: "int", nullable: false),
                    PuissanceKW = table.Column<double>(type: "float", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borne", x => x.BorneId);
                    table.ForeignKey(
                        name: "FK_Borne_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorneUtilisateurs",
                columns: table => new
                {
                    BorneId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<double>(type: "float", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstFavoris = table.Column<bool>(type: "bit", nullable: false),
                    DateAjoutFavori = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorneUtilisateurs", x => new { x.BorneId, x.UtilisateurId });
                    table.ForeignKey(
                        name: "FK_BorneUtilisateurs_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorneUtilisateurs_Borne_BorneId",
                        column: x => x.BorneId,
                        principalTable: "Borne",
                        principalColumn: "BorneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilites",
                columns: table => new
                {
                    DisponibiliteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorneId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilites", x => x.DisponibiliteId);
                    table.ForeignKey(
                        name: "FK_Disponibilites_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disponibilites_Borne_BorneId",
                        column: x => x.BorneId,
                        principalTable: "Borne",
                        principalColumn: "BorneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseId", "CodePostal", "Latitude", "Longitude", "NoCivique", "Province", "Rue", "Ville" },
                values: new object[,]
                {
                    { 1, "J0H 1S0", 45.590083399999997, -73.093208000000004, "200", 9, "Rue Morier", "Sainte-Madeleine" },
                    { 2, "G1R 1P4", 46.813878299999999, -71.207980899999995, "300", 9, "Rue Saint-Jean", "Québec" },
                    { 3, "H2W 1S4", 45.519280000000002, -73.589378999999994, "500", 9, "Avenue du Parc", "Montréal" },
                    { 4, "G1V 4H3", 46.776029999999999, -71.271308000000005, "600", 9, "Boulevard Laurier", "Québec" },
                    { 5, "H2X 3K2", 45.512144999999997, -73.563441999999995, "700", 9, "Rue Saint-Denis", "Montréal" },
                    { 6, "H3A 1G3", 45.504859000000003, -73.574924999999993, "800", 9, "Rue Sherbrooke", "Montréal" },
                    { 7, "H3B 1A4", 45.498314999999998, -73.566754000000003, "900", 9, "Rue Sainte-Catherine", "Montréal" },
                    { 8, "G1R 5P1", 46.805804999999999, -71.225488999999996, "1000", 9, "Boulevard René-Lévesque", "Québec" },
                    { 9, "G1N 2E5", 46.798437999999997, -71.236394000000004, "1100", 9, "Boulevard Charest", "Québec" },
                    { 10, "G1S 4R1", 46.775084, -71.297023999999993, "1200", 9, "Chemin Sainte-Foy", "Québec" },
                    { 11, "G1V 2M2", 46.767600000000002, -71.282300000000006, "222", 9, "Boulevard Laurier", "Québec" },
                    { 12, "G1S 2J4", 46.7896, -71.254099999999994, "333", 9, "Chemin Sainte-Foy", "Québec" },
                    { 13, "G1R 2S3", 46.807600000000001, -71.222499999999997, "444", 9, "Avenue Cartier", "Québec" },
                    { 14, "G1K 6E2", 46.814999999999998, -71.213399999999993, "555", 9, "Rue de la Couronne", "Québec" },
                    { 15, "G1K 3A5", 46.812600000000003, -71.216899999999995, "666", 9, "Rue Saint-Joseph Est", "Québec" },
                    { 16, "G9A 6N3", 46.345199999999998, -72.547700000000006, "777", 9, "Rue Saint-Dominique", "Trois-Rivières" },
                    { 17, "G9A 5H9", 46.338099999999997, -72.540000000000006, "888", 9, "Rue des Forges", "Trois-Rivières" },
                    { 18, "G9A 6B1", 46.347700000000003, -72.548400000000001, "999", 9, "Boulevard des Récollets", "Trois-Rivières" },
                    { 19, "G9A 3P6", 46.332500000000003, -72.548699999999997, "1010", 9, "Rue Saint-Maurice", "Trois-Rivières" },
                    { 20, "G9A 4J6", 46.335799999999999, -72.539299999999997, "1111", 9, "Rue Notre-Dame Centre", "Trois-Rivières" },
                    { 21, "G9A 4H8", 46.341299999999997, -72.5458, "1212", 9, "Rue Royale", "Trois-Rivières" },
                    { 22, "G8Y 4E4", 46.3401, -72.548900000000003, "1313", 9, "Boulevard Sainte-Madeleine", "Trois-Rivières" },
                    { 23, "G9N 6T5", 46.564900000000002, -72.746300000000005, "1414", 9, "Boulevard du Saint-Maurice", "Shawinigan" },
                    { 24, "G9N 6M9", 46.564799999999998, -72.744500000000002, "1515", 9, "Boulevard des Hêtres", "Shawinigan" },
                    { 25, "G9N 6R6", 46.566899999999997, -72.745199999999997, "1616", 9, "Boulevard du Capitaine", "Shawinigan" },
                    { 26, "G9N 6E7", 46.567, -72.741299999999995, "1717", 9, "Rue de l'Anse", "Shawinigan" },
                    { 27, "G9N 6M3", 46.564599999999999, -72.742999999999995, "1818", 9, "Rue de l'Église", "Shawinigan" },
                    { 28, "G9N 6N4", 46.566499999999998, -72.745999999999995, "1919", 9, "Rue Saint-Joseph", "Shawinigan" },
                    { 29, "G9N 6G3", 46.564700000000002, -72.746200000000002, "2020", 9, "Avenue Saint-Charles", "Shawinigan" },
                    { 30, "G9N 6J4", 46.564999999999998, -72.748699999999999, "2121", 9, "Rue des Érables", "Shawinigan" },
                    { 31, "G9N 6L3", 46.566200000000002, -72.743399999999994, "2222", 9, "Rue du Centre", "Shawinigan" },
                    { 32, "G9N 6N9", 46.566699999999997, -72.742000000000004, "2323", 9, "Rue Saint-Marc", "Shawinigan" },
                    { 33, "G9N 6J8", 46.565899999999999, -72.743700000000004, "2424", 9, "Rue des Pins", "Shawinigan" },
                    { 34, "G9N 6E5", 46.566800000000001, -72.746499999999997, "2525", 9, "Rue Saint-Jean-Baptiste", "Shawinigan" },
                    { 35, "G9N 6T9", 46.5672, -72.746899999999997, "2626", 9, "Boulevard Saint-Michel", "Shawinigan" },
                    { 36, "G9N 6M6", 46.565399999999997, -72.747100000000003, "2727", 9, "Rue Saint-Pierre", "Shawinigan" },
                    { 37, "G9A 6M3", 46.338000000000001, -72.548900000000003, "2828", 9, "Rue Notre-Dame", "Trois-Rivières" },
                    { 38, "G9A 6T8", 46.335799999999999, -72.549700000000001, "2929", 9, "Boulevard des Chenaux", "Trois-Rivières" },
                    { 39, "G9A 6N5", 46.334800000000001, -72.540199999999999, "3030", 9, "Rue de la Commune", "Trois-Rivières" },
                    { 40, "G9A 6S7", 46.340699999999998, -72.547499999999999, "3131", 9, "Boulevard des Forges", "Trois-Rivières" },
                    { 41, "G9A 6T2", 46.3384, -72.540700000000001, "3232", 9, "Boulevard du Saint-Laurent", "Trois-Rivières" },
                    { 42, "G9A 6J3", 46.332900000000002, -72.545299999999997, "3333", 9, "Rue Saint-Roch", "Trois-Rivières" }
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseId", "CodePostal", "Latitude", "Longitude", "NoCivique", "Province", "Rue", "Ville" },
                values: new object[,]
                {
                    { 43, "G9A 6T4", 46.347000000000001, -72.548500000000004, "3434", 9, "Boulevard des Récollets", "Trois-Rivières" },
                    { 44, "G9A 6K7", 46.347499999999997, -72.5471, "3535", 9, "Boulevard des Récollets", "Trois-Rivières" },
                    { 45, "G9A 6N7", 46.334000000000003, -72.540400000000005, "3636", 9, "Boulevard des Chenaux", "Trois-Rivières" },
                    { 46, "G9A 6S8", 46.340600000000002, -72.549000000000007, "3737", 9, "Boulevard des Récollets", "Trois-Rivières" },
                    { 47, "G9A 6J6", 46.340899999999998, -72.548299999999998, "3838", 9, "Boulevard des Récollets", "Trois-Rivières" },
                    { 48, "G9A 6N1", 46.339300000000001, -72.548000000000002, "3939", 9, "Boulevard du Saint-Maurice", "Trois-Rivières" },
                    { 49, "G9A 6K8", 46.3354, -72.541600000000003, "4040", 9, "Rue de la Commune", "Trois-Rivières" },
                    { 50, "G9A 6M8", 46.339399999999998, -72.540899999999993, "4141", 9, "Boulevard des Chenaux", "Trois-Rivières" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "432fe4df-2749-4bc1-a212-72a16b66f165", "user1@example.com", false, "John", "Doe", false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", null, null, false, "f0ad4fb9-c498-4197-b2d3-442071148b8d", false, "user1@example.com" },
                    { "2", 0, "f808ba52-a61c-4cbb-89a3-06a070cc7859", "user2@example.com", false, "Jane", "Doe", false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", null, null, false, "872f091e-1d6b-445c-b0dd-eed8ab8e61e5", false, "user2@example.com" },
                    { "3", 0, "809d5cbf-5523-4927-9a5a-988aa8e654eb", "user3@example.com", false, "Pierre", "Doe", false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", null, null, false, "65fdee27-65ad-4c3d-827d-dda908abeaee", false, "user3@example.com" },
                    { "4", 0, "d16968cf-f170-4133-acd2-631d48dda144", "user4@example.com", false, "Paul", "Doe", false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", null, null, false, "917ea97b-ec05-4c5d-8cdf-231c60e9bb71", false, "user4@example.com" },
                    { "5", 0, "fe68c36e-b7f0-4bb7-bc1b-6cb8373cc9ee", "user5@example.com", false, "Richard", "Doe", false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", null, null, false, "86e4569e-b836-49c5-acbf-15b9ba5e5f53", false, "user5@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Borne",
                columns: new[] { "BorneId", "AdresseId", "DateCreation", "PuissanceKW", "TypeConnecteur" },
                values: new object[,]
                {
                    { 1, 44, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3704), 85.0, 0 },
                    { 2, 31, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3750), 52.0, 0 },
                    { 3, 19, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3760), 19.0, 0 },
                    { 4, 25, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3768), 51.0, 1 },
                    { 5, 18, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3775), 85.0, 1 },
                    { 6, 29, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3784), 21.0, 0 },
                    { 7, 40, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3792), 88.0, 0 },
                    { 8, 8, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3800), 44.0, 0 },
                    { 9, 50, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3835), 90.0, 0 },
                    { 10, 6, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3846), 24.0, 0 },
                    { 11, 32, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3854), 67.0, 1 },
                    { 12, 27, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3861), 11.0, 0 },
                    { 13, 2, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3869), 65.0, 0 },
                    { 14, 41, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3877), 100.0, 1 },
                    { 15, 45, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3884), 33.0, 0 },
                    { 16, 48, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3891), 18.0, 1 },
                    { 17, 21, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3900), 67.0, 1 },
                    { 18, 47, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3908), 38.0, 1 },
                    { 19, 43, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3917), 38.0, 1 },
                    { 20, 22, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3924), 85.0, 1 },
                    { 21, 14, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3931), 22.0, 1 },
                    { 22, 4, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3939), 20.0, 0 },
                    { 23, 26, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3947), 68.0, 1 },
                    { 24, 42, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3954), 72.0, 1 },
                    { 25, 46, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3962), 32.0, 1 },
                    { 26, 37, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3970), 43.0, 1 },
                    { 27, 15, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3977), 95.0, 1 },
                    { 28, 11, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3985), 62.0, 0 },
                    { 29, 36, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(3993), 27.0, 0 },
                    { 30, 7, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4000), 31.0, 1 },
                    { 31, 17, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4007), 71.0, 1 },
                    { 32, 34, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4015), 36.0, 0 },
                    { 33, 24, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4022), 44.0, 1 },
                    { 34, 38, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4060), 51.0, 0 },
                    { 35, 3, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4067), 22.0, 1 },
                    { 36, 28, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4075), 50.0, 1 },
                    { 37, 9, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4082), 32.0, 0 },
                    { 38, 35, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4090), 99.0, 0 },
                    { 39, 30, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4097), 54.0, 1 },
                    { 40, 10, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4105), 79.0, 1 },
                    { 41, 16, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4112), 91.0, 0 },
                    { 42, 12, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4120), 11.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Borne",
                columns: new[] { "BorneId", "AdresseId", "DateCreation", "PuissanceKW", "TypeConnecteur" },
                values: new object[,]
                {
                    { 43, 1, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4128), 32.0, 1 },
                    { 44, 39, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4135), 11.0, 1 },
                    { 45, 13, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4143), 82.0, 0 },
                    { 46, 20, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4150), 47.0, 0 },
                    { 47, 23, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4158), 22.0, 0 },
                    { 48, 5, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4165), 10.0, 0 },
                    { 49, 33, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4173), 41.0, 0 },
                    { 50, 49, new DateTime(2025, 9, 6, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4180), 57.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "BorneUtilisateurs",
                columns: new[] { "BorneId", "UtilisateurId", "Commentaire", "DateAjoutFavori", "DateEvaluation", "EstFavoris", "Id", "Note" },
                values: new object[,]
                {
                    { 1, "1", "Évaluation pour la borne 1 par utilisateur 1", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4412), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4409), true, 2, 4.0 },
                    { 1, "2", "Évaluation pour la borne 1 par utilisateur 2", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4426), new DateTime(2025, 8, 19, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4424), false, 3, 2.0 },
                    { 1, "4", "Évaluation pour la borne 1 par utilisateur 4", null, new DateTime(2025, 8, 13, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4378), true, 1, 2.0 },
                    { 2, "1", "Évaluation pour la borne 2 par utilisateur 1", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4527), new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4524), false, 4, 4.0 },
                    { 2, "2", "Évaluation pour la borne 2 par utilisateur 2", null, new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4557), false, 6, 3.0 },
                    { 2, "3", "Évaluation pour la borne 2 par utilisateur 3", new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4543), new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4542), false, 5, 3.0 },
                    { 3, "1", "Évaluation pour la borne 3 par utilisateur 1", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4618), new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4616), true, 9, 5.0 },
                    { 3, "3", "Évaluation pour la borne 3 par utilisateur 3", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4592), new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4589), true, 7, 1.0 },
                    { 3, "4", "Évaluation pour la borne 3 par utilisateur 4", null, new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4605), false, 8, 3.0 },
                    { 4, "1", "Évaluation pour la borne 4 par utilisateur 1", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4672), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4670), true, 12, 2.0 },
                    { 4, "2", "Évaluation pour la borne 4 par utilisateur 2", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4659), new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4658), true, 11, 2.0 },
                    { 4, "5", "Évaluation pour la borne 4 par utilisateur 5", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4647), new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4645), false, 10, 4.0 },
                    { 5, "1", "Évaluation pour la borne 5 par utilisateur 1", null, new DateTime(2025, 8, 17, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4705), false, 14, 2.0 },
                    { 5, "3", "Évaluation pour la borne 5 par utilisateur 3", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4718), new DateTime(2025, 8, 19, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4716), true, 15, 2.0 },
                    { 5, "4", "Évaluation pour la borne 5 par utilisateur 4", new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4694), new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4692), false, 13, 5.0 },
                    { 6, "1", "Évaluation pour la borne 6 par utilisateur 1", new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4800), new DateTime(2025, 8, 15, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4798), false, 18, 3.0 },
                    { 6, "2", "Évaluation pour la borne 6 par utilisateur 2", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4744), new DateTime(2025, 8, 17, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4742), true, 16, 1.0 },
                    { 6, "4", "Évaluation pour la borne 6 par utilisateur 4", null, new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4782), false, 17, 5.0 },
                    { 7, "3", "Évaluation pour la borne 7 par utilisateur 3", null, new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4837), true, 20, 1.0 },
                    { 7, "4", "Évaluation pour la borne 7 par utilisateur 4", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4850), new DateTime(2025, 8, 8, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4848), true, 21, 5.0 },
                    { 7, "5", "Évaluation pour la borne 7 par utilisateur 5", null, new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4826), false, 19, 1.0 },
                    { 8, "2", "Évaluation pour la borne 8 par utilisateur 2", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4887), new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4885), false, 23, 3.0 },
                    { 8, "3", "Évaluation pour la borne 8 par utilisateur 3", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4875), new DateTime(2025, 8, 17, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4873), false, 22, 1.0 },
                    { 8, "5", "Évaluation pour la borne 8 par utilisateur 5", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4900), new DateTime(2025, 8, 17, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4898), true, 24, 1.0 },
                    { 9, "2", "Évaluation pour la borne 9 par utilisateur 2", null, new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4925), false, 25, 4.0 },
                    { 9, "3", "Évaluation pour la borne 9 par utilisateur 3", null, new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4948), true, 27, 1.0 },
                    { 9, "5", "Évaluation pour la borne 9 par utilisateur 5", null, new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4937), false, 26, 2.0 },
                    { 10, "1", "Évaluation pour la borne 10 par utilisateur 1", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5001), new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(4998), false, 28, 3.0 },
                    { 10, "2", "Évaluation pour la borne 10 par utilisateur 2", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5027), new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5026), false, 30, 3.0 },
                    { 10, "5", "Évaluation pour la borne 10 par utilisateur 5", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5015), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5013), false, 29, 1.0 },
                    { 11, "2", "Évaluation pour la borne 11 par utilisateur 2", null, new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5066), false, 32, 3.0 },
                    { 11, "3", "Évaluation pour la borne 11 par utilisateur 3", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5078), new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5077), false, 33, 4.0 },
                    { 11, "5", "Évaluation pour la borne 11 par utilisateur 5", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5054), new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5052), false, 31, 3.0 },
                    { 12, "3", "Évaluation pour la borne 12 par utilisateur 3", null, new DateTime(2025, 9, 3, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5117), false, 35, 3.0 },
                    { 12, "4", "Évaluation pour la borne 12 par utilisateur 4", null, new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5127), false, 36, 4.0 },
                    { 12, "5", "Évaluation pour la borne 12 par utilisateur 5", new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5106), new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5103), false, 34, 5.0 },
                    { 13, "1", "Évaluation pour la borne 13 par utilisateur 1", null, new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5148), true, 37, 2.0 },
                    { 13, "3", "Évaluation pour la borne 13 par utilisateur 3", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5209), new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5207), false, 39, 1.0 },
                    { 13, "4", "Évaluation pour la borne 13 par utilisateur 4", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5195), new DateTime(2025, 8, 12, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5193), false, 38, 2.0 },
                    { 14, "1", "Évaluation pour la borne 14 par utilisateur 1", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5261), false, 42, 5.0 },
                    { 14, "3", "Évaluation pour la borne 14 par utilisateur 3", new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5237), new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5235), false, 40, 2.0 },
                    { 14, "4", "Évaluation pour la borne 14 par utilisateur 4", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5250), new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5248), true, 41, 4.0 }
                });

            migrationBuilder.InsertData(
                table: "BorneUtilisateurs",
                columns: new[] { "BorneId", "UtilisateurId", "Commentaire", "DateAjoutFavori", "DateEvaluation", "EstFavoris", "Id", "Note" },
                values: new object[,]
                {
                    { 15, "1", "Évaluation pour la borne 15 par utilisateur 1", null, new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5311), false, 45, 4.0 },
                    { 15, "3", "Évaluation pour la borne 15 par utilisateur 3", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5287), new DateTime(2025, 8, 11, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5285), false, 43, 5.0 },
                    { 15, "5", "Évaluation pour la borne 15 par utilisateur 5", new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5301), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5298), true, 44, 5.0 },
                    { 16, "1", "Évaluation pour la borne 16 par utilisateur 1", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5357), new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5355), true, 48, 1.0 },
                    { 16, "2", "Évaluation pour la borne 16 par utilisateur 2", null, new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5333), false, 46, 5.0 },
                    { 16, "5", "Évaluation pour la borne 16 par utilisateur 5", null, new DateTime(2025, 8, 14, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5344), true, 47, 3.0 },
                    { 17, "3", "Évaluation pour la borne 17 par utilisateur 3", new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5407), new DateTime(2025, 8, 11, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5405), false, 51, 1.0 },
                    { 17, "4", "Évaluation pour la borne 17 par utilisateur 4", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5381), false, 49, 2.0 },
                    { 17, "5", "Évaluation pour la borne 17 par utilisateur 5", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5394), new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5392), false, 50, 1.0 },
                    { 18, "3", "Évaluation pour la borne 18 par utilisateur 3", null, new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5480), false, 54, 5.0 },
                    { 18, "4", "Évaluation pour la borne 18 par utilisateur 4", null, new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5455), true, 52, 5.0 },
                    { 18, "5", "Évaluation pour la borne 18 par utilisateur 5", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5470), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5468), false, 53, 2.0 },
                    { 19, "1", "Évaluation pour la borne 19 par utilisateur 1", null, new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5517), true, 56, 5.0 },
                    { 19, "2", "Évaluation pour la borne 19 par utilisateur 2", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5505), true, 55, 2.0 },
                    { 19, "4", "Évaluation pour la borne 19 par utilisateur 4", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5530), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5528), false, 57, 4.0 },
                    { 20, "1", "Évaluation pour la borne 20 par utilisateur 1", null, new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5565), false, 59, 5.0 },
                    { 20, "3", "Évaluation pour la borne 20 par utilisateur 3", null, new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5554), false, 58, 3.0 },
                    { 20, "5", "Évaluation pour la borne 20 par utilisateur 5", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5578), new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5576), false, 60, 3.0 },
                    { 21, "1", "Évaluation pour la borne 21 par utilisateur 1", null, new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5624), false, 63, 1.0 },
                    { 21, "2", "Évaluation pour la borne 21 par utilisateur 2", null, new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5613), true, 62, 1.0 },
                    { 21, "4", "Évaluation pour la borne 21 par utilisateur 4", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5601), new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5599), true, 61, 2.0 },
                    { 22, "3", "Évaluation pour la borne 22 par utilisateur 3", null, new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5648), true, 64, 5.0 },
                    { 22, "4", "Évaluation pour la borne 22 par utilisateur 4", null, new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5686), false, 65, 1.0 },
                    { 22, "5", "Évaluation pour la borne 22 par utilisateur 5", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5704), new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5702), false, 66, 1.0 },
                    { 23, "1", "Évaluation pour la borne 23 par utilisateur 1", null, new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5729), false, 67, 5.0 },
                    { 23, "4", "Évaluation pour la borne 23 par utilisateur 4", null, new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5753), false, 69, 5.0 },
                    { 23, "5", "Évaluation pour la borne 23 par utilisateur 5", new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5742), new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5740), true, 68, 3.0 },
                    { 24, "1", "Évaluation pour la borne 24 par utilisateur 1", null, new DateTime(2025, 8, 13, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5773), false, 70, 2.0 },
                    { 24, "3", "Évaluation pour la borne 24 par utilisateur 3", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5786), false, 71, 4.0 },
                    { 24, "4", "Évaluation pour la borne 24 par utilisateur 4", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5796), true, 72, 3.0 },
                    { 25, "1", "Évaluation pour la borne 25 par utilisateur 1", null, new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5819), true, 73, 3.0 },
                    { 25, "3", "Évaluation pour la borne 25 par utilisateur 3", null, new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5831), true, 74, 2.0 },
                    { 25, "4", "Évaluation pour la borne 25 par utilisateur 4", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5844), new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5842), false, 75, 2.0 },
                    { 26, "2", "Évaluation pour la borne 26 par utilisateur 2", null, new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5919), true, 78, 1.0 },
                    { 26, "3", "Évaluation pour la borne 26 par utilisateur 3", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5867), new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5865), false, 76, 1.0 },
                    { 26, "4", "Évaluation pour la borne 26 par utilisateur 4", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5908), new DateTime(2025, 8, 8, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5906), false, 77, 2.0 },
                    { 27, "2", "Évaluation pour la borne 27 par utilisateur 2", null, new DateTime(2025, 8, 15, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5945), true, 79, 2.0 },
                    { 27, "4", "Évaluation pour la borne 27 par utilisateur 4", null, new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5968), false, 81, 1.0 },
                    { 27, "5", "Évaluation pour la borne 27 par utilisateur 5", null, new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5957), false, 80, 2.0 },
                    { 28, "1", "Évaluation pour la borne 28 par utilisateur 1", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5994), new DateTime(2025, 8, 12, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(5992), false, 82, 1.0 },
                    { 28, "2", "Évaluation pour la borne 28 par utilisateur 2", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6007), new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6005), true, 83, 1.0 },
                    { 28, "5", "Évaluation pour la borne 28 par utilisateur 5", null, new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6017), false, 84, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "BorneUtilisateurs",
                columns: new[] { "BorneId", "UtilisateurId", "Commentaire", "DateAjoutFavori", "DateEvaluation", "EstFavoris", "Id", "Note" },
                values: new object[,]
                {
                    { 29, "1", "Évaluation pour la borne 29 par utilisateur 1", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6054), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6052), false, 86, 2.0 },
                    { 29, "2", "Évaluation pour la borne 29 par utilisateur 2", null, new DateTime(2025, 8, 19, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6065), false, 87, 1.0 },
                    { 29, "5", "Évaluation pour la borne 29 par utilisateur 5", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6041), new DateTime(2025, 8, 13, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6039), true, 85, 5.0 },
                    { 30, "2", "Évaluation pour la borne 30 par utilisateur 2", null, new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6090), false, 88, 1.0 },
                    { 30, "3", "Évaluation pour la borne 30 par utilisateur 3", null, new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6148), true, 90, 2.0 },
                    { 30, "5", "Évaluation pour la borne 30 par utilisateur 5", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6102), false, 89, 3.0 },
                    { 31, "1", "Évaluation pour la borne 31 par utilisateur 1", new DateTime(2025, 9, 3, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6192), new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6190), true, 92, 4.0 },
                    { 31, "2", "Évaluation pour la borne 31 par utilisateur 2", null, new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6203), false, 93, 3.0 },
                    { 31, "4", "Évaluation pour la borne 31 par utilisateur 4", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6179), new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6177), true, 91, 4.0 },
                    { 32, "1", "Évaluation pour la borne 32 par utilisateur 1", null, new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6225), false, 94, 5.0 },
                    { 32, "4", "Évaluation pour la borne 32 par utilisateur 4", null, new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6247), false, 96, 4.0 },
                    { 32, "5", "Évaluation pour la borne 32 par utilisateur 5", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6236), true, 95, 3.0 },
                    { 33, "2", "Évaluation pour la borne 33 par utilisateur 2", null, new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6314), false, 97, 1.0 },
                    { 33, "3", "Évaluation pour la borne 33 par utilisateur 3", null, new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6341), true, 99, 5.0 },
                    { 33, "5", "Évaluation pour la borne 33 par utilisateur 5", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6331), new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6329), true, 98, 4.0 },
                    { 34, "1", "Évaluation pour la borne 34 par utilisateur 1", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6367), new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6365), true, 100, 5.0 },
                    { 34, "2", "Évaluation pour la borne 34 par utilisateur 2", new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6380), new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6378), true, 101, 2.0 },
                    { 34, "3", "Évaluation pour la borne 34 par utilisateur 3", null, new DateTime(2025, 8, 14, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6390), false, 102, 5.0 },
                    { 35, "1", "Évaluation pour la borne 35 par utilisateur 1", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6417), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6415), false, 103, 3.0 },
                    { 35, "2", "Évaluation pour la borne 35 par utilisateur 2", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6430), new DateTime(2025, 8, 18, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6428), true, 104, 3.0 },
                    { 35, "4", "Évaluation pour la borne 35 par utilisateur 4", new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6442), new DateTime(2025, 8, 18, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6440), false, 105, 5.0 },
                    { 36, "1", "Évaluation pour la borne 36 par utilisateur 1", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6481), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6479), true, 107, 2.0 },
                    { 36, "2", "Évaluation pour la borne 36 par utilisateur 2", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6468), new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6466), false, 106, 4.0 },
                    { 36, "5", "Évaluation pour la borne 36 par utilisateur 5", new DateTime(2025, 8, 31, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6493), new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6491), false, 108, 2.0 },
                    { 37, "1", "Évaluation pour la borne 37 par utilisateur 1", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6528), new DateTime(2025, 8, 17, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6525), true, 110, 1.0 },
                    { 37, "4", "Évaluation pour la borne 37 par utilisateur 4", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6540), new DateTime(2025, 8, 12, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6538), true, 111, 3.0 },
                    { 37, "5", "Évaluation pour la borne 37 par utilisateur 5", null, new DateTime(2025, 8, 25, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6514), false, 109, 2.0 },
                    { 38, "2", "Évaluation pour la borne 38 par utilisateur 2", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6620), new DateTime(2025, 8, 11, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6618), false, 114, 2.0 },
                    { 38, "3", "Évaluation pour la borne 38 par utilisateur 3", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6595), new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6593), false, 112, 4.0 },
                    { 38, "5", "Évaluation pour la borne 38 par utilisateur 5", null, new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6607), false, 113, 1.0 },
                    { 39, "2", "Évaluation pour la borne 39 par utilisateur 2", null, new DateTime(2025, 8, 14, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6667), false, 117, 2.0 },
                    { 39, "3", "Évaluation pour la borne 39 par utilisateur 3", null, new DateTime(2025, 8, 15, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6656), false, 116, 4.0 },
                    { 39, "5", "Évaluation pour la borne 39 par utilisateur 5", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6646), new DateTime(2025, 8, 10, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6644), true, 115, 3.0 },
                    { 40, "1", "Évaluation pour la borne 40 par utilisateur 1", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6702), new DateTime(2025, 8, 11, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6700), true, 119, 3.0 },
                    { 40, "3", "Évaluation pour la borne 40 par utilisateur 3", null, new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6689), false, 118, 3.0 },
                    { 40, "5", "Évaluation pour la borne 40 par utilisateur 5", null, new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6713), false, 120, 4.0 },
                    { 41, "1", "Évaluation pour la borne 41 par utilisateur 1", new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6739), new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6737), true, 121, 2.0 },
                    { 41, "4", "Évaluation pour la borne 41 par utilisateur 4", null, new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6761), false, 123, 2.0 },
                    { 41, "5", "Évaluation pour la borne 41 par utilisateur 5", null, new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6750), false, 122, 2.0 },
                    { 42, "3", "Évaluation pour la borne 42 par utilisateur 3", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6825), new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6823), true, 125, 5.0 },
                    { 42, "4", "Évaluation pour la borne 42 par utilisateur 4", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6838), new DateTime(2025, 8, 8, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6836), false, 126, 2.0 },
                    { 42, "5", "Évaluation pour la borne 42 par utilisateur 5", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6784), new DateTime(2025, 9, 2, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6782), true, 124, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "BorneUtilisateurs",
                columns: new[] { "BorneId", "UtilisateurId", "Commentaire", "DateAjoutFavori", "DateEvaluation", "EstFavoris", "Id", "Note" },
                values: new object[,]
                {
                    { 43, "2", "Évaluation pour la borne 43 par utilisateur 2", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6877), new DateTime(2025, 9, 3, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6876), false, 128, 3.0 },
                    { 43, "3", "Évaluation pour la borne 43 par utilisateur 3", null, new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6888), true, 129, 5.0 },
                    { 43, "4", "Évaluation pour la borne 43 par utilisateur 4", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6865), new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6863), false, 127, 2.0 },
                    { 44, "1", "Évaluation pour la borne 44 par utilisateur 1", new DateTime(2025, 8, 29, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6916), new DateTime(2025, 8, 21, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6914), true, 130, 3.0 },
                    { 44, "4", "Évaluation pour la borne 44 par utilisateur 4", null, new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6939), false, 132, 3.0 },
                    { 44, "5", "Évaluation pour la borne 44 par utilisateur 5", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6929), new DateTime(2025, 8, 12, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6927), false, 131, 3.0 },
                    { 45, "1", "Évaluation pour la borne 45 par utilisateur 1", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7015), new DateTime(2025, 8, 14, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7013), false, 135, 1.0 },
                    { 45, "4", "Évaluation pour la borne 45 par utilisateur 4", null, new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6960), true, 133, 2.0 },
                    { 45, "5", "Évaluation pour la borne 45 par utilisateur 5", new DateTime(2025, 9, 5, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6974), new DateTime(2025, 8, 23, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(6972), false, 134, 2.0 },
                    { 46, "2", "Évaluation pour la borne 46 par utilisateur 2", new DateTime(2025, 8, 26, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7056), new DateTime(2025, 8, 15, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7054), true, 137, 5.0 },
                    { 46, "4", "Évaluation pour la borne 46 par utilisateur 4", new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7043), new DateTime(2025, 8, 18, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7041), true, 136, 4.0 },
                    { 46, "5", "Évaluation pour la borne 46 par utilisateur 5", null, new DateTime(2025, 8, 22, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7066), true, 138, 5.0 },
                    { 47, "2", "Évaluation pour la borne 47 par utilisateur 2", null, new DateTime(2025, 8, 12, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7105), false, 140, 2.0 },
                    { 47, "3", "Évaluation pour la borne 47 par utilisateur 3", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7094), new DateTime(2025, 8, 9, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7092), true, 139, 3.0 },
                    { 47, "4", "Évaluation pour la borne 47 par utilisateur 4", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7118), new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7116), true, 141, 5.0 },
                    { 48, "2", "Évaluation pour la borne 48 par utilisateur 2", null, new DateTime(2025, 8, 18, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7165), true, 144, 2.0 },
                    { 48, "3", "Évaluation pour la borne 48 par utilisateur 3", new DateTime(2025, 8, 27, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7141), new DateTime(2025, 9, 1, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7139), false, 142, 1.0 },
                    { 48, "4", "Évaluation pour la borne 48 par utilisateur 4", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7154), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7152), false, 143, 4.0 },
                    { 49, "1", "Évaluation pour la borne 49 par utilisateur 1", new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7205), new DateTime(2025, 8, 16, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7203), false, 146, 3.0 },
                    { 49, "3", "Évaluation pour la borne 49 par utilisateur 3", new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7217), new DateTime(2025, 8, 28, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7215), false, 147, 5.0 },
                    { 49, "4", "Évaluation pour la borne 49 par utilisateur 4", new DateTime(2025, 8, 30, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7192), new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7190), true, 145, 5.0 },
                    { 50, "3", "Évaluation pour la borne 50 par utilisateur 3", null, new DateTime(2025, 9, 4, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7280), true, 149, 2.0 },
                    { 50, "4", "Évaluation pour la borne 50 par utilisateur 4", new DateTime(2025, 8, 24, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7267), new DateTime(2025, 8, 19, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7265), false, 148, 5.0 },
                    { 50, "5", "Évaluation pour la borne 50 par utilisateur 5", null, new DateTime(2025, 8, 20, 23, 39, 8, 950, DateTimeKind.Local).AddTicks(7291), false, 150, 1.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_NoCivique_Rue_Ville_CodePostal_Province",
                table: "Adresses",
                columns: new[] { "NoCivique", "Rue", "Ville", "CodePostal", "Province" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Borne_AdresseId",
                table: "Borne",
                column: "AdresseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorneUtilisateurs_UtilisateurId",
                table: "BorneUtilisateurs",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilites_BorneId",
                table: "Disponibilites",
                column: "BorneId");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilites_UtilisateurId",
                table: "Disponibilites",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BorneUtilisateurs");

            migrationBuilder.DropTable(
                name: "Disponibilites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Borne");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
