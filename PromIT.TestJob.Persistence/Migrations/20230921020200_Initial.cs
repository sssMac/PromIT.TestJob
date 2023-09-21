using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromIT.TestJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    OrgName = table.Column<string>(type: "text", nullable: false),
                    OrgAddress = table.Column<string>(type: "text", nullable: true),
                    WhatLike = table.Column<string>(type: "text", nullable: false),
                    WhatDislike = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedAt", "OrgAddress", "OrgName", "Rating", "UserName", "WhatDislike", "WhatLike" },
                values: new object[,]
                {
                    { new Guid("256907b4-e958-4683-bcab-3069e97c7823"), new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "ABC Inc.", 4, "JohnDoe", "Long commute", "Friendly colleagues" },
                    { new Guid("282ebf54-7973-421b-901c-e0e8c5ce49c7"), new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), "456 Elm St", "XYZ Corp.", 5, "JaneSmith", null, "Flexible hours" },
                    { new Guid("2b371052-2e01-430a-869d-d97a516f84a5"), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "789 Oak St", "LMN Ltd.", 3, "BobJohnson", "No remote work", "Great benefits" },
                    { new Guid("2fa14d15-338a-4e24-8b44-933e2e0c36e7"), new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, "HIJ Corporation", 5, "GraceWang", "Micromanagement", "Innovative projects" },
                    { new Guid("387f2d1b-0e13-43a4-a2f6-b6e287796358"), new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), "303 Cedar St", "UVW Inc.", 4, "DavidLee", "Lack of training", "Diverse team" },
                    { new Guid("4fbfeee1-a6c0-46b2-be35-a9387076a609"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), "404 Birch St", "HIJ Corporation", 5, "GraceWang", "Micromanagement", "Innovative projects" },
                    { new Guid("5179f33d-ff84-40ac-9d85-6dc41794f2d8"), new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), null, "ABC Inc.", 4, "JohnDoe", "Long commute", "Friendly colleagues" },
                    { new Guid("5377ae6d-24b3-440f-9791-e3f517821199"), new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), "456 Elm St", "XYZ Corp.", 5, "JaneSmith", null, "Flexible hours" },
                    { new Guid("63483ea2-3340-4870-a677-2d4f3c305845"), new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), "202 Pine St", "RST Group", 3, "EveAdams", "High workload", "Opportunities for growth" },
                    { new Guid("d6fa53c4-485a-4cff-99eb-eb99a352386d"), new DateTime(2020, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), "789 Oak St", "LMN Ltd.", 3, "BobJohnson", "No remote work", "Great benefits" },
                    { new Guid("d7895ad6-2288-423d-9935-ae42b9517a14"), new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), null, "PQR Co.", 4, "AliceJohnson", null, "Work-life balance" },
                    { new Guid("e0da5076-7070-4aef-a578-390594e3cf0e"), new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), "303 Cedar St", "UVW Inc.", 4, "DavidLee", "Lack of training", "Diverse team" },
                    { new Guid("ee0d75b2-0904-463c-9671-11315b10fec6"), new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Utc), null, "PQR Co.", 4, "AliceJohnson", null, "Work-life balance" },
                    { new Guid("eeddf878-bdd5-47c6-a90d-18a08f7b8c1e"), new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), "202 Pine St", "RST Group", 3, "EveAdams", "High workload", "Opportunities for growth" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c9b9b73-517e-4749-b183-b80583da38c1", "b1be3726-851c-4e22-a626-cbb21348fcc7", "Basic", "BASIC" },
                    { "a5f00ba5-73c9-40cf-a8dc-4da34b2ec086", "922dc172-15f5-431e-93b7-1788f3f3ba03", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
