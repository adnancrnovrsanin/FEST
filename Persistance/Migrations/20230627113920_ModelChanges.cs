using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("2cbf70ff-f822-4d06-a716-7986a5e40f51"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("4dde64ba-5a06-4879-80f6-21ddf31f13b9"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d17df312-8412-4aa0-a014-b7488a3a2ffc"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d3bfe2a9-95d8-4525-8bda-562549c45c20"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("e16ba146-d58c-499f-a433-14fdf975e904"));

            migrationBuilder.AddColumn<bool>(
                name: "Reviewed",
                table: "ShowFestivalApplicationReviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("0e36255c-2759-40d6-85ce-e8932519da45"), "Beograd", new DateTime(2024, 2, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3302), "Festival 4", null, new DateTime(2024, 1, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3301), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("29c507c7-a1a1-485e-96b9-d70b060be2f7"), "Beograd", new DateTime(2023, 12, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3296), "Festival 3", null, new DateTime(2023, 11, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3295), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("86b0ddde-8dc1-41c1-b221-8400bdbc7996"), "Beograd", new DateTime(2024, 4, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3308), "Festival 5", null, new DateTime(2024, 3, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3308), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("ace1bb00-bc92-4ea3-9a39-3e26afba34d1"), "Beograd", new DateTime(2023, 8, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3279), "Festival 1", null, new DateTime(2023, 7, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3274), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d515be1c-5245-4462-8d3e-16eb47ba3c78"), "Beograd", new DateTime(2023, 10, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3289), "Festival 2", null, new DateTime(2023, 9, 27, 11, 39, 20, 320, DateTimeKind.Utc).AddTicks(3288), 36300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("0e36255c-2759-40d6-85ce-e8932519da45"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("29c507c7-a1a1-485e-96b9-d70b060be2f7"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("86b0ddde-8dc1-41c1-b221-8400bdbc7996"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("ace1bb00-bc92-4ea3-9a39-3e26afba34d1"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("d515be1c-5245-4462-8d3e-16eb47ba3c78"));

            migrationBuilder.DropColumn(
                name: "Reviewed",
                table: "ShowFestivalApplicationReviews");

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("2cbf70ff-f822-4d06-a716-7986a5e40f51"), "Beograd", new DateTime(2023, 10, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(683), "Festival 2", null, new DateTime(2023, 9, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(682), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("4dde64ba-5a06-4879-80f6-21ddf31f13b9"), "Beograd", new DateTime(2024, 2, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(696), "Festival 4", null, new DateTime(2024, 1, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(695), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d17df312-8412-4aa0-a014-b7488a3a2ffc"), "Beograd", new DateTime(2023, 8, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(674), "Festival 1", null, new DateTime(2023, 7, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(669), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("d3bfe2a9-95d8-4525-8bda-562549c45c20"), "Beograd", new DateTime(2024, 4, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(702), "Festival 5", null, new DateTime(2024, 3, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(701), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("e16ba146-d58c-499f-a433-14fdf975e904"), "Beograd", new DateTime(2023, 12, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(689), "Festival 3", null, new DateTime(2023, 11, 27, 11, 14, 21, 684, DateTimeKind.Utc).AddTicks(689), 36300 });
        }
    }
}
