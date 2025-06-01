using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo
    {
        public int id;
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string status = "Aberto";

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
        }
    }
}
