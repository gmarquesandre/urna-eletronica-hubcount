using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUrna.WebAPI.Models
{
    public class Voto
    {
        [Key]
        public string CodigoVoto { get; set; }

        public int? IdCandidato { get; set; }

        public Candidato Candidato { get; set; }

        public DateTime DataVoto { get; set; }

        /*    Id do candidato(referência à tabela de candidatos)
            Data do voto(DateTime)
            Código de votação do cidadão, sendo a união da data no formato 
                yyyyMMdd com o IP da máquina em que está sendo feita a votação, 
                encriptografado em MD5(exemplo: 20201127192.168.0.1, que é igual a 97b4b4545f558b3d27cebf0aa8b8109e).
                */
    }
}
