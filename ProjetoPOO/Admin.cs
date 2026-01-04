using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public class Admin : IAutenticar
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        private string senhaHash;

        public Admin(int id, string nome, string senha)
        {
            ID = id;
            Nome = nome;
            senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
        }
        public bool Autenticar(string usuario, string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
        }
    }
}
