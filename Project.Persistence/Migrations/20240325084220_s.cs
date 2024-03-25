using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Persistence.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "1c28fade-803d-4312-9102-a25c519dc2a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "0dcbe8a0-dccf-4609-bda4-7e936d842708");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "6797d025-2063-4217-94c2-b01e8c326f01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c092918-3ca5-4d03-8d71-9bddbdbaf7c4", "AQAAAAEAACcQAAAAEK4e5Q4mVro+zDvzOUaVumyVNFk7a2ugf9ygIPjM/cBxfOQE3gOtGu1aPm499U//KQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "928e1a39-ec3e-4747-a742-ce79e7c9e0b8", "AQAAAAEAACcQAAAAEBgN9V9VrTy+MmfkGDVWRtEcBChPaGYjWc81S17n5HS8rL7Z1sj0ILodtXTqUnUuGQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99d71e54-b69c-4a44-8baf-e545535e98d1", "AQAAAAEAACcQAAAAELiRBQT7SH2wTtbVJkZlpqhK57ldfu3W0PHKTOiCP8DSptC4EBwShiRK9COlF3Ff6A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "AdminRoleID",
                column: "ConcurrencyStamp",
                value: "7494f645-7488-47ad-bb8f-a46dc30bdbde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployeeRoleID",
                column: "ConcurrencyStamp",
                value: "d551155a-83d9-42df-b94a-e39d09e0f9bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EmployerRoleID",
                column: "ConcurrencyStamp",
                value: "486a68b4-6db5-44d5-b7a1-c20afc308c43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69080124-b63b-4372-a359-7b2d7e20e312", "AQAAAAEAACcQAAAAEHyb3uIuHtoT+YwmOZWWHFrVWT2mkIS8F+JcWlFjxi4pGx0b64nbz0wGuS6mnqUHzg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employeeUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1f8b7ed-146d-48a5-8609-bd6a073f886a", "AQAAAAEAACcQAAAAEDA62VgMICEyto7eFWvOOVKq//ge7+4KKB9b2x/x5+LHenJpgCPHWenWrtRHXL7wvg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "employerUserId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8139ec90-da73-488d-8b9e-4c8508c87aec", "AQAAAAEAACcQAAAAEPu7JakRK1r2VSD68tAfY+ueJB3mmQMKWmxYw7vOD6B3NkZQ6Z8gYxda/5zlEqLYig==" });
        }
    }
}
