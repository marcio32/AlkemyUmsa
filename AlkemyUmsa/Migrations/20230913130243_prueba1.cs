using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkemyUmsa.Migrations
{
    public partial class prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_firstName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_lastName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    user_password = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_activo", "role_description", "role_name" },
                values: new object[] { 1, true, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "role_id", "role_activo", "role_description", "role_name" },
                values: new object[] { 2, true, "Consulta", "Consulta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_email", "user_firstName", "user_lastName", "user_password", "role_id" },
                values: new object[] { 1, "marcioabriola@yahoo.com", "Marcio", "Abriola", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
