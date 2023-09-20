using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkemyUmsa.Migrations
{
    public partial class prueba16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    account_money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    account_isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.account_id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "account_id", "account_creationDate", "account_isBlocked", "account_money", "user_id" },
                values: new object[] { 1, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1000m, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "user_password",
                value: "7ba97c4f66a05b1d9ef83d2d910ef655b09a57726fff38e0f69c07fe82357095");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "user_password",
                value: "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4");
        }
    }
}
