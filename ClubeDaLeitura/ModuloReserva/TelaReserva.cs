using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        private string formatoColunasTabela = "{0,-5} | {1,-25} | {2,-25} | {3,-20} | {4,-10}";

        private RepositorioReserva repositorioReserva;

        public Amigo amigo;
        public Revista revista;

        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;
        public RepositorioEmprestimo repositorioEmprestimo;

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
            Console.WriteLine("5 - Voltar");
            Console.WriteLine();

            return int.Parse(Console.ReadLine());
        }

        public void Cancelar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Cancelamento de Reserva");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int idReserva = ObterID();
            Reserva reserva = (Reserva)repositorioReserva.BuscarRegistroPorID(idReserva);
            
            if (reserva.status == "Cancelada" || reserva.status == "Concluída")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Essa reserva já foi cancelada ou concluída!");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para voltar...");
                Console.ReadLine();
            }
            else
            {
                repositorioReserva.CancelarReserva(reserva);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Cancelamento realizado com sucesso!");
                Console.ReadLine();
                Console.ResetColor();
            }
        }

        public void RetirarRevista()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Retirada de Revista");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int idReserva = ObterID();
            Reserva reserva = (Reserva)repositorioReserva.BuscarRegistroPorID(idReserva);

            if (reserva.status == "Cancelada" || reserva.status == "Concluída")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Essa reserva já foi cancelada ou concluída!");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para voltar...");
                Console.ReadLine();
            }
            else
            {
                Emprestimo emprestimo = repositorioReserva.GerarEmprestimo(reserva);
                repositorioEmprestimo.CadastrarRegistro(emprestimo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Revista retirada com sucesso!");
                Console.ReadLine();
                Console.ResetColor();
            }
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

        protected override bool TemRestricaoDeExclusao(EntidadeBase registro)
        {
            throw new NotImplementedException();
        }
    }
}
