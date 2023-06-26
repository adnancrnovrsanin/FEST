using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedManagerToTheatre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Theatres",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("1b98ad48-89db-4cf4-98ca-d945a79e89f8"), "Beograd", new DateTime(2024, 4, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5316), "Festival 5", null, new DateTime(2024, 3, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5316), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("60dc464e-391c-4da9-aeac-c508346817fa"), "Beograd", new DateTime(2023, 10, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5296), "Festival 2", null, new DateTime(2023, 9, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5296), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("9441b443-6761-4ec1-b189-8083cb480b7b"), "Beograd", new DateTime(2023, 12, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5303), "Festival 3", null, new DateTime(2023, 11, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5303), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("fb3b914d-dca6-45a4-bec2-44ae22564564"), "Beograd", new DateTime(2024, 2, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5310), "Festival 4", null, new DateTime(2024, 1, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5309), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("fbb375a6-fe93-4a29-87f6-35b7835bf87b"), "Beograd", new DateTime(2023, 8, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5287), "Festival 1", null, new DateTime(2023, 7, 26, 15, 24, 59, 277, DateTimeKind.Utc).AddTicks(5282), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_Theatres_ManagerId",
                table: "Theatres",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Theatres_AspNetUsers_ManagerId",
                table: "Theatres",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theatres_AspNetUsers_ManagerId",
                table: "Theatres");

            migrationBuilder.DropIndex(
                name: "IX_Theatres_ManagerId",
                table: "Theatres");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("1b98ad48-89db-4cf4-98ca-d945a79e89f8"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("60dc464e-391c-4da9-aeac-c508346817fa"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("9441b443-6761-4ec1-b189-8083cb480b7b"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("fb3b914d-dca6-45a4-bec2-44ae22564564"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("fbb375a6-fe93-4a29-87f6-35b7835bf87b"));

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Theatres");

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
        }
    }
}
