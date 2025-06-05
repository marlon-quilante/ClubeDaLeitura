using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloMultas;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
    {
        
        public Amigo amigo;
        public Revista revista;
        public Multa multas;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string status = "Aberto";
        public bool temMulta = false;

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;

            if (dataEmprestimo > DateTime.Now)
                revista.status = "Reservada";
            else
                revista.status = "Emprestada";
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {            
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            return false;
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (amigo == null)
                erros += "O amigo é obrigatório!\n";

            if (revista == null)
                erros += "A revista é obrigatório!\n";

            if (dataEmprestimo == DateTime.MinValue)
                erros += "A data do empréstimo é obrigatório!\n";                      

            return erros;
        }

        public bool EstaAtrasado()
        {
            if (dataDevolucao < DateTime.Now && status != "Concluído")
            {
                status = "Atrasado";
                return true;
            }

            return false;
        }
    }
}
