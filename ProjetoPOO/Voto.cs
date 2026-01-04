using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public enum TipoEleicao
    {
        Presidencial,
        Parlamentar,
        Municipal
    }
    public class Voto
    {
        public Guid IdVoto { get; private set; }
        public int IdCandidato { get; private set; }
        public DateTime DataVoto { get; private set; }
        public TipoEleicao TipoEleicao { get; private set; }
        public Voto(int idCandidato)
        {
            IdVoto = Guid.NewGuid();
            IdCandidato = idCandidato;
            DataVoto = DateTime.Now;
            TipoEleicao = TipoEleicao;
        }
    }
}
