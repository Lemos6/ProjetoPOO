using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPOO.Servicos;

namespace ProjetoPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin(
                id: 999,
                nome: "admin",
                senha: "admin123"
                );
            // 2️⃣ Criar serviços
            AdminService adminService = new AdminService(admin);
            EleicaoService eleicaoService = new EleicaoService();

            // 3️⃣ Criar eleição
            Eleicao eleicaoAtual = eleicaoService.CriarEleicao();

            var listaCandidatos = new CandidatosLista();
            var listaEleitores = new EleitoresLista();
            var sistemaVotacao = new SistemaVotacao(listaCandidatos, listaEleitores);
            while (true) {
                Console.WriteLine("=========================================");
                Console.WriteLine("         SISTEMA DE VOTAÇÃO");
                Console.WriteLine("=========================================");
                Console.WriteLine("Deseja iniciar uma nova eleição? (s/n): ");
                var resposta = Console.ReadKey();
                if (resposta.KeyChar == 's' ) 
                break;
            }

            bool adminAutenticado = false;
            while (!adminAutenticado) 
            {
                Console.WriteLine("Inicie Sessáo como Admin");
                Console.WriteLine("Digite o seu ID");
                var id = Console.ReadLine();
                if (id == "999")
                {
                    // repetir a solicitação da senha até que esteja correta
                    while (!adminAutenticado)
                    {
                        Console.WriteLine("Digite a sua senha.");
                        var tentativa = Console.ReadLine();
                        if (admin.Autenticar(admin.Nome, tentativa))
                        {
                            Console.WriteLine("Autenticação bem-sucedida!");
                            adminAutenticado = true;
                            // passa também a lista de candidatos para sincronizar adições do admin
                            AdminMenu.Executar(adminService, eleicaoAtual, listaCandidatos);
                        }
                        else
                        {
                            Console.WriteLine("Falha na autenticação. Senha incorreta. Tente novamente.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ID incorreto. Tente novamente.");
                }
            }

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
