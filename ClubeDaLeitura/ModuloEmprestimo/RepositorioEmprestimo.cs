using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        public void CadastrarRegistro(Emprestimo emprestimo)
        {
            listaEmprestimos.Add(emprestimo);
        }

        public bool IDExiste(int idEmprestimo)
        {
            foreach (Emprestimo emprestimo in listaEmprestimos)
            {
                if (idEmprestimo == emprestimo.id)
                    return true;
            }
            return false;
        }

        public Emprestimo BuscarRegistroPorID(int idEmprestimo)
        {
            foreach (Emprestimo emprestimo in listaEmprestimos)
            {
                if (idEmprestimo == emprestimo.id)
                    return emprestimo;
            }
            return null;
        }
    }
}
