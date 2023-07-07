using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class DodaoIdUActorShowRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                table: "ActorShowRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorShowRoles",
                table: "ActorShowRoles");

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

            migrationBuilder.AlterColumn<string>(
                name: "ActorId",
                table: "ActorShowRoles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ActorShowRoles",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorShowRoles",
                table: "ActorShowRoles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("33bdcfd0-0859-47f0-b22f-c668f8fec402"), "Beograd", new DateTime(2023, 11, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6844), "Festival 2", null, new DateTime(2023, 10, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6844), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("6a98c113-b919-4178-875b-d7b8f1471d9e"), "Beograd", new DateTime(2024, 1, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6851), "Festival 3", null, new DateTime(2023, 12, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6850), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("7359481f-dd68-4e0d-b328-dc61a2fa020e"), "Beograd", new DateTime(2024, 5, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6864), "Festival 5", null, new DateTime(2024, 4, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6863), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("95f8519b-2eba-4ac2-9f32-39140b4d9ead"), "Beograd", new DateTime(2024, 3, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6857), "Festival 4", null, new DateTime(2024, 2, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6857), 36300 });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "City", "EndDate", "Name", "OrganizerId", "StartDate", "ZipCode" },
                values: new object[] { new Guid("dcece2a1-f53e-463c-b716-28179c7b0ee5"), "Beograd", new DateTime(2023, 9, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6836), "Festival 1", null, new DateTime(2023, 8, 7, 5, 23, 7, 642, DateTimeKind.Utc).AddTicks(6831), 36300 });

            migrationBuilder.CreateIndex(
                name: "IX_ActorShowRoles_ActorId",
                table: "ActorShowRoles",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                table: "ActorShowRoles",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                table: "ActorShowRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorShowRoles",
                table: "ActorShowRoles");

            migrationBuilder.DropIndex(
                name: "IX_ActorShowRoles_ActorId",
                table: "ActorShowRoles");

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("33bdcfd0-0859-47f0-b22f-c668f8fec402"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("6a98c113-b919-4178-875b-d7b8f1471d9e"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("7359481f-dd68-4e0d-b328-dc61a2fa020e"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("95f8519b-2eba-4ac2-9f32-39140b4d9ead"));

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: new Guid("dcece2a1-f53e-463c-b716-28179c7b0ee5"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActorShowRoles");

            migrationBuilder.AlterColumn<string>(
                name: "ActorId",
                table: "ActorShowRoles",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorShowRoles",
                table: "ActorShowRoles",
                columns: new[] { "ActorId", "RoleId", "ShowId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActorShowRoles_AspNetUsers_ActorId",
                table: "ActorShowRoles",
                column: "ActorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
