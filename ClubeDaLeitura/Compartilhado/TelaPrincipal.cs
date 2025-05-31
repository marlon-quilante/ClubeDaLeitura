using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.Compartilhado
{
    public class TelaPrincipal
    {
        private int opcaoTelaEscolhida;

        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        private RepositorioCaixa repositorioCaixa;
        private TelaCaixa telaCaixa;

        private RepositorioRevista repositorioRevista;
        private TelaRevista telaRevista;

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            telaAmigo = new TelaAmigo(repositorioAmigo);

            repositorioCaixa = new RepositorioCaixa();
            telaCaixa = new TelaCaixa(repositorioCaixa);

            repositorioRevista = new RepositorioRevista();
            telaRevista = new TelaRevista(repositorioRevista);

            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.telaCaixa = telaCaixa;
        }

        public void OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("Clube de Leitura");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Amigos");
            Console.WriteLine("2 - Caixas");
            Console.WriteLine("3 - Revistas");
            Console.WriteLine("4 - Empréstimos");
            Console.WriteLine("5 - Sair");
            Console.WriteLine();

            opcaoTelaEscolhida = int.Parse(Console.ReadLine());
        }

        public TelaBase EscolherTela()
        {
            if (opcaoTelaEscolhida == 1)
                return telaAmigo;
            else if (opcaoTelaEscolhida == 2)
                return telaCaixa;
            else if (opcaoTelaEscolhida == 3)
                return telaRevista;
            else if (opcaoTelaEscolhida == 4)
                return null;
            else
                return null;
        }
    }
}
