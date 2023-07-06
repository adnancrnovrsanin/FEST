using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class RefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: true),
                    Token = table.Column<string>(type: "TEXT", nullable: true),
                    Expires = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Revoked = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("12959bf2-f6e3-42c8-9588-4c9d03ff784e"), "Beograd", new DateTime(2023, 11, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(4), "Festival 2", null, new DateTime(2023, 10, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(3), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("320a76d7-4985-40ca-ad58-c2df0cbb3b68"), "Beograd", new DateTime(2023, 9, 6, 12, 4, 48, 659, DateTimeKind.Utc).AddTicks(9994), "Festival 1", null, new DateTime(2023, 8, 6, 12, 4, 48, 659, DateTimeKind.Utc).AddTicks(9989), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("73d77cf6-d6bb-425a-8a31-ef5312f85f2f"), "Beograd", new DateTime(2024, 3, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(17), "Festival 4", null, new DateTime(2024, 2, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(16), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("9626cbe3-022e-436f-b1c1-f665a041ac59"), "Beograd", new DateTime(2024, 1, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(10), "Festival 3", null, new DateTime(2023, 12, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(9), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d68c0ee3-1bbc-4abc-a4af-204cda01f7f0"), "Beograd", new DateTime(2024, 5, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(23), "Festival 5", null, new DateTime(2024, 4, 6, 12, 4, 48, 660, DateTimeKind.Utc).AddTicks(23), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserId",
                table: "RefreshToken",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("12959bf2-f6e3-42c8-9588-4c9d03ff784e"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("320a76d7-4985-40ca-ad58-c2df0cbb3b68"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("73d77cf6-d6bb-425a-8a31-ef5312f85f2f"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("9626cbe3-022e-436f-b1c1-f665a041ac59"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d68c0ee3-1bbc-4abc-a4af-204cda01f7f0"));

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
        }
    }
}
