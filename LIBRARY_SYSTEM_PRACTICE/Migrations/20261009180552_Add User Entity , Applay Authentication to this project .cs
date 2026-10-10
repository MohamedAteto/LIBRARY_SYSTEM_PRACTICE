using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARY_SYSTEM_PRACTICE.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntityApplayAuthenticationtothisproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2026, 10, 2, 21, 5, 50, 863, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 2,
                column: "BorrowDate",
                value: new DateTime(2026, 10, 4, 21, 5, 50, 863, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.CreateIndex(
                name: "IX_users_UserName",
                table: "users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2026, 9, 28, 14, 32, 40, 840, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "Borrowings",
                keyColumn: "BorrowingId",
                keyValue: 2,
                column: "BorrowDate",
                value: new DateTime(2026, 9, 30, 14, 32, 40, 840, DateTimeKind.Local).AddTicks(648));
        }
    }
}
