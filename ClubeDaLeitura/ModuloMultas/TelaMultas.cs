using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloMultas
{
    public class TelaMultas : TelaBase
    {
        private RepositorioMultas repositorioMultas;
        public RepositorioEmprestimo repositorioEmprestimo;

        public TelaMultas(RepositorioMultas repositorioMultas) : base("Multa", repositorioMultas)
        {
            this.repositorioMultas = repositorioMultas;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de Multas");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Gerar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Quitar");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        public void GerarMulta()
        {
            Console.Clear();
            Console.WriteLine($"Empréstimos com multa gerada: ");
            Console.WriteLine();

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (DateTime.Now > emprestimo.dataDevolucao && emprestimo.temMulta == false)
                {
                    double valorMultas = (DateTime.Now.Subtract(emprestimo.dataDevolucao).Days) * 2.00;
                    Multa multa = new Multa(valorMultas, "Pendente", emprestimo);
                    emprestimo.temMulta = true;
                    repositorioMultas.CadastrarRegistro(multa);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID do Empréstimo: {emprestimo.id}");
                    Console.ResetColor();
                }
            }
            Console.ReadLine();
        }

        public void QuitarMulta()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Quitação de Multas");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int idMulta = ObterID();
            Multa multa = (Multa)repositorioMultas.BuscarRegistroPorID(idMulta);

            multa.status = "Quitada";
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Multa quitada com sucesso!");
            Console.ReadLine();
            Console.ResetColor();
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0,-8} | {1,-15} | {2,-18} | {3,-18} | {4,-10} | {5,-10} | {6,-10}",
                "ID Multa", "ID Empréstimo", "Data de Empréstimo", "Data De Devolução", "Data Atual", "Valor", "Status");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Multa multas = (Multa)registro;

            Console.WriteLine("{0,-8} | {1,-15} | {2,-18} | {3,-18} | {4,-10} | {5,-10} | {6,-10}",
                multas.id, multas.emprestimo.id, multas.emprestimo.dataEmprestimo.ToShortDateString(), multas.emprestimo.dataDevolucao.ToShortDateString(),
                DateTime.Now.ToShortDateString(), $"R$ {multas.valor.ToString("F2")}", multas.status);
        }

        protected override bool TemRestricao(EntidadeBase registro)
        {
            return false;
        }

        protected override EntidadeBase ObterDados()
        {
            throw new NotImplementedException();
        }
    }
}
