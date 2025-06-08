using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public bool temMulta = false;
        public bool temEmprestimoAtivo = false;

        public Amigo(string nome, string nomeResponsavel, string telefone)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (nome.Length < 3 || nome.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do amigo precisa conter de 3 a 100 carateres!\n";
            if (nomeResponsavel.Length < 3 || nomeResponsavel.Length > 100 || string.IsNullOrWhiteSpace(nome))
                erros += "O nome do responsável precisa conter de 3 a 100 carateres!\n";
            if (!TelefoneValido(telefone))
                erros += "O telefone digitado não é válido!\n";
            if (RegistroExiste(registro, repositorio))
                erros += "Este nome ou telefone já estão cadastrados!\n";

            return erros;
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            Amigo registroAmigo = (Amigo)registro;
            RepositorioAmigo repositorioAmigo = (RepositorioAmigo)repositorio;

            foreach (Amigo amigo in repositorioAmigo.listaRegistros)
            {
                if ((amigo.nome == registroAmigo.nome || amigo.telefone == registroAmigo.telefone) && registroAmigo.id != amigo.id)
                    return true;
            }
            return false;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            nome = amigoAtualizado.nome;
            nomeResponsavel = amigoAtualizado.nomeResponsavel;
            telefone = amigoAtualizado.telefone;
        }

        public bool TelefoneValido(string telefone)
        {
            if (telefone.Length < 14 || telefone.Length > 15 || telefone[0] != '(' ||
                telefone[3] != ')' || (!telefone.Substring(5, 6).Contains('-')) || telefone[4] != ' ')
                return false;

            return true;
        }
    }
}
