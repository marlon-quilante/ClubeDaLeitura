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
        public TelaAmigo telaAmigo;

        private RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;

        private RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;

        private RepositorioEmprestimo repositorioEmprestimo;
        public TelaEmprestimo telaEmprestimo;

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            telaAmigo = new TelaAmigo(repositorioAmigo);

            repositorioCaixa = new RepositorioCaixa();
            telaCaixa = new TelaCaixa(repositorioCaixa);

            repositorioRevista = new RepositorioRevista();
            telaRevista = new TelaRevista(repositorioRevista);

            repositorioEmprestimo = new RepositorioEmprestimo();
            telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo);

            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.telaCaixa = telaCaixa;

            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.telaRevista = telaRevista;

            repositorioAmigo.repositorioEmprestimo = repositorioEmprestimo;
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
            else
                return null;
        }

        public TelaEmprestimo EscolherEmprestimo()
        {
            if (opcaoTelaEscolhida == 4)
                return telaEmprestimo;
            else
                return null;
        }
    }
}
