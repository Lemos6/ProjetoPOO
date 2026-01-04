using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public class EleicaoMenu 
    {
        public Eleicao criarEleicao()
        {
            Console.WriteLine("Escolha o tipo de eleição:");
            Console.WriteLine("1 - Presidencial");
            Console.WriteLine("2 - Assembleia");
            Console.WriteLine("3 - Municipal");

            int tipoInt;
            while (!int.TryParse(Console.ReadLine(), out tipoInt) || !Enum.IsDefined(typeof(Eleicao.TipoEleicao), tipoInt))
            {
                Console.WriteLine("Opção inválida.");
            }
            Eleicao.TipoEleicao tipo = (Eleicao.TipoEleicao)tipoInt;

            DateTime inicio = LerDataHora("Hora de início da votação (HH:mm): ");
            DateTime fim = LerDataHora("Hora de fim da votação (HH:mm): ");

            return new EleicaoPresidencial(tipo, inicio, fim);
        }
        private DateTime LerDataHora(string mensagem)
        {
            Console.Write(mensagem);
            TimeSpan hora = TimeSpan.Parse(Console.ReadLine());
            return DateTime.Today.Add(hora);
        }
    }
}
