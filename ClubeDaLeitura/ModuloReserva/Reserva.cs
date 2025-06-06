using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigo;
using ClubeDaLeitura.ModuloRevista;

namespace ClubeDaLeitura.ModuloReserva
{
    public class Reserva : EntidadeBase
    {
        public Amigo amigo;
        public Revista revista;
        public DateTime dataReserva = DateTime.Now;
        public string status = "Ativa";

        public Reserva(Amigo amigo, Revista revista, DateTime dataReserva)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataReserva = dataReserva;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio)
        {
            throw new NotImplementedException();
        }

        public override string Validacao(EntidadeBase registro, RepositorioBase repositorio)
        {
            string erros = "";

            if (amigo.temMulta == true)
                erros += "Este amigo possui multa pendente!\n";
            if (revista.status != "Disponível")
                erros += "Esta revista não está disponível!\n";

            return erros;
        }
    }
}
