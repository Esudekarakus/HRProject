using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class ini2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "74eb7a44-c2cd-4e94-afb9-678f60dcaaf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "8e102137-cce8-4eff-858e-f95fe17706a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "dc494541-a75e-4272-83f5-f948fed4abc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7e24d8a-7ad9-449b-a4ef-bb1e6d8ffea6", "AQAAAAEAACcQAAAAEEBtLq7ew+ndTCkXpKepVc5vty2cjgykYJXgm7ozM/n4T1BjlqAPHRe/YnxKlN+tzg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "15c0f282-8254-41a8-b899-c7629c19e21f", "AQAAAAEAACcQAAAAEJMm6DF7lNuOE4SwLj3QQk3TVm3IsuDlBpxCwdSqhBB+UZSVskTGKj36HUxBkqsvDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb466763-4029-493e-bcc1-0678dbb9516e", "AQAAAAEAACcQAAAAEMPKd88dFKxY5ipUm2j//UQ5Tl5u0oGM+2z54uCGlj0Xl9JbWp4aRO2nMeNv909/1A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VatNumber",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "d1b447bc-92b3-49d3-9e50-1c7e5c85464f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "1b1b0288-230f-4e1c-8086-3c51b7a7ced0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "8ab77ba4-7f62-401d-a48c-4dad9e51b6f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9f42fd6-4384-4bc7-b7d3-47db234cd243", "AQAAAAEAACcQAAAAEP/ucaSr/Wlkb7jEWcP5bTAs1qlkLIPayMWNETCex16dmrYgVvkcQuvl4f3mlfAPHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0cbd5a74-2678-4de4-8446-89ac40a5f730", "AQAAAAEAACcQAAAAEIuVorGYjxT/G8Ed1NquWvDARZ1JBUTWmSgMVgn7OHUWPWnlv4u4xxhqa5fF7FhxUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40d6d1fc-4006-40ba-b9bc-add8d037e54b", "AQAAAAEAACcQAAAAEB2Km22nNTPhlCZWigQe3HanNfWRhbGAKyy14fr/+bc9XAGIMszayEY8dnc593bOSQ==" });
        }
    }
}
