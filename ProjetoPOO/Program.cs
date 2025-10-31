using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciar a lista de candidatos
            var listaCandidatos = new CandidatosLista();
            var eleitorAtual = new Eleitor();

            while (true)
            {
                Console.WriteLine("--- Sistema de Votação ---");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar Candidatos");
                Console.WriteLine("2. Listar Eleitores");
                Console.WriteLine("3. Mostrar Lista de Candidatos");
                Console.WriteLine("4. Candidatar-se");
                Console.WriteLine("5.Votar");
                Console.WriteLine("6. Sair");

                var escolha = Console.ReadLine();
                if (escolha == "6") break;

                switch (escolha)
                {
                    case "3":
                        listaCandidatos.EscreverListaCandidatos();
                        break;
                    case "5":
                       
                        var votar = new Votar();
                        var candidatos = votar.ObterCandidatos();
                        Console.WriteLine("Digite o número do candidato para votar:");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out int numeroCandidato) &&
                            numeroCandidato >= 1 && numeroCandidato <= candidatos.Count)
                        {
                            var candidatoEscolhido = candidatos[numeroCandidato - 1];
                            Console.WriteLine($"Você votou em: {candidatoEscolhido.Nome}");
                            eleitorAtual.JaVotou = true;
                        }
                        else
                        {
                            Console.WriteLine("Número de candidato inválido.");
                        }
                        break;
                }
            }
        }
    }
}
