using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloMultas
{
    public class TelaMultas : TelaBase
    {
        private RepositorioMultas repositorioMultas;

        public TelaMultas(RepositorioMultas repositorioMultas) : base("Multas", repositorioMultas)
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
            Console.WriteLine("1 - Visulizar");
            Console.WriteLine("2 - Quitar");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-10} | {5,-10}",
                "ID", "Data de Empréstimo", "Data De Devolução", "Data Atual", "Valor", "Status");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Multas multas = (Multas)registro;

            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-10}",
                multas.id, multas.emprestimo.dataEmprestimo, multas.emprestimo.dataDevolucao, 
                DateTime.Now.ToShortDateString(), multas.valor, multas.status);
        }

        public void Quitar()
        {
            int idMultas = ObterID();
            Multas multas = (Multas)repositorioMultas.BuscarRegistroPorID(idMultas);

            multas.status = "Quitada";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Multa quitada com sucesso!");
            Console.ResetColor();
        }

        protected override EntidadeBase ObterDados()
        {
            throw new NotImplementedException();
        }

        protected override bool TemRestricao(EntidadeBase registro)
        {
            return false;
        }
    }
}
