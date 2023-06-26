using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedBioDirectorWriter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "DirectorName",
                table: "Shows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoryWriterName",
                table: "Shows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Auditions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("392699b9-b418-4575-a420-366e84e6181e"), "Beograd", new DateTime(2024, 4, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9930), "Festival 5", null, new DateTime(2024, 3, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9930), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("8aff5893-c7f3-4d41-ad19-4738f4d43e29"), "Beograd", new DateTime(2023, 8, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9902), "Festival 1", null, new DateTime(2023, 7, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9897), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("ae836ac2-e8e3-46d5-8e16-50ee8c306b6b"), "Beograd", new DateTime(2023, 12, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9918), "Festival 3", null, new DateTime(2023, 11, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9917), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d119b7c7-1d5c-4eef-9211-a86c5d6dc209"), "Beograd", new DateTime(2024, 2, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9924), "Festival 4", null, new DateTime(2024, 1, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9923), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("efc42c21-dc77-45d2-ac98-07b8edda427e"), "Beograd", new DateTime(2023, 10, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9911), "Festival 2", null, new DateTime(2023, 9, 26, 18, 30, 1, 503, DateTimeKind.Utc).AddTicks(9910), 36300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("392699b9-b418-4575-a420-366e84e6181e"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("8aff5893-c7f3-4d41-ad19-4738f4d43e29"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("ae836ac2-e8e3-46d5-8e16-50ee8c306b6b"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d119b7c7-1d5c-4eef-9211-a86c5d6dc209"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("efc42c21-dc77-45d2-ac98-07b8edda427e"));

            migrationBuilder.DropColumn(
                name: "DirectorName",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "StoryWriterName",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Auditions");

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
        }
    }
}
