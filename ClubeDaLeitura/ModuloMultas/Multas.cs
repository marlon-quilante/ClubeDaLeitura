using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloMultas
{
    public class Multas : EntidadeBase
    {
        public int valor;
        public string status = "Pendente";
        public Emprestimo emprestimo;

        public Multas(int valor, string status, Emprestimo emprestimo)
        {
            this.valor = valor;
            this.status = status;
            this.emprestimo = emprestimo;
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            throw new NotImplementedException();
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            throw new NotImplementedException();
        }
    }
}
