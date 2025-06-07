using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase
    {
        private string formatoColunasTabela = "{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-20} | {5,-10}";

        public Amigo amigo;
        public Revista revista;

        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;

        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo) : base("Empréstimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de Empréstimos");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Registrar Empréstimo");
            Console.WriteLine("2 - Visualizar Empréstimos");
            Console.WriteLine("3 - Registrar Devolução");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        protected override Emprestimo ObterDados()
        {
            int idAmigo = telaAmigo.ObterID();
            amigo = (Amigo)repositorioAmigo.BuscarRegistroPorID(idAmigo);
            int idRevista = telaRevista.ObterID();
            revista = (Revista)repositorioRevista.BuscarRegistroPorID(idRevista);
            Console.Write("Data de empréstimo: ");
            DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());
            DateTime dataDevolucao = dataEmprestimo.AddDays(revista.caixa.diasEmprestimo);

            Emprestimo emprestimo = new Emprestimo(amigo, revista, dataEmprestimo, dataDevolucao);

            return emprestimo;
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine(formatoColunasTabela,
               "ID", "Amigo", "Revista", "Data de Empréstimo", "Data de Devolução", "Status");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Emprestimo e = (Emprestimo)registro;            

            if (e.EstaAtrasado())
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(formatoColunasTabela,
                e.id, e.amigo.nome, e.revista.titulo,
                e.dataEmprestimo.ToShortDateString(),
                e.dataDevolucao.ToShortDateString(), e.status);

            Console.ResetColor();
        }        

        public void RegistrarDevolucao()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Registro de Devolução");
            Console.WriteLine("------------------------");

            int idEmprestimo = ObterID();
            Emprestimo emprestimo = (Emprestimo)repositorioEmprestimo.BuscarRegistroPorID(idEmprestimo);
            repositorioEmprestimo.RegistrarDevolucao(emprestimo);
        }        

        public int ObterID()
        {
            Console.Write($"IDEmpréstimo: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorioEmprestimo.IDExiste(id))
                return id;
            else
            {
                Console.WriteLine();
                Console.Write("ID não localizado! Pressione ENTER para tentar novamente...");
                Console.WriteLine();
                Console.ReadLine();
                return ObterID();
            }
        }

        protected override bool TemRestricaoDeExclusao(EntidadeBase registro)
        {
            return false;
        }
    }
}
