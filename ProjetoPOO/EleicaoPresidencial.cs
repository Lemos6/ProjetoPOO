using System;

namespace ProjetoPOO
{
    public class EleicaoPresidencial : Eleicao
    {
        public EleicaoPresidencial(TipoEleicao tipo, DateTime inicio, DateTime fim)
            : base(tipo, inicio, fim)
        {
        }

        public override int QuorumMinimo()
        {
            // Implementação mínima; ajuste conforme a regra de negócio
            return 1;
        }
    }
}