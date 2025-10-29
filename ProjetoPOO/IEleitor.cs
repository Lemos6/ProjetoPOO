using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal interface IEleitor
    {
        string Id { get; }
        string Nome { get; }
        int Idade { get; }
        bool podeVotar { get; }
        bool jaVotou { get; }
        void ElegivelParaVotar();
    }
}
