using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloReserva
{
    public class RepositorioReserva : RepositorioBase
    {
        public override void CadastrarRegistro(EntidadeBase registro)
        {
            base.CadastrarRegistro(registro);
            Reserva reserva = (Reserva)registro;
            reserva.revista.status = "Reservada";
        }

        public void CancelarReserva(Reserva reserva)
        {
            reserva.status = "Cancelada";
            reserva.revista.status = "Disponível";
        }

        public Emprestimo GerarEmprestimo(Reserva reserva)
        {
            DateTime dataDevolucao = DateTime.Now.AddDays(reserva.revista.caixa.diasEmprestimo);
            Emprestimo emprestimo = new Emprestimo(reserva.amigo, reserva.revista, DateTime.Now, dataDevolucao);
            reserva.status = "Concluída";

            return emprestimo;
        }
    }
}
