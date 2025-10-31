using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class Eleitor
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool PodeVotar
        {
            get { return Idade >= 18; }
        }
        public bool JaVotou { get; set; }
        public bool ElegivelParaVotar
        {
            get { return PodeVotar && !JaVotou; }
        }
    }
}
