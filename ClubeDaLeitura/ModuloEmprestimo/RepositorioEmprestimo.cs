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

        public void RegistrarDevolucao(Emprestimo emprestimo)
        {
            emprestimo.status = "Concluído";
            emprestimo.revista.status = "Disponível";
        }
    }
}
