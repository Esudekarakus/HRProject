using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOFContractEnd",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfContractStart",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MersisNo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOffice",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "9ef09d58-0d02-42e8-abb6-32bbabcd6747");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "5733b176-0ad9-4846-8d2d-5daf6eccbf7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "e0991338-0d69-4469-b3cd-cada733b6df3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cafc06d-b61b-4f78-933c-38781fd3ac33", "AQAAAAEAACcQAAAAEK8xAKiQXE7qUMUIULy/u9UzI6kWv0PYFgbQJXFUHikOngmKh83P8Bi12YEecouNig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f520a15f-a89b-4c7c-8c39-95a83591945d", "AQAAAAEAACcQAAAAEE8caVLb8dTPYQ8YYX80KJ/6wiStaA2ldV1y4YXrweLhKGxQdhwoy77oTND8ANBcmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88dd8383-6c59-47bd-b4c9-8130fc01908d", "AQAAAAEAACcQAAAAEL+vyBbg5h1ILwRQwmfE/gyhkOzbhgKGE1jYgfipPDayY/N1QuWwbAMHei/tLHAn9w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOFContractEnd",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DateOfContractStart",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MersisNo",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TaxOffice",
                table: "Companies");

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
    }
}
