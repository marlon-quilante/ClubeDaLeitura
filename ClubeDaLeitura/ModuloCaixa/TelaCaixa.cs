using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class TelaCaixa : TelaBase
    {
        private RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorioCaixa) : base ("Caixa", repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de Caixas");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Etiqueta: ");
            string etiqueta = Console.ReadLine();
            Console.Write("Cor: ");
            string cor = Console.ReadLine();
            Console.Write("Dias de Empréstimo: ");
            int diasEmprestimo = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo);

            return caixa;
        }

        public override void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Caixas Cadastrados");
            Console.WriteLine("------------------------");

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-25}",
                "ID", "Etiqueta", "Cor", "Dias de Empréstimo");

            foreach (Caixa caixa in repositorioCaixa.listaRegistros)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-25}",
                    caixa.id, caixa.etiqueta, caixa.cor, caixa.diasEmprestimo);
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public override void Deletar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Exclusão de Caixa");
            Console.WriteLine("------------------------");

            int id = ObterID();
            Console.WriteLine();
            if (repositorioCaixa.IDExiste(id))
            {
                if (!repositorioCaixa.CaixaTemRevista(id))
                {
                    repositorioCaixa.DeletarRegistro(id);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exclusão realizada com sucesso!");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Não é possível excluir esta caixa pois ela possui revistas vinculadas! Pressione ENTER para voltar...");
                    Console.ReadLine();
                    return;
                }
            }
        }
    }
}
