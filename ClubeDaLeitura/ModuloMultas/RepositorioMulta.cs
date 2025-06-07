using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloMultas
{
    public class RepositorioMulta : RepositorioBase
    {
        public override void CadastrarRegistro(EntidadeBase registro)
        {
            base.CadastrarRegistro(registro);

            Multa multa = (Multa)registro;
            multa.emprestimo.amigo.temMulta = true;
            multa.emprestimo.amigo.temMulta = true;
            multa.emprestimo.multa = multa;
        }

        public void QuitarMulta(Multa multa)
        {
            multa.status = "Quitada";
            multa.emprestimo.amigo.temMulta = false;
        }
    }
}
