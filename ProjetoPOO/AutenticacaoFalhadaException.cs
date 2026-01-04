using System;

namespace ProjetoPOO
{
    public class AutenticacaoFalhadaException : Exception
    {
        public AutenticacaoFalhadaException()
            : base("Falha na autenticação do administrador.") { }
    }
}