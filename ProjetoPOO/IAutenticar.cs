using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    public interface IAutenticar
    {
        bool Autenticar(string usuario, string senha);
    }
}
