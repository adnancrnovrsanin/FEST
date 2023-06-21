using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("11adb3d4-18d8-42a1-8b18-1b835f559c2d"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("4043b607-2cba-4f22-971d-e1a314bac332"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("469b5fe7-ed22-45b9-b624-5b82fa235da4"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("7b4d7315-c513-425f-8232-58f77c1bbce2"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("cdb7e9cc-d024-47c5-b85f-66d3c11659d4"));

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("4a783d95-6c95-484e-93f7-d516d4fade1a"), "Beograd", new DateTime(2023, 8, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7593), "Festival 1", null, new DateTime(2023, 7, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7588), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("5cf693bc-6987-4650-b748-be5039fd6ce6"), "Beograd", new DateTime(2024, 4, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7621), "Festival 5", null, new DateTime(2024, 3, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7621), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("694199d3-d8e4-4409-88b8-30fe99d35e0c"), "Beograd", new DateTime(2024, 2, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7615), "Festival 4", null, new DateTime(2024, 1, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7615), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("6d5755ad-d4b5-4529-b624-ade377a50589"), "Beograd", new DateTime(2023, 10, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7602), "Festival 2", null, new DateTime(2023, 9, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7602), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("e037b798-9c44-4c74-abcd-14275ae56210"), "Beograd", new DateTime(2023, 12, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7609), "Festival 3", null, new DateTime(2023, 11, 21, 12, 58, 59, 167, DateTimeKind.Utc).AddTicks(7608), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("4a783d95-6c95-484e-93f7-d516d4fade1a"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("5cf693bc-6987-4650-b748-be5039fd6ce6"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("694199d3-d8e4-4409-88b8-30fe99d35e0c"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("6d5755ad-d4b5-4529-b624-ade377a50589"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("e037b798-9c44-4c74-abcd-14275ae56210"));

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("11adb3d4-18d8-42a1-8b18-1b835f559c2d"), "Beograd", new DateTime(2024, 4, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6753), "Festival 5", null, new DateTime(2024, 3, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6753), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("4043b607-2cba-4f22-971d-e1a314bac332"), "Beograd", new DateTime(2024, 2, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6747), "Festival 4", null, new DateTime(2024, 1, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6746), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("469b5fe7-ed22-45b9-b624-5b82fa235da4"), "Beograd", new DateTime(2023, 10, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6734), "Festival 2", null, new DateTime(2023, 9, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6733), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("7b4d7315-c513-425f-8232-58f77c1bbce2"), "Beograd", new DateTime(2023, 12, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6740), "Festival 3", null, new DateTime(2023, 11, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6740), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("cdb7e9cc-d024-47c5-b85f-66d3c11659d4"), "Beograd", new DateTime(2023, 8, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6724), "Festival 1", null, new DateTime(2023, 7, 16, 13, 14, 30, 850, DateTimeKind.Utc).AddTicks(6716), 36300 });
        }
    }
}
