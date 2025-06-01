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

        public override void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Amigos Cadastrados");
            Console.WriteLine("------------------------");

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                "ID", "Nome", "Responsável", "Telefone");

            foreach (Amigo amigo in repositorioAmigo.listaRegistros)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                    amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.telefone);
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
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

        public override void Deletar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Exclusão de Amigo");
            Console.WriteLine("------------------------");

            int id = ObterID();
            Console.WriteLine();
            if (repositorioAmigo.IDExiste(id))
            {
                if (!repositorioAmigo.AmigoTemEmprestimo(id))
                    repositorioAmigo.DeletarRegistro(id);
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Não é possível excluir este amigo pois ele possui empréstimo realizado! Pressione ENTER para voltar...");
                    Console.ReadLine();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Amigo não encontrado por esse ID! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Deletar();
                return;
            }
        }
    }
}
