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
        public bool podeVotar { get; set; }
        public bool jaVotou { get; set; }

        private const int IdadeMinima = 35;
        public bool ElegivelParaCandidatar()
        {
            bool elegivel = idade >= IdadeMinima;
            podeVotar = elegivel;
            return elegivel;
        }
    }
}
