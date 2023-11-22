using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATV.Migrations
{
    public partial class Atualizati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho");

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

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId",
                unique: true);
        }
    }
}
