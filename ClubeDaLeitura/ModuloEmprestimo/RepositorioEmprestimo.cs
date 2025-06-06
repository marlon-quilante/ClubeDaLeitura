using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase
    {
        public override void CadastrarRegistro(EntidadeBase registro)
        {
            base.CadastrarRegistro(registro);

            Emprestimo emprestimo = (Emprestimo)registro;
            emprestimo.amigo.temEmprestimoAtivo = true;
            emprestimo.revista.status = "Emprestada";
        }
    }
}
