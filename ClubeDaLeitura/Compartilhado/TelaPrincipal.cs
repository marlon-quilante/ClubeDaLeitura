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

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            telaAmigo = new TelaAmigo();

            telaAmigo.repositorio = repositorioAmigo;
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
                return null;
            else if (opcaoTelaEscolhida == 3)
                return null;
            else if (opcaoTelaEscolhida == 4)
                return null;
            else
                return null;
        }
    }
}
