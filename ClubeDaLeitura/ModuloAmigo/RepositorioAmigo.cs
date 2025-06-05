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

        public bool AmigoTemMultaPendente(int idAmigo)
        {
            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (idAmigo == emprestimo.amigo.id && emprestimo.temMulta == true)
                    if (emprestimo.multa.status == "Pendente")
                        return true;
            }
            return false;
        }
    }
}
