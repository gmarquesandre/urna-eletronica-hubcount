﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoUrna.WebAPI.Data;

namespace ProjetoUrna.WebAPI.Migrations
{
    [DbContext(typeof(VotoContexto))]
    [Migration("20201210212157_iae")]
    partial class iae
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoUrna.WebAPI.Models.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoCandidato");

                    b.Property<string>("Legenda");

                    b.Property<string>("NomeCandidato");

                    b.Property<string>("NomeVice");

                    b.Property<int>("TipoCandidato");

                    b.HasKey("IdCandidato");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("ProjetoUrna.WebAPI.Models.Voto", b =>
                {
                    b.Property<string>("CodigoVoto")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataVoto");

                    b.Property<int?>("IdCandidato");

                    b.HasKey("CodigoVoto");

                    b.HasIndex("IdCandidato");

                    b.ToTable("Votos");
                });

            modelBuilder.Entity("ProjetoUrna.WebAPI.Models.Voto", b =>
                {
                    b.HasOne("ProjetoUrna.WebAPI.Models.Candidato", "Candidato")
                        .WithMany()
                        .HasForeignKey("IdCandidato");
                });
#pragma warning restore 612, 618
        }
    }
}
