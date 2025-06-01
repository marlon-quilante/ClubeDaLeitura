using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase
    {
        public RepositorioRevista repositorioRevista;

        public bool CaixaTemRevista(int idCaixa)
        {
            foreach (Revista revista in repositorioRevista.listaRegistros)
            {
                if (idCaixa == revista.caixa.id)
                    return true;
            }
            return false;
        }
    }
}
