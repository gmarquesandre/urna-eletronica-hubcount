using Microsoft.EntityFrameworkCore;
using ProjetoUrna.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.WebAPI.Data
{
    public class VotoContexto : DbContext
    {

        public VotoContexto(DbContextOptions<VotoContexto> options) : base(options)
        {

        }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Voto> Votos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Password=senha;Persist Security Info=True;User ID=usuario;Initial Catalog=Votacao;Data Source=DESKTOP-AR6RF1J");
        }

    }
}
