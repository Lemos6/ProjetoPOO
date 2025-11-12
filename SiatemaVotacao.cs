using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPOO
{
    internal class SistemaVotacao
    {
        private readonly CandidatosLista candidatos;
        private readonly EleitoresLista eleitores;
        private readonly Dictionary<int, int> votos; // CandidatoId -> Número de votos

        public SistemaVotacao(CandidatosLista candidatos, EleitoresLista eleitores)
        {
            this.candidatos = candidatos;
            this.eleitores = eleitores;
            this.votos = new Dictionary<int, int>();
        }

        public void ProcessarVotacao()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("            PROCESSO DE VOTAÇÃO");
            Console.WriteLine("==========================================");

            try
            {
                // Passo 1: Identificar o eleitor
                Console.Write("Digite o ID do eleitor (ex: E001): ");
                string eleitorId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(eleitorId))
                {
                    Console.WriteLine("❌ ID não pode estar vazio!");
                    return;
                }

                var eleitor = eleitores.ObterTodos().FirstOrDefault(e => e.Id == eleitorId);

                if (eleitor == null)
                {
                    Console.WriteLine("❌ Eleitor não encontrado!");
                    return;
                }

                Console.WriteLine($"\nEleitor: {eleitor.Nome}");
                Console.WriteLine($"Idade: {eleitor.Idade} anos");

                // Passo 2: Verificar elegibilidade
                if (!eleitor.PodeVotar)
                {
                    Console.WriteLine($"\n❌ {eleitor.Nome} não pode votar!");
                    Console.WriteLine("   Motivo: Menor de 18 anos.");
                    return;
                }

                if (eleitor.JaVotou)
                {
                    Console.WriteLine($"\n❌ {eleitor.Nome} já votou!");
                    Console.WriteLine("   Não é permitido votar mais de uma vez.");
                    return;
                }

                // Passo 3: Mostrar candidatos elegíveis
                var candidatosElegiveis = candidatos.ObterCandidatos()
                    .Where(c => c.ElegivelParaCandidatar())
                    .ToList();

                if (candidatosElegiveis.Count == 0)
                {
                    Console.WriteLine("\n❌ Não há candidatos elegíveis no momento.");
                    return;
                }

                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Candidatos disponíveis:");
                Console.WriteLine("------------------------------------------");

                foreach (var c in candidatosElegiveis)
                {
                    int votosAtuais = votos.ContainsKey(c.Id) ? votos[c.Id] : 0;
                    Console.WriteLine($"ID: {c.Id} - {c.Nome} (Votos: {votosAtuais})");
                }

                // Passo 4: Registrar voto
                Console.Write("\nDigite o ID do candidato em quem deseja votar: ");
                if (!int.TryParse(Console.ReadLine(), out int candidatoId))
                {
                    Console.WriteLine("❌ ID inválido!");
                    return;
                }

                var candidatoEscolhido = candidatosElegiveis.FirstOrDefault(c => c.Id == candidatoId);

                if (candidatoEscolhido == null)
                {
                    Console.WriteLine("❌ Candidato não encontrado ou não elegível!");
                    return;
                }

                // Registrar o voto
                if (!votos.ContainsKey(candidatoId))
                {
                    votos[candidatoId] = 0;
                }
                votos[candidatoId]++;
                eleitor.JaVotou = true;

                Console.WriteLine($"\n✓ Voto registrado com sucesso!");
                Console.WriteLine($"  Eleitor: {eleitor.Nome}");
                Console.WriteLine($"  Votou em: {candidatoEscolhido.Nome}");

                // Mostrar estatísticas
                MostrarEstatisticas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Erro durante a votação: {ex.Message}");
            }
        }

        private void MostrarEstatisticas()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("        ESTATÍSTICAS DA VOTAÇÃO");
            Console.WriteLine("==========================================");

            var todosEleitores = eleitores.ObterTodos();
            int totalEleitores = todosEleitores.Count;
            int eleitoresVotaram = todosEleitores.Count(e => e.JaVotou);
            int eleitoresPendentes = todosEleitores.Count(e => e.ElegivelParaVotar);

            Console.WriteLine($"Total de eleitores: {totalEleitores}");
            Console.WriteLine($"Já votaram: {eleitoresVotaram}");
            Console.WriteLine($"Elegíveis para votar: {eleitoresPendentes}");
            Console.WriteLine($"Total de votos: {votos.Values.Sum()}");

            if (votos.Count > 0)
            {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Votação por candidato:");
                Console.WriteLine("------------------------------------------");

                var resultadosOrdenados = votos.OrderByDescending(v => v.Value);

                foreach (var voto in resultadosOrdenados)
                {
                    var candidato = candidatos.ObterCandidatos()
                        .FirstOrDefault(c => c.Id == voto.Key);

                    if (candidato != null)
                    {
                        double percentual = totalEleitores > 0
                            ? (voto.Value * 100.0 / eleitoresVotaram)
                            : 0;

                        Console.WriteLine($"{candidato.Nome}: {voto.Value} votos ({percentual:F1}%)");
                    }
                }
            }
        }
    }
}
