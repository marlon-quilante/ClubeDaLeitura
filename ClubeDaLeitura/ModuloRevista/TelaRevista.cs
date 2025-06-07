using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.ModuloRevista
{
    public class TelaRevista : TelaBase
    {
        private RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista) : base ("Revista", repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de {entidade}s");
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
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Número da Edição: ");
            int numeroEdicao = int.Parse(Console.ReadLine());
            Console.Write("Ano de publicação: ");
            DateTime anoPublicacao = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
            int IDCaixa = telaCaixa.ObterID();
            
            Caixa caixa = (Caixa)repositorioCaixa.BuscarRegistroPorID(IDCaixa);

            Revista revista = new Revista(titulo, numeroEdicao, anoPublicacao, caixa);

            return revista;
        }

        protected override bool TemRestricaoDeExclusao(EntidadeBase registro)
        {
            return false;
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-25} | {4,-20} | {5,-10}",
                "ID", "Título", "Número da Edição", "Ano da Publicação", "Caixa", "Status");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Revista revista = (Revista)registro;

            Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-25} | {4,-20} | {5,-10}",
                    revista.id, revista.titulo, revista.numeroEdicao, revista.anoPublicacao.Year, revista.caixa.etiqueta, revista.status);
        }
    }
}
