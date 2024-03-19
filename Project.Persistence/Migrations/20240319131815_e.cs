using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "d5c251f9-9d32-410f-807a-fe2150dbb990");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "e5359bcd-6989-4d95-b7dd-7a3aa5edb80e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "9091926f-1fa0-49d6-9986-af476ac6abf5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6843b3a8-4c8e-4057-8c47-1d1aeff507d2", "AQAAAAEAACcQAAAAEI+Cf/btKibqZFIZhJlZdRfTD1mo99MYOKStImhjfOhQOhEz6gqjZozLbMseoYDeGQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "369a137b-b666-4f06-a17f-044d4bc56ebf", "AQAAAAEAACcQAAAAEPb97eGlere0gP4wuZsw59aIfuurNc/2F1hGkTHiW8JmyusII7TKyjOg0r2PMrjdiw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a75ddfb6-0d9f-4a7a-824e-9d57deef8bb7", "AQAAAAEAACcQAAAAEH74NFlmGU/Vw+S81MW7pHBKcHCLj5dAk+qZi3Id1WecJc3MCs/xlU13p4SNIUm3Ag==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "82c3fd96-a1f8-40ef-8f84-defbef01f2d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "a6d41a4f-85dd-4215-b31a-2400ff0d28c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "dd02b054-1881-43f9-9166-f2b0d4dacc55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6da3e912-2938-409a-a364-d262e5e752bf", "AQAAAAEAACcQAAAAEAKCjSsSyDjP4JvUZI1xar3rgv1TSX5d7ovssHLgEBZRQa8Jx64HklrLphZSME5cfA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0042adda-9862-4a5b-819b-51e1e33d4d7d", "AQAAAAEAACcQAAAAEH+UO5aoBbLmBek+ipwczzJX5ayPLOqjLr+rWjl1lg/y5RvgBXiS9euSTdksLohF0A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "61410041-2af3-40fa-9060-d166576c9250", "AQAAAAEAACcQAAAAEH7U5U+GwIHF/L8544XShZcPrnaTeTPAtVeJcdaGHQ5yPW3zOnjjUuiIgo5u8Ya3VA==" });
        }
    }
}
