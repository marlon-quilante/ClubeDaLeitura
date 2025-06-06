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
        public Multa multa;
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
                erros += "A revista é obrigatória!\n";
            if (dataEmprestimo == DateTime.MinValue)
                erros += "A data do empréstimo é obrigatória!\n";
            if (amigo.temEmprestimoAtivo == true)
                erros += "Este amigo possui um empréstimo em aberto!\n";
            if (amigo.temMulta == true)
                erros += "Este amigo possui multa pendente\n";
            if (revista.status != "Disponível")
                erros += "Esta revista não está disponível\n";

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
