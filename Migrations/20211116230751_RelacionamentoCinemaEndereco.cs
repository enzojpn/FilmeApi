using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesApi.Migrations
{
    public partial class RelacionamentoCinemaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Cinemas",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_EnderecoId",
                table: "Cinemas",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Endereco_EnderecoId",
                table: "Cinemas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Endereco_EnderecoId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_EnderecoId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Cinemas");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cinemas",
                newName: "nome");
        }
    }
}
