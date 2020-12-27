using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoUrna.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoCandidato = table.Column<string>(nullable: true),
                    NomeCandidato = table.Column<string>(nullable: true),
                    NomeVice = table.Column<string>(nullable: true),
                    Legenda = table.Column<string>(nullable: true),
                    TipoCandidato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    CodigoVoto = table.Column<string>(nullable: false),
                    IdCandidato = table.Column<int>(nullable: true),
                    DataVoto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.CodigoVoto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Votos");
        }
    }
}
