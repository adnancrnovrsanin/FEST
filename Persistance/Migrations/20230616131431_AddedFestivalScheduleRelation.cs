using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedFestivalScheduleRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FestivalId",
                table: "Schedules",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FestivalId",
                table: "Schedules",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Festivals_FestivalId",
                table: "Schedules",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Festivals_FestivalId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_FestivalId",
                table: "Schedules");

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

            migrationBuilder.DropColumn(
                name: "FestivalId",
                table: "Schedules");
        }
    }
}
