using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class Emprestimo : EntidadeBase
    {
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo = DateTime.Now;
        public DateTime dataDevolucao;
        public string status;

        public override string Validacao()
        {
            return "";
        }
    }
}
