using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class CandidatosLista
    {
        private List<Candidato> candidatos;
        public CandidatosLista()
        {
            candidatos = new List<Candidato>();
        }
        public void AdicionarCandidato(Candidato candidato)
        {

            candidatos.Add(candidato);
            AdicionarCandidato(new Candidato { Id = 1, Nome = "Ana Silva", idade = 42, podeVotar = true, jaVotou = false });
            AdicionarCandidato(new Candidato { Id = 2, Nome = "Bruno Costa", idade = 34, podeVotar = false, jaVotou = true });
            AdicionarCandidato(new Candidato { Id = 3, Nome = "Carlos Pereira", idade = 50, podeVotar = true, jaVotou = false });
            AdicionarCandidato(new Candidato { Id = 4, Nome = "Daniela Souza", idade = 37, podeVotar = false, jaVotou = true });
            AdicionarCandidato(new Candidato { Id = 5, Nome = "Eduardo Lima", idade = 29, podeVotar = true, jaVotou = false });

        }

        public List<Candidato> ObterCandidatos()
        {
            return candidatos;
        }

    }
}
