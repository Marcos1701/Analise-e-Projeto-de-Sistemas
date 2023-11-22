using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATV.Migrations
{
    public partial class Atualization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho");

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                unique: true);
        }
    }
}
