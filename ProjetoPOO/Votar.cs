using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    // Herda apenas de Candidato; usa composição para acessar CandidatosLista
    internal class Votar : Eleitor // Corrigir para herdar de Eleitor, se necessário
    {
        private readonly EleitoresLista _listaEleitores;

        // Construtor padrão cria uma lista nova
        public Votar() : this(new EleitoresLista())
        {
        }

        // Construtor que aceita a lista (injeção de dependência)
        public Votar(EleitoresLista lista)
        {
            _listaEleitores = lista ?? throw new ArgumentNullException(nameof(lista));

            Console.WriteLine("Digite o seu numero de identificação");
            Id = Console.ReadLine();
            Console.WriteLine("Digite o seu Nome");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite a sua Idade");
            Idade = int.Parse(Console.ReadLine() ?? "0");


            // Corrigir: Votar precisa ser do tipo Eleitor para ser adicionado à lista
            // Solução: Criar um objeto Eleitor e adicionar à lista
            var eleitor = new Eleitor
            {
                Id = this.Id,
                Nome = this.Nome,
                Idade = this.Idade,
                // Adicione outras propriedades necessárias aqui
            };
            if (!eleitor.ElegivelParaVotar)
            {
                Console.WriteLine("Não tens idade para votar ou já votaste.");
                return;
            }
            _listaEleitores.AdicionarEleitor(eleitor);
        }

        // Método de conveniência para acessar os candidatos da lista
        public List<Candidato> ObterCandidatos()
        {
            Console.WriteLine("Escolha o número do candidato para votar:");

            var candidatosLista = new CandidatosLista();
            var candidatos = candidatosLista.ObterCandidatos();

            // Escreve cada candidato prefixado por um número começando em 1
            for (int i = 0; i < candidatos.Count; i++)
            {
                var c = candidatos[i];
                Console.WriteLine("{0}. {1} (Id: {2}, Idade: {3})", i + 1, c.Nome, c.Id, c.idade);
            }

            return candidatos;
        }
        
    }
}
