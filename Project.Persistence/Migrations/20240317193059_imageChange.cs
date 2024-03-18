using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class imageChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId",
                column: "ConcurrencyStamp",
                value: "88cc4bda-201d-4359-afdd-3af04f2761df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employeeRoleId",
                column: "ConcurrencyStamp",
                value: "ce31fb62-db10-4d77-80e3-c7e7358cd3aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employerRoleId",
                column: "ConcurrencyStamp",
                value: "7d02f274-62c6-4ed4-a35f-aaf2ac7897fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "6b74f996-71b7-4899-846a-0b9d748133e9", "admin@boost.com", "AQAAAAEAACcQAAAAENgVVS/JKuGUPWh1ZbxUOhG0ChrIOVmenQB0X8VpN7P7eXdyXs3/tEKkvS5m0POCWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "1a51386f-b0ea-4cf6-a159-f11699238ff3", "employee@boost.com", "AQAAAAEAACcQAAAAEGl8IxQxxR3L7RDxtzd29QUO6tz47KlhZ1vTF01uAsbU1yPY+kQ2riS2IRflpEaR4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "173973e1-df75-4d3d-9d47-f57feb533c0c", "employer@boost.com", "AQAAAAEAACcQAAAAEPMAZpBfDvY3TJysG0xnPCoFLxW5vtIstQZh2OxZ+BfeZH9/oePY/8Aum1KCGvdx/Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId",
                column: "ConcurrencyStamp",
                value: "19d3abbd-e87e-47da-b5f6-5c9286f8fafa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employeeRoleId",
                column: "ConcurrencyStamp",
                value: "98817269-9892-4298-b42d-b34507508968");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employerRoleId",
                column: "ConcurrencyStamp",
                value: "d57de4ba-0535-4cf3-8a85-7b5ef136bfb9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "5bbfc0ac-78f2-4a1d-af25-3a9d0ad32cc1", "admin@contoso.com", "AQAAAAEAACcQAAAAEB0Jo8ni7z043pwe0sRQbhpdepaMrqDGh6VJoIQKOW08xvR4T1B3COnqpTRcHLgeeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "db62114a-3484-4212-9827-277de2f0a2a6", "employee@contoso.com", "AQAAAAEAACcQAAAAEGhuwaLxufcup6DrFwh1V8n3cqCQoSP6DWCf6s6qEARGD2sJ3AOumPUfC248AgdsrQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "9f51513b-16fb-4574-8c4a-c84c8bbd58ba", "employer@contoso.com", "AQAAAAEAACcQAAAAEG+/kT6ABnHm87d2h1wRIpNL477+m0hVcXHX4UuBqfgm3JZMXGlL8S1osPsrwMl9SA==" });
        }
    }
}
