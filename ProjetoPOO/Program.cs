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
            var listaCandidatos = new CandidatosLista();
            var listaEleitores = new EleitoresLista();
            var sistemaVotacao = new SistemaVotacao(listaCandidatos, listaEleitores);

            while (true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("--- Sistema de Votação ---");
                Console.WriteLine("=================================");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Listar Candidatos");
                Console.WriteLine("2. Listar Eleitores");
                Console.WriteLine("3. Votar");
                Console.WriteLine("4. Sair");
                Console.Write("\nOpção: ");

                var escolha = Console.ReadLine();
                Console.WriteLine();

                if (escolha == "4")
                {
                    Console.WriteLine("Encerrando sistema...");
                    break;
                }

                switch (escolha)
                {
                    case "1":
                        ListarCandidatosDetalhado(listaCandidatos);
                        break;
                    case "2":
                        ListarEleitores(listaEleitores);
                        break;
                    case "3":
                        sistemaVotacao.ProcessarVotacao();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ListarCandidatosDetalhado(CandidatosLista lista)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("         LISTA COMPLETA DE CANDIDATOS");
            Console.WriteLine("==========================================");

            var candidatos = lista.ObterCandidatos();

            if (candidatos.Count == 0)
            {
                Console.WriteLine("Nenhum candidato registrado.");
                return;
            }

            foreach (var c in candidatos)
            {
                Console.WriteLine($"\nID: {c.Id}");
                Console.WriteLine($"Nome: {c.Nome}");
                Console.WriteLine($"Idade: {c.idade} anos");
                Console.WriteLine($"Elegível para candidatura: {(c.ElegivelParaCandidatar() ? "Sim" : "Não")}");
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine($"\nTotal de candidatos: {candidatos.Count}");
        }

        static void ListarEleitores(EleitoresLista lista)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("         LISTA COMPLETA DE ELEITORES");
            Console.WriteLine("==========================================");

            var eleitores = lista.ObterTodos();

            if (eleitores.Count == 0)
            {
                Console.WriteLine("Nenhum eleitor registrado.");
                return;
            }

            foreach (var e in eleitores)
            {
                Console.WriteLine($"\nID: {e.Id}");
                Console.WriteLine($"Nome: {e.Nome}");
                Console.WriteLine($"Idade: {e.Idade} anos");
                Console.WriteLine($"Pode votar: {(e.PodeVotar ? "Sim" : "Não (menor de 18)")}");
                Console.WriteLine($"Já votou: {(e.JaVotou ? "Sim" : "Não")}");
                Console.WriteLine($"Elegível para votar: {(e.ElegivelParaVotar ? "Sim" : "Não")}");
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine($"\nTotal de eleitores: {eleitores.Count}");
        }
    }
}
