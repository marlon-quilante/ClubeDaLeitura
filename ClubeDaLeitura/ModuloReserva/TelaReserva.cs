using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        private RepositorioReserva repositorioReserva;
        private string formatoColunasTabela = "{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-10}";

        public Amigo amigo;
        public Revista revista;

        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;

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
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Cancelar");
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
            int idAmigo = telaAmigo.ObterID();
            amigo = (Amigo)repositorioAmigo.BuscarRegistroPorID(idAmigo);
            int idRevista = telaRevista.ObterID();
            revista = (Revista)repositorioRevista.BuscarRegistroPorID(idRevista);
            DateTime dataReserva = DateTime.Now;
            Reserva reserva = new Reserva(amigo, revista, dataReserva);
            return reserva;
        }

        protected override bool TemRestricao(EntidadeBase registro)
        {
            throw new NotImplementedException();
        }
    }
}
