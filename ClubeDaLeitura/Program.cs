using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloMultas;
using ClubeDaLeitura.ModuloReserva;

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

                if (telaEscolhida == telaPrincipal.telaAmigo)
                    ControleDeAmigos(telaPrincipal, telaEscolhida);
                if (telaEscolhida == telaPrincipal.telaCaixa || telaEscolhida == telaPrincipal.telaRevista)
                    ControleGenerico(telaPrincipal, telaEscolhida);
                else if (telaEscolhida == telaPrincipal.telaEmprestimo)
                    ControleDeEmprestimos(telaPrincipal, telaEscolhida);
                else if (telaEscolhida == telaPrincipal.telaMulta)
                    ControleDeMultas(telaPrincipal, telaEscolhida);
                else if (telaEscolhida == telaPrincipal.telaReserva)
                    ControleDeReservas(telaPrincipal, telaEscolhida);
            }
        }

        static void ControleDeAmigos(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
            int opcaoEscolhida = telaEscolhida.OpcaoDoMenu();

            switch (opcaoEscolhida)
            {
                case 1:
                    telaEscolhida.Cadastrar();
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
                case 6:
                    telaPrincipal.telaAmigo.VisualizarMultas();
                    break;
                case 7:
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
                    telaEscolhida.Cadastrar();
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
                    break;
                default:
                    break;
            }
        }

        static void ControleDeEmprestimos(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
            int opcaoEscolhida = telaEscolhida.OpcaoDoMenu();

            TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaEscolhida;

            switch (opcaoEscolhida)
            {
                case 1:
                    telaEscolhida.Cadastrar();
                    break;
                case 2:
                    telaEscolhida.Visualizar();
                    break;
                case 3:
                    telaEmprestimo.RegistrarDevolucao();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        static void ControleDeMultas(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
            int opcaoEscolhida = telaEscolhida.OpcaoDoMenu();

            TelaMulta telaMulta = (TelaMulta)telaEscolhida;

            switch (opcaoEscolhida)
            {
                case 1:
                    telaMulta.GerarMulta();
                    break;
                case 2:
                    telaEscolhida.Visualizar();
                    break;
                case 3:
                    telaMulta.QuitarMulta();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private static void ControleDeReservas(TelaPrincipal telaPrincipal, TelaBase telaEscolhida)
        {
            int opcaoEscolhida = telaEscolhida.OpcaoDoMenu();

            TelaReserva telaReserva = (TelaReserva)telaEscolhida;

            switch (opcaoEscolhida)
            {
                case 1:
                    telaEscolhida.Cadastrar();
                    break;
                case 2:
                    telaEscolhida.Visualizar();
                    break;
                case 3:
                    telaReserva.Cancelar();
                    break;
                case 4:
                    telaReserva.RetirarRevista();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}
