using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class Picturechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("07632a48-e741-47c0-9eb2-b3ca940e0b35"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("a51281ce-eb70-4498-bf36-00fb9a4af952"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("ade3948e-96e3-4414-a45e-d59dcf00f5b8"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("b9807413-7477-4d52-b06f-2f45c2ca9e18"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("eccd26b4-8f11-4b28-93a4-fd7bbd0bcf92"));

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Photos",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                newName: "IX_Photos_UserId");

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("0fde8614-ed28-4158-98ec-d1d9996724be"), "Beograd", new DateTime(2023, 9, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8053), "Festival 1", null, new DateTime(2023, 8, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8045), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("244cb6ef-3b77-4c75-afb1-16509fe8a28b"), "Beograd", new DateTime(2024, 3, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8081), "Festival 4", null, new DateTime(2024, 2, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8080), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("35805774-dc48-42ba-983f-a476d3e3a6a3"), "Beograd", new DateTime(2023, 11, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8075), "Festival 2", null, new DateTime(2023, 10, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8074), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("5d53db62-a7c5-4360-a3c1-8778f86bdc19"), "Beograd", new DateTime(2024, 1, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8078), "Festival 3", null, new DateTime(2023, 12, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8077), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("72c80805-9ab3-4621-9303-fd9ecd41adcc"), "Beograd", new DateTime(2024, 5, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8083), "Festival 5", null, new DateTime(2024, 4, 5, 16, 30, 44, 383, DateTimeKind.Utc).AddTicks(8082), 36300 });

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("0fde8614-ed28-4158-98ec-d1d9996724be"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("244cb6ef-3b77-4c75-afb1-16509fe8a28b"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("35805774-dc48-42ba-983f-a476d3e3a6a3"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("5d53db62-a7c5-4360-a3c1-8778f86bdc19"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("72c80805-9ab3-4621-9303-fd9ecd41adcc"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Photos",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                newName: "IX_Photos_AppUserId");

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("07632a48-e741-47c0-9eb2-b3ca940e0b35"), "Beograd", new DateTime(2024, 5, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3674), "Festival 5", null, new DateTime(2024, 4, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3673), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("a51281ce-eb70-4498-bf36-00fb9a4af952"), "Beograd", new DateTime(2023, 11, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3661), "Festival 2", null, new DateTime(2023, 10, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3660), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("ade3948e-96e3-4414-a45e-d59dcf00f5b8"), "Beograd", new DateTime(2024, 1, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3665), "Festival 3", null, new DateTime(2023, 12, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3664), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("b9807413-7477-4d52-b06f-2f45c2ca9e18"), "Beograd", new DateTime(2024, 3, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3670), "Festival 4", null, new DateTime(2024, 2, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3669), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("eccd26b4-8f11-4b28-93a4-fd7bbd0bcf92"), "Beograd", new DateTime(2023, 9, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3653), "Festival 1", null, new DateTime(2023, 8, 5, 15, 19, 47, 354, DateTimeKind.Utc).AddTicks(3645), 36300 });

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
