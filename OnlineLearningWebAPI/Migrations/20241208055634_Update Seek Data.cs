using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeekData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Student", "STUDENT" },
                    { "3", null, "VIP Student", "VIP STUDENT" },
                    { "4", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsBan", "IsVip", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "admin.png", "c92f77f9-a521-4646-9413-244bc726a760", "admin@example.com", false, false, false, false, null, null, null, "AQAAAAIAAYagAAAAEBCaFxA6UeetNFn0RFTqfHglx2rSN9Jdyv/OwEZzRJq4A7nS6m6R10dSxtlOdBONOQ==", null, false, "70f9f20c-d869-4ff0-924d-abe233b3ac8a", false, "admin_user" },
                    { "2", 0, "student.png", "42439893-ee2b-425d-a478-8fa9a9748dad", "student@example.com", false, false, false, false, null, null, null, "AQAAAAIAAYagAAAAEC848MjURxNjqnU3ehBq+dh2pMgUhSPWzfNKCrcQ07ykkxpPQGj3kK9SKswl9a7wOQ==", null, false, "ef1e3b30-dbf2-4273-9163-d2d0eaf1ad01", false, "student_user" },
                    { "3", 0, "vipstudent.png", "0ff3d837-cf3b-4c81-96a2-2b7a039f3674", "vipstudent@example.com", false, false, true, false, null, null, null, "AQAAAAIAAYagAAAAEFOKPw6DOIsz4Hd5AmOPplDuzTwzvB92PXCkerZtt8CXYUBG0qK/cFQno6QoWI1YEg==", null, false, "d1d35a08-bbe2-46b3-8929-50cb692473ab", false, "vip_student_user" },
                    { "4", 0, "teacher.png", "32bbf118-6ec5-4059-9af0-f9efcc5789a4", "teacher@example.com", false, false, false, false, null, null, null, "AQAAAAIAAYagAAAAEEymkm8uTpUOcA4QamcsjM5zG+GOQ73btESHSnLPbEvcnEipkmDMpM4m8iAPoHVQeQ==", null, false, "fbb620dd-2cd9-4888-b277-ed2b8b4bfaa9", false, "teacher_user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");
        }
    }
}
