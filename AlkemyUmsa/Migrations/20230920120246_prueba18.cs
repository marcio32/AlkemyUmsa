using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkemyUmsa.Migrations
{
    public partial class prueba18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_user_id",
                table: "Accounts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_user_id",
                table: "Accounts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_user_id",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_user_id",
                table: "Accounts");
        }
    }
}
