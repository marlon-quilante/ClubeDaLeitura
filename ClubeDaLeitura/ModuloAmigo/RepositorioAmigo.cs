using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase
    {
        public RepositorioEmprestimo repositorioEmprestimo;

        public bool AmigoTemEmprestimoAtivo(int idAmigo)
        {
            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaEmprestimos)
            {
                if (idAmigo == emprestimo.amigo.id && emprestimo.status == "Aberto")
                    return true;
            }
            return false;
        }
    }
}
