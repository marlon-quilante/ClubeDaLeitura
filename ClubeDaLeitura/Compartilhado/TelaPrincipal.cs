using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloMultas;
using ClubeDaLeitura.ModuloReserva;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.Compartilhado
{
    public class TelaPrincipal
    {
        private int opcaoTelaEscolhida;

        public RepositorioAmigo repositorioAmigo;
        public TelaAmigo telaAmigo;

        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;

        public RepositorioRevista repositorioRevista;
        public TelaRevista telaRevista;

        public RepositorioEmprestimo repositorioEmprestimo;
        public TelaEmprestimo telaEmprestimo;

        public RepositorioMulta repositorioMultas;
        public TelaMulta telaMulta;

        public RepositorioReserva repositorioReserva;
        public TelaReserva telaReserva;

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

            repositorioMultas = new RepositorioMulta();
            telaMulta = new TelaMulta(repositorioMultas);

            repositorioReserva = new RepositorioReserva();
            telaReserva = new TelaReserva(repositorioReserva);

            telaAmigo.repositorioEmprestimo = repositorioEmprestimo;

            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.telaCaixa = telaCaixa;

            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.telaRevista = telaRevista;

            telaMulta.repositorioEmprestimo = repositorioEmprestimo;

            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioEmprestimo = repositorioEmprestimo;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.telaRevista = telaRevista;

            repositorioCaixa.repositorioRevista = repositorioRevista;
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
            Console.WriteLine("5 - Multas");
            Console.WriteLine("6 - Reservas");
            Console.WriteLine("7 - Sair");
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
                return telaEmprestimo;
            else if (opcaoTelaEscolhida == 5)
                return telaMulta;
            else if (opcaoTelaEscolhida == 6)
                return telaReserva;
            else
                return null;
        }
    }
}
