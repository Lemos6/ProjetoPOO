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
                    // Adicione outros cases conforme necessário
                }
            }
        }
    }
}
