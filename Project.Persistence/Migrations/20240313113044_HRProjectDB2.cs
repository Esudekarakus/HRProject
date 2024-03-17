using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class HRProjectDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployerID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId",
                column: "ConcurrencyStamp",
                value: "6e7afbea-eefe-4a8d-962e-e97024aa72ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employeeRoleId",
                column: "ConcurrencyStamp",
                value: "a9135f8b-4f1d-4b60-af9d-35f300f3e7d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employerRoleId",
                column: "ConcurrencyStamp",
                value: "b0e611a6-7cae-49b6-8f09-29fda42fbe28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2885eb56-99e4-4f77-9d29-f1221b784d8b", "AQAAAAEAACcQAAAAEG/JGDgWTmb+LetGNaMcNhF0WmzvB057RNprX02AW/OMfdEgboVA1LptxMe02/6rfw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837d3fe2-dd92-4d58-9dbc-86fb23f09216", "AQAAAAEAACcQAAAAEE5lG4AC868GgVaWUU6fTFYDHmgvHF/91QOO5OttpKyeYg2XW0d119/8JT0BkvnUBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c4433f7-d9cb-48cd-97f3-4436f250e193", "AQAAAAEAACcQAAAAENZnnqJhr4k4Dr0qf/DbV8BAufGCmj47RV0lq0fLXT70DIJdrnBYbEzf0JYkTFaceQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployeeID",
                table: "AspNetUsers",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeID",
                table: "AspNetUsers",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerID",
                table: "AspNetUsers",
                column: "EmployerID",
                principalTable: "Employers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployeeID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmployerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployerID",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId",
                column: "ConcurrencyStamp",
                value: "98b6047f-84bc-4804-b7d8-4e4350d27d95");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bbfc0ac-78f2-4a1d-af25-3a9d0ad32cc1", "AQAAAAEAACcQAAAAEB0Jo8ni7z043pwe0sRQbhpdepaMrqDGh6VJoIQKOW08xvR4T1B3COnqpTRcHLgeeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db62114a-3484-4212-9827-277de2f0a2a6", "AQAAAAEAACcQAAAAEGhuwaLxufcup6DrFwh1V8n3cqCQoSP6DWCf6s6qEARGD2sJ3AOumPUfC248AgdsrQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f51513b-16fb-4574-8c4a-c84c8bbd58ba", "AQAAAAEAACcQAAAAEG+/kT6ABnHm87d2h1wRIpNL477+m0hVcXHX4UuBqfgm3JZMXGlL8S1osPsrwMl9SA==" });
        }
    }
}
