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
            
            telaAmigo.repositorio = repositorio;

            while (true)
            {
                telaAmigo.Cadastro();
            }
        }
    }
}
