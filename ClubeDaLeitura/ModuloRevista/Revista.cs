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

        public override string Validacao()
        {
            string erros = "";

            if (titulo.Length < 2 || titulo.Length > 100 || string.IsNullOrWhiteSpace(titulo))
                erros += "O título da revista precisa conter de 2 a 100 carateres!\n";
            if (numeroEdicao < 0)
                erros += "O número da edição precisa ser positivo!\n";

            return erros;
        }
    }
}
