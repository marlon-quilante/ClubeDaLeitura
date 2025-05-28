using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class Amigo : EntidadeBase
    {
        public string nome;
        public string nomeResponsavel;
        public string telefone;

        public string Validacao()
        {
            string erros = "";

            if (nome.Length < 3 || nome.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do amigo precisa conter mais de 1 caractere!\n";
            if (nomeResponsavel.Length < 3 || nomeResponsavel.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do responsável precisa conter mais de 1 caractere!\n";
            if (!TelefoneValido(telefone))
                erros += "O telefone digitado não é válido!";

            return erros;
        }
    }
}
