using ClubeDaLeitura.Compartilhado;

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
    }
}
