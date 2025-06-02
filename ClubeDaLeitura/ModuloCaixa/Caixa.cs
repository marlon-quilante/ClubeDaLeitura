using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
        public string etiqueta;
        public string cor;
        public int diasEmprestimo = 7;

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            this.etiqueta = etiqueta;
            this.cor = cor;
            this.diasEmprestimo = diasEmprestimo;
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (etiqueta.Length < 3 || etiqueta.Length > 50 || string.IsNullOrWhiteSpace(etiqueta))
                erros += "A etiqueta precisa conter de 3 a 50 carateres!\n";
            if (RegistroExiste(registro, repositorio))
                erros += "Esta etiqueta já está cadastrada!\n";

            return erros;
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            Caixa registroCaixa = (Caixa)registro;
            RepositorioCaixa repositorioCaixa = (RepositorioCaixa)repositorio;

            foreach (Caixa caixa in repositorioCaixa.listaRegistros)
            {
                if (caixa.etiqueta == registroCaixa.etiqueta)
                    return true;
            }
            return false;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
            Caixa caixaAtualizada = (Caixa)registroAtualizado;

            etiqueta = caixaAtualizada.etiqueta;
            cor = caixaAtualizada.cor;
            diasEmprestimo = caixaAtualizada.diasEmprestimo;
        }
    }
}
