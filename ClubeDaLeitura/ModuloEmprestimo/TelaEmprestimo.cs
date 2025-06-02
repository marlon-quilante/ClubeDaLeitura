using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class TelaEmprestimo
    {
        private int idContador = 1;

        public Amigo amigo;
        public Revista revista;

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
            int idAmigo = telaAmigo.ObterID();

            if (repositorioAmigo.AmigoTemEmprestimo(idAmigo))
            {
                Console.WriteLine();
                Console.WriteLine("Este amigo já possui um empréstimo realizado! Pressione ENTER para tentar novamente...");
                Console.WriteLine();
                return ObterDados();
            }

            amigo = (Amigo)repositorioAmigo.BuscarRegistroPorID(idAmigo);
            
            int idRevista = telaRevista.ObterID();
            revista = (Revista)repositorioRevista.BuscarRegistroPorID(idRevista);

            Console.Write("Data de empréstimo: ");
            DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());
            DateTime dataDevolucao = dataEmprestimo.AddDays(revista.caixa.diasEmprestimo);

            Emprestimo emprestimo = new Emprestimo(amigo, revista, dataEmprestimo, dataDevolucao);

            return emprestimo;
        }

        public void RegistroDeEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Registro de Empréstimo");
            Console.WriteLine("------------------------");

            Emprestimo novoEmprestimo = ObterDados();
            novoEmprestimo.id = idContador;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Registro realizado com sucesso!");
            Console.ResetColor();
            Console.ReadLine();
            idContador++;
            repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);

            if (novoEmprestimo.dataEmprestimo > DateTime.Now)
                novoEmprestimo.revista.status = "Reservada";
            else
                novoEmprestimo.revista.status = "Emprestada";
        }

        public void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Empréstimos Realizados");
            Console.WriteLine("------------------------");

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-20} | {5,-10}",
                "ID", "Amigo", "Revista", "Data de Empréstimo", "Data de Devolução", "Status");

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaEmprestimos)
            {
                if (emprestimo.dataDevolucao < DateTime.Now)
                    emprestimo.status = "Atrasado";

                if (emprestimo.status == "Atrasado")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-20} | {5,-10}",
                                       emprestimo.id, emprestimo.amigo.nome, emprestimo.revista.titulo,
                                       emprestimo.dataEmprestimo.ToShortDateString(),
                                       emprestimo.dataDevolucao.ToShortDateString(), emprestimo.status);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-20} | {5,-10}",
                        emprestimo.id, emprestimo.amigo.nome, emprestimo.revista.titulo,
                        emprestimo.dataEmprestimo.ToShortDateString(),
                        emprestimo.dataDevolucao.ToShortDateString(), emprestimo.status);
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void RegistroDeDevolucao()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Registro de Devolução");
            Console.WriteLine("------------------------");

            int idEmprestimo = ObterID();
            Emprestimo emprestimo = repositorioEmprestimo.BuscarRegistroPorID(idEmprestimo);
            emprestimo.status = "Concluído";
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
    }
}
