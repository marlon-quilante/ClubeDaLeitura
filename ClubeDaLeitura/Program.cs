using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                telaPrincipal.OpcaoDoMenu();

                TelaBase telaEscolhida = telaPrincipal.EscolherTela();

                if (telaEscolhida == null)
                    break;

                int opcaoEscolhida = telaEscolhida.OpcaoDoMenu();

                switch (opcaoEscolhida)
                {
                    case 1:
                        telaEscolhida.Cadastro();
                        break;
                    case 2:
                        telaEscolhida.Visualizar();
                        break;
                    case 3:
                        telaEscolhida.Editar();
                        break;
                    case 4:
                        telaEscolhida.Deletar();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
