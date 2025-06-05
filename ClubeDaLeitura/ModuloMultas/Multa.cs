using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloMultas
{
    public class Multa : EntidadeBase
    {
        public double valor;
        public string status = "Pendente";
        public Emprestimo emprestimo;

        public Multa(double valor, string status, Emprestimo emprestimo)
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
