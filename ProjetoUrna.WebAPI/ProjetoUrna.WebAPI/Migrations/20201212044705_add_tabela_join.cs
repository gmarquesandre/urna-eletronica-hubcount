using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoUrna.WebAPI.Migrations
{
    public partial class add_tabela_join : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Candidatos_IdCandidato",
                table: "Votos");

            migrationBuilder.DropIndex(
                name: "IX_Votos_IdCandidato",
                table: "Votos");

            migrationBuilder.CreateTable(
                name: "VotosCandidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false),
                    CodigoVoto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotosCandidatos", x => new { x.CodigoVoto, x.IdCandidato });
                    table.ForeignKey(
                        name: "FK_VotosCandidatos_Votos_CodigoVoto",
                        column: x => x.CodigoVoto,
                        principalTable: "Votos",
                        principalColumn: "CodigoVoto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotosCandidatos_Candidatos_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidatos",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotosCandidatos_IdCandidato",
                table: "VotosCandidatos",
                column: "IdCandidato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotosCandidatos");

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
    }
}
