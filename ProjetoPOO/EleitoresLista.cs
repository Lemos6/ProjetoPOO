using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class EleitoresLista
    {
        private List<Eleitor> eleitores;

        public EleitoresLista()
        {
            eleitores = new List<Eleitor>();

            eleitores.Add(new Eleitor { Id = "E001", Nome = "João Silva", Idade = 25, JaVotou = false });
            eleitores.Add(new Eleitor { Id = "E002", Nome = "Maria Oliveira", Idade = 17, JaVotou = false });
            eleitores.Add(new Eleitor { Id = "E003", Nome = "Pedro Santos", Idade = 30, JaVotou = true });
            eleitores.Add(new Eleitor { Id = "E004", Nome = "Ana Costa", Idade = 22, JaVotou = false });
            eleitores.Add(new Eleitor { Id = "E005", Nome = "Lucas Pereira", Idade = 16, JaVotou = false });
        }

        public void AdicionarEleitor(Eleitor eleitor)
        {
            if (eleitor == null) throw new ArgumentNullException(nameof(eleitor));

            if (eleitores.Any(e => e.Id == eleitor.Id))
                throw new InvalidOperationException($"Eleitor com Id '{eleitor.Id}' já existe.");

            eleitores.Add(eleitor);
        }

        // opcional: método para obter todos
        public IReadOnlyList<Eleitor> ObterTodos() => eleitores.AsReadOnly();
    }
}