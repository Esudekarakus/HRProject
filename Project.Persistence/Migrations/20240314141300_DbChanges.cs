using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class DbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrivateMail",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrivateMail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId",
                column: "ConcurrencyStamp",
                value: "950781fe-db8e-4811-b050-3b7ec9c14b24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employeeRoleId",
                column: "ConcurrencyStamp",
                value: "a2914a83-c3ab-4048-a1fe-62923bdc3dd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "employerRoleId",
                column: "ConcurrencyStamp",
                value: "0d29650c-9186-4368-8f85-6388d90f761e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c950c0a-56b5-434b-8854-0f8c74ae87bc", "AQAAAAEAACcQAAAAEBrGnan5+iaykm6NYaSQ6YOEf71fe+EQvYf+MtphNADaJYhwrZPiqskLstblYW5/lA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11d643a6-1214-468f-ad2a-cfccb1f273c0", "AQAAAAEAACcQAAAAEGU/HThYsP4UvH/E+7cvDVRdk0AsODdUY/S8HkerPTfovshXAVTFhUdoKm6zNLsvVg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c2b539a-1ea3-4ad5-b87c-0b68b491fce1", "AQAAAAEAACcQAAAAEFY4fUO5HxrKIv2/fG6zGLYc9lSVsywW4qqPrmm8HbUsDZOKT4OOee4rlEKVhtRXUg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivateMail",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "PrivateMail",
                table: "Employees");

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
        }
    }
}
