using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        protected string nome;
        protected string nomeResponsavel;
        protected string telefone;

        public Amigo(string nome, string nomeResponsavel, string telefone)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
        }

        public override string Validacao()
        {
            string erros = "";

            if (nome.Length < 3 || nome.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do amigo precisa conter de 3 a 100 carateres!\n";
            if (nomeResponsavel.Length < 3 || nomeResponsavel.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do responsável precisa conter de 3 a 100 carateres!\n";
            if (!TelefoneValido(telefone))
                erros += "O telefone digitado não é válido!";

            return erros;
        }
    }
}
