using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloMultas;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class TelaAmigo : TelaBase
    {
        private RepositorioAmigo repositorioAmigo;
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioMulta RepositorioMulta;

        public TelaAmigo(RepositorioAmigo repositorioAmigo) : base("Amigo", repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de Amigos");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine("5 - Visualizar Empréstimos");
            Console.WriteLine("6 - Visualizar Multas");
            Console.WriteLine("7 - Voltar");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Nome do amigo: ");
            string nomeAmigo = Console.ReadLine();
            Console.Write("Nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

            return amigo;
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Empréstimos do Amigo");
            Console.WriteLine("------------------------");

            int idAmigo = ObterID();

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4, -15}",
                "ID", "Revista", "Data de Empréstimo", "Data de Devolução", "Status");

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (idAmigo == emprestimo.amigo.id)
                {
                    if (emprestimo.EstaAtrasado())
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4, -15}",
                        emprestimo.id, emprestimo.revista.titulo, emprestimo.dataEmprestimo.ToShortDateString(),
                        emprestimo.dataDevolucao.ToShortDateString(),
                        emprestimo.status);
                }
                Console.ResetColor();
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public void VisualizarMultas()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Multas do Amigo");
            Console.WriteLine("------------------------");

            int idAmigo = ObterID();

            Console.WriteLine();
            Console.WriteLine("{0,-8} | {1,-15} | {2,-18} | {3,-18} | {4,-10} | {5,-10} | {6,-10}",
                "ID Multa", "ID Empréstimo", "Data de Empréstimo", "Data De Devolução", "Data Atual", "Valor", "Status");

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (idAmigo == emprestimo.amigo.id && emprestimo.amigo.temMulta == true)
                    Console.WriteLine("{0,-8} | {1,-15} | {2,-18} | {3,-18} | {4,-10} | {5,-10} | {6,-10}",
                emprestimo.multa.id, emprestimo.multa.emprestimo.id, emprestimo.dataEmprestimo.ToShortDateString(),
                emprestimo.dataDevolucao.ToShortDateString(), DateTime.Now.ToShortDateString(),
                $"R$ {emprestimo.multa.valor.ToString("F2")}", emprestimo.multa.status);
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        protected override bool TemRestricaoDeExclusao(EntidadeBase registro)
        {
            Amigo amigo = (Amigo)registro;

            if (amigo.temEmprestimoAtivo == true)
                return true;

            return false;
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                "ID", "Nome", "Responsável", "Telefone");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Amigo amigo = (Amigo)registro;

            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.telefone);
        }
    }
}
