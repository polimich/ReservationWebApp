using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MP.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    WhatITeach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Person = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Requester = table.Column<string>(nullable: false),
                    isOnetime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c48cbdad-2ed6-47b5-a949-e83f10e484e1", "ff7acd48-c20a-4e61-abfd-88b4a65eeb10", "Trener", "TRENER" },
                    { "8b76af91-6aec-45b0-a930-fa95c80532ac", "c6537cc0-aa77-4670-ad0c-41bc812a90a9", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WhatITeach" },
                values: new object[,]
                {
                    { "1", 0, "7a94b31e-6ac5-4165-91d6-d98d193f0d26", "trener@gmail.com", true, "Pavel", "Markovič", false, null, "TRENER@GMAIL.COM", "TRENER@GMAIL.COM", "AQAAAAEAACcQAAAAEHf+p5jH2e6bp4cQfeOhlXRYatTVuKSFJHDWvlAXBvb/8jbgalZ2ZyawZvhpbunPdg==", null, false, "695f7a4a-d7e6-40ca-9690-bff26c84a59c", false, "trener@gmail.com", "Tenis" },
                    { "2", 0, "04199b78-53fb-44ad-a69b-5ce25337c489", "student@gmail.com", true, "Michael", "Polívka", false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEBmN2bjWpd/3Ho5/XmooCiRQ2OIi0YXn/ak8KoWu2blXgVZ2/pXQMhGHOyrcVIf98g==", null, false, "2ca9d3e2-e563-4c6e-a195-a91baad101c5", false, "student@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "Hours",
                columns: new[] { "Id", "End", "Name", "Person", "Requester", "Start", "isOnetime" },
                values: new object[,]
                {
                    { 16, new DateTime(2021, 3, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 15, new DateTime(2021, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 14, new DateTime(2021, 3, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 13, new DateTime(2021, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 12, new DateTime(2021, 3, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 11, new DateTime(2021, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 20, new DateTime(2021, 3, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 19, new DateTime(2021, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 10, new DateTime(2021, 2, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 8, new DateTime(2021, 2, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 17, new DateTime(2021, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 7, new DateTime(2021, 2, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 6, new DateTime(2021, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 5, new DateTime(2021, 2, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 4, new DateTime(2021, 2, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, new DateTime(2021, 2, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, new DateTime(2021, 2, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 1, new DateTime(2021, 2, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 9, new DateTime(2021, 2, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 2, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 18, new DateTime(2021, 3, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "c48cbdad-2ed6-47b5-a949-e83f10e484e1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "8b76af91-6aec-45b0-a930-fa95c80532ac" });

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
                name: "Changes");

            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
