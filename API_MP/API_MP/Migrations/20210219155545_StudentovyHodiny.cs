using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MP.Migrations
{
    public partial class StudentovyHodiny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "5b1c2b5e-08bf-4a98-ba54-b884e1fbbfbf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "fac9bb7e-6026-4f4b-ba37-0727c4642f27" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1c2b5e-08bf-4a98-ba54-b884e1fbbfbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac9bb7e-6026-4f4b-ba37-0727c4642f27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36390f24-8fb2-4e36-b053-b133b05bdc59", "ec126408-8f59-4c52-8632-1e310de11b3b", "Trener", "TRENER" },
                    { "9b22a93a-9faf-45c6-885c-147fe81cf8c8", "1e37ef44-0ebe-4f2e-880f-fac0bfa5bc78", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d079c26-051e-43b4-a266-b36e04403040", "AQAAAAEAACcQAAAAEDn6ujWuqK1T97cMJoKLcWk5qbLd6chkMEaI+vv9diKEEvuC8S5fSWzmZhu5sTWDOA==", "d3861b4c-b162-4d86-a530-62a425b48ae6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ab93be1-37d6-4a8c-9509-869800e9b5c9", "AQAAAAEAACcQAAAAEAqz/b+AxwR1S4pr14JsV+obbQQnbviyPaGVRd468VhIskCcG6PV72sDszevTbar3A==", "08e9900d-0cd3-45ca-88d8-d7ee5a5d8ebb" });

            migrationBuilder.InsertData(
                table: "Hours",
                columns: new[] { "Id", "End", "Person", "Requester", "Start", "isOnetime" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 2, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "2", "1", new DateTime(2021, 2, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, new DateTime(2021, 2, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "2", "1", new DateTime(2021, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, new DateTime(2021, 2, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "2", "1", new DateTime(2021, 2, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 5, new DateTime(2021, 2, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), "2", "1", new DateTime(2021, 2, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "36390f24-8fb2-4e36-b053-b133b05bdc59" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "9b22a93a-9faf-45c6-885c-147fe81cf8c8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "36390f24-8fb2-4e36-b053-b133b05bdc59" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "9b22a93a-9faf-45c6-885c-147fe81cf8c8" });

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36390f24-8fb2-4e36-b053-b133b05bdc59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b22a93a-9faf-45c6-885c-147fe81cf8c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b1c2b5e-08bf-4a98-ba54-b884e1fbbfbf", "3f26f181-d65d-415f-8502-01d565fc7e8d", "Trener", "TRENER" },
                    { "fac9bb7e-6026-4f4b-ba37-0727c4642f27", "be5cbb2f-4b52-494c-96cf-52d4ad228c52", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1acd6c6-824f-40ef-96b3-307e5d0b949e", "AQAAAAEAACcQAAAAEJHF2oTBjfvBTdlGCu6X1a61nbWU7MuKbZB9Fr0PdIrikTSq4j4M2e4s1onDLmVFOQ==", "5bf5e299-046f-4fab-8719-6b9e233274d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "add1aefe-e2a4-4c89-a7ec-c9028c1bfcb1", "AQAAAAEAACcQAAAAEJ5URZsOhFK3crg6cTuHrazm4N852Vdq5d4ScBccw2MHHxAcDyZFSzlvmEEgrzNZxw==", "76f24ad3-3785-4520-84f0-be98321fb75d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "5b1c2b5e-08bf-4a98-ba54-b884e1fbbfbf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "fac9bb7e-6026-4f4b-ba37-0727c4642f27" });
        }
    }
}
