using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPOO;

namespace ProjetoPOO.Servicos
{
    public class AdminService
    {
        private readonly Admin adminAutorizado;

        public AdminService(Admin admin)
        {
            adminAutorizado = admin;
        }

        public void AutenticarAdmin()
        {
            Console.Write("Palavra-passe de admin: ");
            string senha = Console.ReadLine();

            if (!adminAutorizado.Autenticar(adminAutorizado.Nome, senha))
                throw new AutenticacaoFalhadaException();
        }

        public void AdicionarCandidato(Eleicao eleicao, Candidato candidato)
        {
            eleicao.Candidatos.Add(candidato);
        }

        public void RemoverCandidato(Eleicao eleicao, int candidatoId)
        {
            var candidato = eleicao.Candidatos
                .FirstOrDefault(c => c.Id == candidatoId);

            if (candidato == null)
                throw new Exception("Candidato não encontrado.");

            eleicao.Candidatos.Remove(candidato);
        }

        // NOVO: Permite ao Admin iniciar a votação agora por uma duração
        public void IniciarVotacaoAgora(Eleicao eleicao, TimeSpan duracao)
        {
            eleicao.IniciarAgora(duracao);
        }

        // NOVO: Permite ao Admin definir horário manualmente
        public void DefinirPeriodoVotacao(Eleicao eleicao, DateTime inicio, DateTime fim)
        {
            eleicao.DefinirPeriodoVotacao(inicio, fim);
        }
    }

    // Helper para mover o código de exemplo (antes em nível superior) para dentro de um método,
    // evitando _instruções de nível superior_ que não são suportadas em C# 7.3.
    internal static class AdminMenu
    {
        // Atualizado: recebe também a lista global de candidatos para sincronizar adições/remoções.
        internal static void Executar(AdminService adminService, Eleicao eleicaoAtual, CandidatosLista listaCandidatos)
        {
            if (adminService == null) throw new ArgumentNullException(nameof(adminService));
            if (eleicaoAtual == null) throw new ArgumentNullException(nameof(eleicaoAtual));
            if (listaCandidatos == null) throw new ArgumentNullException(nameof(listaCandidatos));

            while (true)
            {
                Console.WriteLine("Menu Admin: 1-Adicionar candidato  2-Remover candidato  3-Iniciar votação  4-Sair");
                var op = Console.ReadLine();
                if (op == "1")
                {
                    // ler dados e criar Candidato c
                    Console.Write("Id do candidato: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Id inválido. Operação cancelada.");
                        continue;
                    }

                    Console.Write("Nome do candidato: ");
                    var nome = Console.ReadLine();

                    Console.Write("Idade do candidato: ");
                    if (!int.TryParse(Console.ReadLine(), out int idade))
                    {
                        Console.WriteLine("Idade inválida. Operação cancelada.");
                        continue;
                    }

                    var c = new Candidato
                    {
                        Id = id,
                        Nome = nome,
                        idade = idade,
                        // podeVotar será ajustado por ElegivelParaCandidatar
                        jaVotou = false
                    };

                    // Verifica elegibilidade mínima antes de adicionar
                    if (!c.ElegivelParaCandidatar())
                    {
                        Console.WriteLine("Candidato NÃO ADICIONADO: não cumpre a idade mínima para candidatura.");
                        continue;
                    }

                    // adiciona tanto à eleição atual (se aplicável) quanto à lista global de candidatos
                    try
                    {
                        adminService.AdicionarCandidato(eleicaoAtual, c);
                        listaCandidatos.AdicionarCandidato(c);
                        Console.WriteLine("Candidato adicionado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao adicionar candidato: {ex.Message}");
                    }
                }
                else if (op == "2")
                {
                    // ler id e chamar RemoverCandidato
                    Console.Write("Id do candidato a remover: ");
                    if (!int.TryParse(Console.ReadLine(), out int idRemover))
                    {
                        Console.WriteLine("Id inválido.");
                        continue;
                    }

                    try
                    {
                        adminService.RemoverCandidato(eleicaoAtual, idRemover);
                        // também remover da lista global se existir
                        var global = listaCandidatos.ObterCandidatos().FirstOrDefault(x => x.Id == idRemover);
                        if (global != null)
                        {
                            listaCandidatos.ObterCandidatos().Remove(global);
                        }
                        Console.WriteLine("Candidato removido com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                }
                else if (op == "3")
                {
                    // iniciar agora por exemplo 1 hora:
                    adminService.IniciarVotacaoAgora(eleicaoAtual, TimeSpan.FromHours(1));
                    Console.WriteLine("Votação iniciada por 1 hora.");
                    break; // libera o menu de votações
                }
                else if (op == "4")
                {
                    break;
                }
            }
        }
    }
}
