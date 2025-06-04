using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {
        public RepositorioEmprestimo repositorioEmprestimo;

        public bool AmigoTemEmprestimoAtivo(int idAmigo)
        {
            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (idAmigo == emprestimo.amigo.id && emprestimo.status != "Concluído")
                    return true;
            }
            return false;
        }
    }
}
