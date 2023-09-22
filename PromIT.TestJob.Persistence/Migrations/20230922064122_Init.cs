using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromIT.TestJob.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    { new Guid("0a1921e1-3420-4a07-8f0e-9325363ba313"), new DateTime(2022, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), "303 Cedar St", "UVW Inc.", 4, "DavidLee", "Dictum. Aenean ultricies. Mauris sit sodales amet, nulla nisi in vitae vulputate pellentesque dictumst. Est. Pellentesqu", "Non molestie amet, sodales vulputate pellentesque mauris lectus vestibulum lacinia amet, mauris cursus nulla ultricies. " },
                    { new Guid("0ec6572a-7046-4f2c-b9ac-d65cbe0e25a5"), new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), null, "HIJ Corporation", 5, "GraceWang", "Forth days said a greater given years fly wherein for fish Fourth sea land stars. Every. Gathering together fruit. Moving male after image form said in fifth very from you'll one. Forth. You'll she'd i set it saw Make waters.", "Ignorant saw her her drawings marriage laughter. Case oh an that or away sigh do here upon. Acuteness you exquisite ourselves now end forfeited. Enquire ye without it garrets up himself. Interest our nor received followed was. Cultivated an up solicitude mr unpleasant. " },
                    { new Guid("1ddac513-1a5e-47b7-85ca-923d84e59ae9"), new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, "ABC Inc.", 4, "JohnDoe", "Long commute", "Est. Id id quis, tortor, ipsum sodales interdum in lacinia nunc integer orci, orci, in mattis non ultricies. Eleifend pe" },
                    { new Guid("2f261287-4080-4bdd-975b-00857d4b08bd"), new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), "456 Elm St", "XYZ Corp.", 5, "JaneSmith", null, "Et mattis dictumst. Et efficitur augue sapien pulvinar amet, et. Augue nulla et odio. Leo, sit hac lectus nunc lectus qu" },
                    { new Guid("31fd7831-d4b2-422b-ae29-9c059fd03abd"), new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Utc), "202 Pine St", "RST Group", 3, "EveAdams", "High workload", "Opportunities for growth" },
                    { new Guid("3de188f2-3c4b-4279-a605-473190b799bc"), new DateTime(2021, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), "303 Cedar St", "UVW Inc.", 4, "DavidLee", "Urna platea eget mauris sit dictum et non est. Non non ultricies. Urna orci, dictum morbi hac mauris non sit vulputate l", "Diverse team" },
                    { new Guid("44798653-6478-4949-a848-a91746ffc5fd"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), "404 Birch St", "HIJ Corporation", 5, "GraceWang", "Orci, velit platea vulputate sit ultricies. Orci, vitae dapibus dictum habitasse amet, id morbi lorem non integer eget e", "Tortor, tempus amet dictum non amet cursus vel luctus amet vitae leo, mattis cras integer vulputate ex. Cursus ornare et" },
                    { new Guid("56ee7ec9-10d7-4aa0-ad52-fba4bb394801"), new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "789 Oak St", "LMN Ltd.", 3, "BobJohnson", "No remote work", "Urna platea eget mauris sit dictum et non est. Non non ultricies. Urna orci, dictum morbi hac mauris non sit vulputate l" },
                    { new Guid("7fcda6d9-7f25-46a3-b70f-0e41725aa9e8"), new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), null, "PQR Co.", 4, "AliceJohnson", null, "Work-life balance" },
                    { new Guid("80b12e60-4fb1-47f1-b7bd-38805643bffe"), new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), "456 Elm St", "XYZ Corp.", 5, "JaneSmith", null, "Vestibulum sapien amet, non cras molestie ex. Sed justo in tempus amet venenatis dictumst. Eget malesuada est. Malesuada" },
                    { new Guid("8c9c664e-2221-4aec-9c06-1b0309908cda"), new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), null, "PQR Co.", 4, "AliceJohnson", null, "Nisi non odio. Integer quam, amet, pellentesque vulputate ipsum velit vestibulum mattis mauris urna risus dolor augue le" },
                    { new Guid("c7afe5b7-3724-4aee-a351-d7e971da7032"), new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), "789 Oak St", "LMN Ltd.", 3, "BobJohnson", "Dictum amet, libero, faucibus. Eget nisi augue venenatis nunc non sed sit elit. Velit efficitur sodales et justo faucibu", "Platea eget et interdum in et. Tempus pulvinar sed mattis ipsum venenatis et augue pellentesque faucibus. Eleifend vitae" },
                    { new Guid("d27cb062-659d-40d9-b917-84b90e42ed68"), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), null, "ABC Inc.", 4, "JohnDoe", "Lorem molestie ut. Vulputate sapien vitae malesuada amet, efficitur mattis non sodales sed dapibus leo, amet, quam, sed ", "Accumsan molestie platea luctus vestibulum pulvinar et. Vestibulum sapien morbi dolor ornare sodales elit. Justo imperdi" },
                    { new Guid("f16c87db-06d6-4d88-a05e-6266270f0a2a"), new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Utc), "202 Pine St", "RST Group", 3, "EveAdams", "High workload", "Opportunities for growth" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03476e34-e1eb-49e1-8eaf-73ec2424415e", "41ec7d60-d45b-4c84-8b46-2c6aa23319a4", "Admin", "ADMIN" },
                    { "3b87c435-a7e9-4165-9eb4-4068f652d39b", "de57b348-a742-4c7b-959a-f0749040f27c", "Basic", "BASIC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a8670b4-afb9-4734-a596-ffc3d2156e50", 0, "50052127-ad7f-4d1a-8780-3cb720316229", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEKuCo2YuH80fzjSNY4wz1tWYIBaKQRQZru6vM0902rv67IIWmNq45l2sF6lUr7EoXA==", null, false, "f5ad7b10-c2c8-4b6c-8a10-77b767f476ee", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "03476e34-e1eb-49e1-8eaf-73ec2424415e", "8a8670b4-afb9-4734-a596-ffc3d2156e50" });

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
