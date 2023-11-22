using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATV.Migrations
{
    public partial class Atualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UsuarioId",
                table: "Carrinho",
                column: "UsuarioId");
        }
    }
}
