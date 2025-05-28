using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
        public string etiqueta;
        public string cor;
        public int diasEmprestimo = 7;

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            throw new NotImplementedException();
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (etiqueta.Length < 3 || etiqueta.Length > 50 || string.IsNullOrWhiteSpace(etiqueta))
                erros += "A etiqueta precisa conter de 3 a 50 carateres!\n";

            return erros;
        }
    }
}
