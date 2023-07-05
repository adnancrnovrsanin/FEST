using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class adnaneumri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowFestivalApplicationReviews_Festivals_FestivalId",
                table: "ShowFestivalApplicationReviews");

            migrationBuilder.DropIndex(
                name: "IX_ShowFestivalApplicationReviews_FestivalId",
                table: "ShowFestivalApplicationReviews");

            migrationBuilder.DropIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("0420255b-52a9-442c-81ed-b2626685b561"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("1cfa698f-516f-451b-80d7-c4a70e7b05ad"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("52ea9009-7d82-4f17-98f4-98d6e505a4c3"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("88cd79ac-60e9-4c11-ac24-318b75c19748"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("a3d23763-d578-4d41-addd-b5dd984ec5e6"));

            migrationBuilder.DropColumn(
                name: "FestivalId",
                table: "ShowFestivalApplicationReviews");

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

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions",
                column: "AuditionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions");

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

            migrationBuilder.AddColumn<Guid>(
                name: "FestivalId",
                table: "ShowFestivalApplicationReviews",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("0420255b-52a9-442c-81ed-b2626685b561"), "Beograd", new DateTime(2023, 11, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5554), "Festival 2", null, new DateTime(2023, 10, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5539), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("1cfa698f-516f-451b-80d7-c4a70e7b05ad"), "Beograd", new DateTime(2023, 9, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5510), "Festival 1", null, new DateTime(2023, 8, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5491), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("52ea9009-7d82-4f17-98f4-98d6e505a4c3"), "Beograd", new DateTime(2024, 1, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5592), "Festival 3", null, new DateTime(2023, 12, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5577), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("88cd79ac-60e9-4c11-ac24-318b75c19748"), "Beograd", new DateTime(2024, 5, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5746), "Festival 5", null, new DateTime(2024, 4, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5731), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("a3d23763-d578-4d41-addd-b5dd984ec5e6"), "Beograd", new DateTime(2024, 3, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5631), "Festival 4", null, new DateTime(2024, 2, 3, 12, 0, 54, 145, DateTimeKind.Utc).AddTicks(5621), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_ShowFestivalApplicationReviews_FestivalId",
                table: "ShowFestivalApplicationReviews",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoleAuditions_AuditionId",
                table: "ActorShowRoleAuditions",
                column: "AuditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowFestivalApplicationReviews_Festivals_FestivalId",
                table: "ShowFestivalApplicationReviews",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id");
        }
    }
}
