using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoUrna.WebAPI.Migrations
{
    public partial class add_candidato_votos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Votos_IdCandidato",
                table: "Votos",
                column: "IdCandidato");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Candidatos_IdCandidato",
                table: "Votos",
                column: "IdCandidato",
                principalTable: "Candidatos",
                principalColumn: "IdCandidato",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Candidatos_IdCandidato",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Votos_IdCandidato",
                table: "Votos");
        }
    }
}
