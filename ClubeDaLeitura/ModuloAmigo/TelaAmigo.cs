using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloAmigo
{
    public class TelaAmigo : TelaBase
    {
        private RepositorioAmigo repositorioAmigo;
        public RepositorioEmprestimo repositorioEmprestimo;

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
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                "ID", "Revista", "Data de Empréstimo", "Data de Devolução");

            foreach (Emprestimo emprestimo in repositorioEmprestimo.listaRegistros)
            {
                if (idAmigo == emprestimo.amigo.id)
                    Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                    emprestimo.id, emprestimo.revista.titulo, emprestimo.dataEmprestimo.ToShortDateString(), emprestimo.dataDevolucao.ToShortDateString());
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        protected override bool TemRestricao(EntidadeBase registro)
        {
            Amigo amigo = (Amigo)registro;

            return repositorioAmigo.AmigoTemEmprestimoAtivo(amigo.id);
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
