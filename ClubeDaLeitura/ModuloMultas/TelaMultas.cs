using ClubeDaLeitura.Compartilhado;

namespace ClubeDaLeitura.ModuloMultas
{
    public class TelaMultas : TelaBase
    {
        private RepositorioMultas repositorioMultas;

        public TelaMultas(RepositorioMultas repositorioMultas) : base("Multas", repositorioMultas)
        {
            this.repositorioMultas = repositorioMultas;
        }

        public override void Deletar()
        {
            base.Deletar();
        }

        public override int OpcaoDoMenu()
        {
            throw new NotImplementedException();
        }

        protected override void ApresentarCabecalhoTabela()
        {
            throw new NotImplementedException();
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            throw new NotImplementedException();
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
