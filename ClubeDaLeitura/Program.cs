using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloMultas;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            //telaPrincipal.repositorioAmigo.CadastrarRegistro(new Amigo("João", "José", "(49) 9999-9999"));
            //telaPrincipal.repositorioCaixa.CadastrarRegistro(new Caixa("Caixa1", "Azul", 2));
            //telaPrincipal.repositorioRevista.CadastrarRegistro(new Revista("Revista1", 1234, new DateTime(2020, 1, 1), new Caixa("Caixa1", "Azul", 2)));
            //telaPrincipal.repositorioEmprestimo.CadastrarRegistro
            //    (new Emprestimo(new Amigo("João", "José", "(49) 9999-9999"), 
            //    new Revista("Revista1", 1234, new DateTime(2020, 1, 1), new Caixa("Caixa1", "Azul", 2)),
            //    new DateTime(2025, 05, 04), new DateTime(2025, 05, 06)
            //    ));
            //telaPrincipal.repositorioEmprestimo.CadastrarRegistro
            //    (new Emprestimo(new Amigo("João", "José", "(49) 9999-9999"),
            //    new Revista("Revista1", 1234, new DateTime(2020, 1, 1), new Caixa("Caixa1", "Azul", 2)),
            //    new DateTime(2025, 05, 25), new DateTime(2025, 05, 27)
            //    ));

            while (true)
            {
                telaPrincipal.OpcaoDoMenu();

                TelaBase telaEscolhida = telaPrincipal.EscolherTela();
                TelaEmprestimo telaEmprestimo = telaPrincipal.EscolherEmprestimo();
                TelaMulta telaMultas = telaPrincipal.EscolherMultas();

                if (telaEscolhida == null && telaEmprestimo == null && telaMultas == null)
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

                else if (telaMultas == telaPrincipal.telaMulta)
                {
                    ControleDeMultas(telaPrincipal, telaMultas);
                }
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
                default:
                    break;
            }
        }

        static void ControleDeMultas(TelaPrincipal telaPrincipal, TelaMulta telaMultas)
        {
            int opcaoEscolhida = telaMultas.OpcaoDoMenu();

            switch (opcaoEscolhida)
            {
                case 1:
                    telaMultas.GerarMulta();
                    break;
                case 2:
                    telaMultas.Visualizar();
                    break;
                case 3:
                    telaMultas.QuitarMulta();
                    break;
                default:
                    break;
            }
        }
    }
}
