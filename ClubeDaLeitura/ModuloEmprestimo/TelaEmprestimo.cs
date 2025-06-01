using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        private int idContador = 1;

        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;

        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
        }

        public int OpcaoDoMenu()
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

        protected Emprestimo ObterDados()
        {
            int IDAmigo = telaAmigo.ObterID();
            Amigo amigo = (Amigo)repositorioAmigo.BuscarRegistroPorID(IDAmigo);

            int IDRevista = telaRevista.ObterID();
            Revista revista = (Revista)repositorioRevista.BuscarRegistroPorID(IDRevista);

            DateTime dataEmprestimo = DateTime.Now;
            DateTime dataDevolucao = dataEmprestimo.AddDays(revista.caixa.diasEmprestimo);

            Emprestimo emprestimo = new Emprestimo(amigo, revista, dataEmprestimo, dataDevolucao);

            return emprestimo;
        }

        public void Registro()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Registro de Empréstimo");
            Console.WriteLine("------------------------");

            Emprestimo novoEmprestimo = ObterDados();
            novoEmprestimo.id = idContador;
            Console.WriteLine();
            Console.WriteLine("Registro realizado com sucesso!");
            Console.ReadLine();
            idContador++;
            repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);
        }

        public void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Empréstimos Realizados");
            Console.WriteLine("------------------------");

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-15} | {4,-15} | {5,-10}",
                "ID", "Amigo", "Revista", "Data de Empréstimo", "Data de Devolução", "Status");

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-15} | {4,-10} | {5,-10}",
                    emprestimo.id, emprestimo.amigo.nome, emprestimo.revista.titulo, emprestimo.dataEmprestimo.ToShortDateString(), emprestimo.dataDevolucao.ToShortDateString(), emprestimo.status);
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
