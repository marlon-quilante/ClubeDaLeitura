using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmprestimo;

namespace ClubeDaLeitura.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        private RepositorioReserva repositorioReserva;
        private string formatoColunasTabela = "{0,-5} | {1,-25} | {2,-25} | {3,-20} | {5,-10}";

        public TelaReserva(RepositorioReserva repositorioReserva) : base("Reserva", repositorioReserva)
        {
            this.repositorioReserva = repositorioReserva;
        }

        public override int OpcaoDoMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Controle de Reservas");
            Console.WriteLine("------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1 - Criar");
            Console.WriteLine("2 - Cancelar");
            Console.WriteLine("3 - Visualizar");
            Console.WriteLine("4 - Retirar Revista");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine(formatoColunasTabela,
               "ID", "Amigo", "Revista", "Data de Reserva", "Status");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Reserva r = (Reserva)registro;

            Console.WriteLine(formatoColunasTabela,
                r.id, r.amigo.nome, r.revista.titulo,
                r.dataReserva.ToShortDateString(), r.status);
        }

        protected override EntidadeBase ObterDados()
        {
            throw new NotImplementedException();
        }

        protected override bool TemRestricao(EntidadeBase registro)
        {
            throw new NotImplementedException();
        }
    }
}
