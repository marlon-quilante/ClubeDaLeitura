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
            Console.WriteLine("5 - Voltar");
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

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-25}",
                "ID", "Etiqueta", "Cor", "Dias de Empréstimo");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Caixa caixa = (Caixa)registro;

            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-25}",
                                caixa.id, caixa.etiqueta, caixa.cor, caixa.diasEmprestimo);
        }

        protected override bool TemRestricaoDeExclusao(EntidadeBase registro)
        {
            Caixa caixa = (Caixa)registro;

            return repositorioCaixa.CaixaTemRevista(caixa.id);
        }
    }
}
