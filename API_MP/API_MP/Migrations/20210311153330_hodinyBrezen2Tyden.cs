using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MP.Migrations
{
    public partial class hodinyBrezen2Tyden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "c48cbdad-2ed6-47b5-a949-e83f10e484e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "8b76af91-6aec-45b0-a930-fa95c80532ac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b76af91-6aec-45b0-a930-fa95c80532ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c48cbdad-2ed6-47b5-a949-e83f10e484e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96543567-02a1-4cb0-8dcc-a5df3d150ff4", "61c16263-f8f9-4c75-8519-caf043e634c1", "Trener", "TRENER" },
                    { "2c139fec-776a-453e-adde-62e1d41ab045", "44f88cf2-584c-4ef1-bdb4-f03efcc0d85c", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b7d1a7c-7abf-46af-a708-c0a188672965", "AQAAAAEAACcQAAAAEDivsU7wpgXV33DF7ngjoNR41eL2jYZ+fKv3qkz+9tuwkZip+r5uVbxDm5RSiKG3AQ==", "5d563be7-2e65-421d-93ba-2008ae2b04b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62613bea-d27a-4271-970b-68169f7de914", "AQAAAAEAACcQAAAAEDSgdgPmZMfLeuRySz1o5CZdZkx0h81Hmq8Ra5bM8Hx6fqV4CiELC/pyllay+295vw==", "1cbedfeb-c06d-4087-9b61-e4cc1aaa99b5" });

            migrationBuilder.InsertData(
                table: "Hours",
                columns: new[] { "Id", "End", "Name", "Person", "Requester", "Start", "isOnetime" },
                values: new object[,]
                {
                    { 29, new DateTime(2021, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 30, new DateTime(2021, 3, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 21, new DateTime(2021, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 22, new DateTime(2021, 3, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 23, new DateTime(2021, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 24, new DateTime(2021, 3, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 25, new DateTime(2021, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 26, new DateTime(2021, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 27, new DateTime(2021, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 28, new DateTime(2021, 3, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), "Tenis", "2", "1", new DateTime(2021, 3, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "96543567-02a1-4cb0-8dcc-a5df3d150ff4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "2c139fec-776a-453e-adde-62e1d41ab045" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "96543567-02a1-4cb0-8dcc-a5df3d150ff4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "2c139fec-776a-453e-adde-62e1d41ab045" });

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c139fec-776a-453e-adde-62e1d41ab045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96543567-02a1-4cb0-8dcc-a5df3d150ff4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c48cbdad-2ed6-47b5-a949-e83f10e484e1", "ff7acd48-c20a-4e61-abfd-88b4a65eeb10", "Trener", "TRENER" },
                    { "8b76af91-6aec-45b0-a930-fa95c80532ac", "c6537cc0-aa77-4670-ad0c-41bc812a90a9", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a94b31e-6ac5-4165-91d6-d98d193f0d26", "AQAAAAEAACcQAAAAEHf+p5jH2e6bp4cQfeOhlXRYatTVuKSFJHDWvlAXBvb/8jbgalZ2ZyawZvhpbunPdg==", "695f7a4a-d7e6-40ca-9690-bff26c84a59c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04199b78-53fb-44ad-a69b-5ce25337c489", "AQAAAAEAACcQAAAAEBmN2bjWpd/3Ho5/XmooCiRQ2OIi0YXn/ak8KoWu2blXgVZ2/pXQMhGHOyrcVIf98g==", "2ca9d3e2-e563-4c6e-a195-a91baad101c5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "c48cbdad-2ed6-47b5-a949-e83f10e484e1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "8b76af91-6aec-45b0-a930-fa95c80532ac" });
        }
    }
}
