using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoUrna.WebAPI.Data;
using ProjetoUrna.WebAPI.Dto;
using ProjetoUrna.WebAPI.Models;

namespace ProjetoUrna.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly VotoContexto _context; 

        public ValuesController(VotoContexto context)
        {
            _context = context;
        }


        [HttpGet("GetCandidates")]
        public ActionResult RetornaCandidatos()
        {
           //var listaCandidato = _context.Candidatos.ToList();
           var listaCandidato = (from candidato in _context.Candidatos
                                 select candidato).ToList();
                                    
            return Ok(listaCandidato);
        }

        [HttpGet("GetCandidates/{codigoCandidato}")]
        public ActionResult RetornaCandidatos(string codigoCandidato)
        {

            var candidato = _context.Candidatos
                                .Where(h => h.CodigoCandidato== codigoCandidato)
                                .FirstOrDefault();


            return Ok(candidato);
        }

        //Cria Candidato
        [HttpPost("PostCandidate/{codigoCandidato},{nomeCandidato},{legenda},{nomeVice},{tipoCandidato}")]
        public ActionResult<string> Get(
                                    
                                                string codigoCandidato,
                                                string nomeCandidato,
                                                string legenda,
                                                string nomeVice,
                                                int tipoCandidato
            )
        {
            var candidato = new Candidato {
                CodigoCandidato = codigoCandidato,
                NomeCandidato = nomeCandidato,
                Legenda = legenda,
                NomeVice = nomeVice,
                TipoCandidato = tipoCandidato};

            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            
            return Ok();
        }

        //Edita Candidato
        [HttpPost("EditCandidate/{Id},{codigoCandidato},{nomeCandidato},{legenda},{nomeVice},{tipoCandidato}")]
        public ActionResult<string> EditaCandidato(
                                                int Id, 
                                                string codigoCandidato,
                                                string nomeCandidato, 
                                                string legenda, 
                                                string nomeVice, 
                                                int tipoCandidato
            )
        {

            var candidato = _context.Candidatos
                                .Where(h => h.IdCandidato == Id)
                                .FirstOrDefault();
            candidato.CodigoCandidato = codigoCandidato;
            candidato.NomeCandidato = nomeCandidato;
            candidato.Legenda = legenda;
            candidato.NomeVice = nomeVice;
            candidato.TipoCandidato = tipoCandidato;

            _context.SaveChanges();
            return Ok(candidato);
            

        }

        // Deleta Candidato
        [HttpDelete("DeleteCandidate/{id}")]
        public void DeletaCandidato(int id)
        {
            var candidato = _context.Candidatos
                .Where(x => x.IdCandidato == id)
                .Single();
            _context.Candidatos.Remove(candidato);

            _context.SaveChanges();
           
        }


        //Retorna Voto

        [HttpGet("GetVote")]
        public ActionResult<string> RetornaVotos()
        {
            var contagem_votos = from r in _context.Votos
                                 group r by (r.IdCandidato == null ? 0 : r.IdCandidato) into rg
                                 select new {
                                     IdCandidato = rg.Key,
                                     votos = rg.Distinct().Count()
                                 };

            var query = _context.Votos
                .GroupBy(a => a.IdCandidato)
                .Select(a => new VotoDto {
                    IdCandidato = a.Key,
                    Votos = a.Count()
                })
                .ToList();

            var candidatos = _context.Candidatos.ToList();

            foreach (var c in query)
            {
                if (!c.IdCandidato.HasValue)
                    continue;

                var candidato = candidatos.FirstOrDefault(a => a.IdCandidato == c.IdCandidato);

                c.IdCandidato = candidato.IdCandidato;
                c.NomeCandidato = candidato.NomeCandidato;
                c.NomeVice = candidato.NomeVice;
                c.TipoCandidato = candidato.TipoCandidato;
                c.CodigoCandidato = candidato.CodigoCandidato;
                c.Legenda = candidato.Legenda;

            }

            return Ok(query);
        }
    


        //Adiciona Voto
        [HttpPost("PostVote/{id},{codigoVoto}")]
        public ActionResult<string> AdicionaVoto(int? id,  string codigoVoto)
        {
           
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day,
                        now.Hour, now.Minute, now.Second);

            var voto = new Voto {

                IdCandidato = id,
                DataVoto = date,
                CodigoVoto = codigoVoto };

            _context.Votos.Add(voto);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("PostVote/{codigoVoto}")]
        public ActionResult<string> AdicionaVoto(string codigoVoto)
        {
           
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day,
                        now.Hour, now.Minute, now.Second);

            var voto = new Voto {

                IdCandidato = null,
                DataVoto = date,
                CodigoVoto = codigoVoto };

            _context.Votos.Add(voto);

            _context.SaveChanges();

            return Ok();
        }

    }



}
