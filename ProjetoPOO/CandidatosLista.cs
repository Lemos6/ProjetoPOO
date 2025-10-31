using System;
using System.Collections.Generic;

namespace ProjetoPOO
{
    internal class CandidatosLista
    {
        private List<Candidato> candidatos;

        public CandidatosLista()
        {
            candidatos = new List<Candidato>();

            // exemplos iniciais
            AdicionarCandidato(new Candidato { Id = 1, Nome = "Diana Pinto", idade = 42, podeVotar = true, jaVotou = false });
            AdicionarCandidato(new Candidato { Id = 2, Nome = "Bruno Costa", idade = 34, podeVotar = false, jaVotou = true });
            AdicionarCandidato(new Candidato { Id = 3, Nome = "Carlos Pereira", idade = 50, podeVotar = true, jaVotou = false });
            AdicionarCandidato(new Candidato { Id = 4, Nome = "Daniela Souza", idade = 37, podeVotar = false, jaVotou = true });
            AdicionarCandidato(new Candidato { Id = 5, Nome = "Eduardo Lima", idade = 29, podeVotar = true, jaVotou = false });
        }

        public void AdicionarCandidato(Candidato candidato)
        {
            if (candidato == null) throw new ArgumentNullException(nameof(candidato));
            candidatos.Add(candidato);
        }


        public void EscreverListaCandidatos()
        {
            Console.WriteLine("Lista de Candidatos:");
            for (int i = 0; i < candidatos.Count; i++)
            {
                var c = candidatos[i];
                Console.WriteLine($"{i + 1}. Nome={c.Nome}");
            }
        }

        public List<Candidato> ObterCandidatos()
        {
            return candidatos;
        }
    }
}
