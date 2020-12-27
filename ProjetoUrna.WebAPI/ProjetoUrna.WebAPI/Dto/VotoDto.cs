using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.WebAPI.Dto
{
    public class VotoDto
    {
        public int? IdCandidato { get; set; }

        public int Votos { get; set; }

        public string NomeCandidato { get; set; }
        public string NomeVice { get; set; }
        public int TipoCandidato { get; set; }
        public string CodigoCandidato { get; set; }
        public string Legenda { get; internal set; }
        //public int IdCandidato { get; internal set; }
    }
}
