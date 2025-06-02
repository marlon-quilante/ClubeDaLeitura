using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

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
                TelaEmprestimo telaEmprestimo = telaPrincipal.EscolherEmprestimo();

                if (telaEscolhida == null && telaEmprestimo == null)
                    break;

                if (telaEscolhida == telaPrincipal.telaAmigo)
                {
                    ControleDeAmigos(telaPrincipal, telaEscolhida);
                }

                if (telaEscolhida == telaPrincipal.telaCaixa 
                    || telaEscolhida == telaPrincipal.telaRevista)
                {
                    ControleGenerico(telaPrincipal, telaEscolhida);
                }

                else if (telaEmprestimo == telaPrincipal.telaEmprestimo)
                {
                    ControleDeEmprestimos(telaPrincipal, telaEmprestimo);
                }
            }
        }

        static void ControleDeAmigos(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
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
                case 5:
                    telaPrincipal.telaAmigo.VisualizarEmprestimos();
                    break;
                default:
                    break;
            }
        }

        static void ControleGenerico(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
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

        static void ControleDeEmprestimos(TelaPrincipal telaPrincipal, TelaEmprestimo telaEmprestimo)
        {
            int opcaoEscolhida = telaEmprestimo.OpcaoDoMenu();

            switch (opcaoEscolhida)
            {
                case 1:
                    telaEmprestimo.RegistroDeEmprestimo();
                    break;
                case 2:
                    telaEmprestimo.Visualizar();
                    break;
                case 3:
                    telaEmprestimo.RegistroDeDevolucao();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}
