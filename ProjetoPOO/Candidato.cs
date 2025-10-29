using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int idade { get; set; }
        public int podeVotar { get; set; }
        public int jaVotou { get; set; }

        private const int IdadeMinima = 35;
        public bool ElegivelParaCandidatar()
        {
            return idade >= IdadeMinima;
        }
    }
}
