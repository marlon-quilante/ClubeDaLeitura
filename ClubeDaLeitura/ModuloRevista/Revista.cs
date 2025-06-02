using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public string titulo;
        public int numeroEdicao;
        public DateTime anoPublicacao;
        public string status = "Disponível";
        public Caixa caixa;

        public Revista(string titulo, int numeroEdicao, DateTime anoPublicacao, Caixa caixa)
        {
            this.titulo = titulo;
            this.numeroEdicao = numeroEdicao;
            this.anoPublicacao = anoPublicacao;
            this.caixa = caixa;
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (titulo.Length < 2 || titulo.Length > 100 || string.IsNullOrWhiteSpace(titulo))
                erros += "O título da revista precisa conter de 2 a 100 carateres!\n";
            if (!int.IsPositive(numeroEdicao))
                erros += "O número da edição precisa ser positivo!\n";
            if (!int.IsPositive(anoPublicacao.Year))
                erros += "O ano de publicação não é válido!\n";
            if (RegistroExiste(registro, repositorio))
                erros += "Este título ou número de edição já estão cadastrados!\n";

            return erros;
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            Revista registroRevista = (Revista)registro;
            RepositorioRevista repositorioRevista = (RepositorioRevista)repositorio;

            foreach (Revista revista in repositorioRevista.listaRegistros)
            {
                if (revista.titulo == registroRevista.titulo || revista.numeroEdicao == registroRevista.numeroEdicao)
                    return true;
            }
            return false;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
            Revista registroRevista = (Revista)registroAtualizado;

            titulo = registroRevista.titulo;
            numeroEdicao = registroRevista.numeroEdicao;
            anoPublicacao = registroRevista.anoPublicacao;
        }
    }
}
