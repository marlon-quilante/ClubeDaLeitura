using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public TelaAmigo() : base("Amigo", new RepositorioAmigo())
        {
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Nome do amigo: ");
            string nomeAmigo = Console.ReadLine();
            Console.Write("Nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

            return amigo;
        }
    }
}
