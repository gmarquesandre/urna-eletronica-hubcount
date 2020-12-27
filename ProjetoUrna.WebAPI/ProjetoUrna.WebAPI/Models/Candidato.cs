using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.WebAPI.Models
{
    public class Candidato
    {
        [Key]
        public int IdCandidato { get; set; }
        
        public string CodigoCandidato { get; set; }

        public string NomeCandidato { get; set; }

        public string NomeVice { get; set; }

        public string Legenda { get; set; }

        public int TipoCandidato { get; set; }

        /*
         * 
        Nome Completo(string)
        Nome do Vice(string?)
        Data de registro(DateTime)
        Legenda(int32)
        Tipo do Candidato(1-prefeito e 2-vereador)
        */

    }
}
