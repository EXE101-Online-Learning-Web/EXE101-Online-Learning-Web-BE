using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8f7b711-2c19-4e8e-a4c5-983546cf0fe5", "Aa1234@", "881c1dcb-213f-4e03-896f-c8e541ba0eeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab86bc6a-a21b-4c51-bb71-083a8e14af60", "Aa1234@", "79738b00-e51c-44d4-a218-2feee3bbb1b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e678c7fd-da9a-4d98-9901-b8e11bb8407a", "Aa1234@", "83cf1749-d2a6-431c-a03f-3b49c6a2dae6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "349adafd-7f1e-41b8-8e65-01e882a17eab", "Aa1234@", "9b900730-8888-439e-9937-5c43b7dbf6d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c92f77f9-a521-4646-9413-244bc726a760", "AQAAAAIAAYagAAAAEBCaFxA6UeetNFn0RFTqfHglx2rSN9Jdyv/OwEZzRJq4A7nS6m6R10dSxtlOdBONOQ==", "70f9f20c-d869-4ff0-924d-abe233b3ac8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42439893-ee2b-425d-a478-8fa9a9748dad", "AQAAAAIAAYagAAAAEC848MjURxNjqnU3ehBq+dh2pMgUhSPWzfNKCrcQ07ykkxpPQGj3kK9SKswl9a7wOQ==", "ef1e3b30-dbf2-4273-9163-d2d0eaf1ad01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ff3d837-cf3b-4c81-96a2-2b7a039f3674", "AQAAAAIAAYagAAAAEFOKPw6DOIsz4Hd5AmOPplDuzTwzvB92PXCkerZtt8CXYUBG0qK/cFQno6QoWI1YEg==", "d1d35a08-bbe2-46b3-8929-50cb692473ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32bbf118-6ec5-4059-9af0-f9efcc5789a4", "AQAAAAIAAYagAAAAEEymkm8uTpUOcA4QamcsjM5zG+GOQ73btESHSnLPbEvcnEipkmDMpM4m8iAPoHVQeQ==", "fbb620dd-2cd9-4888-b277-ed2b8b4bfaa9" });
        }
    }
}
