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

        public override void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"{entidade}s Cadastrados");
            Console.WriteLine("------------------------");

            Console.WriteLine();
            Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                "ID","Nome", "Responsável", "Telefone");

            foreach (Amigo amigo in repositorio.listaRegistros)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-25} | {3,-20}",
                    amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.telefone);
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
