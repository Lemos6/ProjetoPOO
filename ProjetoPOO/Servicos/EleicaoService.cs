using ProjetoPOO;

namespace ProjetoPOO.Servicos
{
    public class EleicaoService
    {
        public Eleicao CriarEleicao()
        {
            var menu = new EleicaoMenu();
            return menu.criarEleicao();
        }
    }
}