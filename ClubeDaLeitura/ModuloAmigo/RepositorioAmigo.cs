using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {
        public RepositorioEmprestimo repositorioEmprestimo;

        public bool AmigoTemEmprestimo(int idAmigo)
        {
            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaEmprestimos)
            {
                if (idAmigo == emprestimo.amigo.id)
                    return true;
            }
            return false;
        }
    }
}
