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

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            return "";
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            throw new NotImplementedException();
        }
    }
}
