using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaBase telaAmigo = new TelaAmigo();
            RepositorioBase repositorio = new RepositorioAmigo();
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            
            telaAmigo.repositorio = repositorio;

            while (true)
            {
                telaPrincipal.MenuPrincipal();
                string opcaoEscolhida = telaAmigo.OpcaoDoMenu();

                switch (int.Parse(opcaoEscolhida))
                {
                    case 1:
                        telaAmigo.Cadastro();
                        break;
                    case 2:
                        telaAmigo.Visualizar();
                        break;
                    case 3:
                        telaAmigo.Editar();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
