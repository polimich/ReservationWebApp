using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MP.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "361a371f-f61a-416b-bc1c-321a5c909cc6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "bbd7118c-e8b4-472d-a277-913798b24667" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361a371f-f61a-416b-bc1c-321a5c909cc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbd7118c-e8b4-472d-a277-913798b24667");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "578fa5d8-b74b-4675-bc52-9cf1bca8a96d", "8f7bb45a-cc09-4c04-9391-18d75cbe4718", "Trener", "TRENER" },
                    { "395a0a42-56ec-494d-bc20-9de745b26465", "64be2bce-0cd2-4a48-b1bd-4d781e97c91d", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48a417aa-cedd-4f54-9ca1-830ce8cee9a7", "Pavel", "Markovič", "AQAAAAEAACcQAAAAENGYE+SAyV78N/SoIjm9hAVS2beOjYXbX1aZBam8wDuwgHrgzX7Uwds82LvPFK3zdA==", "404cc27c-36be-47de-9b9a-e4f762be9a08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9faf79f0-cb40-410c-be8e-b6bbac240cce", "Michael", "Polívka", "AQAAAAEAACcQAAAAEEA/Z1Jy5iYd3lqE+fXcwtJFVwiNxHXlVp62bY2XQL6P3oN/aFuWcX58jG6vIsF3Lg==", "16563d54-8034-44a2-bbce-9890029f1896" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "578fa5d8-b74b-4675-bc52-9cf1bca8a96d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "395a0a42-56ec-494d-bc20-9de745b26465" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1", "578fa5d8-b74b-4675-bc52-9cf1bca8a96d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2", "395a0a42-56ec-494d-bc20-9de745b26465" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "395a0a42-56ec-494d-bc20-9de745b26465");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "578fa5d8-b74b-4675-bc52-9cf1bca8a96d");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "361a371f-f61a-416b-bc1c-321a5c909cc6", "f56cbf17-2418-461f-ba8e-abd302e95427", "Trener", "TRENER" },
                    { "bbd7118c-e8b4-472d-a277-913798b24667", "b5e838a4-ec6a-4fbb-bebf-5e4a5b910baa", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5ee0b27-d79a-4a3c-846f-6f143671baff", "AQAAAAEAACcQAAAAECUoym4H86k4cIqYdj3kzsHTsrbrbac+FrK3fzgL4DpMUucv893ga76m9MjhwVQ8yQ==", "13b5c3fa-8227-483c-8561-bcf2225f44d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fffed4f-33e7-4260-ad24-b04a152d170d", "AQAAAAEAACcQAAAAED2CDvrp0mJUY8n/YtXy28oSh333k78W3ev7/qHwDg8Z7a9lScXqNzEspQGFU2x3Mg==", "21b2f621-ed85-4ba6-81b8-8a8fd021fa70" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1", "361a371f-f61a-416b-bc1c-321a5c909cc6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2", "bbd7118c-e8b4-472d-a277-913798b24667" });
        }
    }
}
