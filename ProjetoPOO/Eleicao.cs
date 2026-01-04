using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public abstract class Eleicao
    {
        public enum TipoEleicao
        {
            Presidencial = 1,
            Assembleia = 2,
            Municipal = 3
        }
        public string Nome { get; protected set; }
        public TipoEleicao Tipo { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataFim { get; protected set; }
        public List<Candidato> Candidatos { get; protected set; } = new List<Candidato>();
        public List<Voto> Votos { get; protected set; } = new List<Voto>();
        private string GerarNome(TipoEleicao tipo)
        {
            switch (tipo)
            {
                case TipoEleicao.Presidencial:
                    return "Eleição Presidencial";
                case TipoEleicao.Assembleia:
                    return "Eleição para a Assembleia";
                case TipoEleicao.Municipal:
                    return "Eleição Municipal";
                default:
                    return "Eleição";
            }
        } // <-- FECHAMENTO ADICIONADO AQUI
        public Eleicao(TipoEleicao tipo, DateTime inicio, DateTime fim)
        {
            if (fim <= inicio)
                throw new ArgumentException("A data de fim deve ser posterior à data de início.");

            Tipo = tipo;
            Nome = GerarNome(tipo);
            DataInicio = inicio;
            DataFim = fim;
        }
        public bool VotacaoAberta()
        {
            DateTime agora = DateTime.Now;
            return agora >= DataInicio && agora <= DataFim;
        }


        public abstract int QuorumMinimo();

        // Overload que recebe um candidato e registra o voto (usa o Tipo da eleição)
        public void RegistarVoto(Candidato candidato)
        {
            if (!VotacaoAberta())
                throw new InvalidOperationException("Votação encerrada."); // ou lance VotacaoEncerradaException se existir

            var voto = new Voto(candidato.Id); // Corrigido: passa o idCandidato exigido pelo construtor

            typeof(Voto).GetProperty("DataVoto").SetValue(voto, DateTime.Now);
            typeof(Voto).GetProperty("TipoEleicao").SetValue(voto, this.Tipo);

            Votos.Add(voto);
        }

        public void RegistarVoto(Voto voto)
        {
            Votos.Add(voto);
        }
    }
}
