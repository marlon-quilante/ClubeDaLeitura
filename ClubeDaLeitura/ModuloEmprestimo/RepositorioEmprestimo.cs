using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public List<Emprestimo> listaRegistros = new List<Emprestimo>();

        public void CadastrarRegistro(Emprestimo emprestimo)
        {
            listaRegistros.Add(emprestimo);
        }
    }
}
