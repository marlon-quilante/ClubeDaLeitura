namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        private string entidade;
        private int idContador = 1;
        public RepositorioBase repositorio;

        public TelaBase(string entidade, RepositorioBase repositorio)
        {
            this.entidade = entidade;
            this.repositorio = repositorio;
        }

        public void Cadastro()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Cadastro de {entidade}");
            Console.WriteLine("------------------------");

            EntidadeBase novoRegistro = ObterDados();
            novoRegistro.id = idContador;
            idContador++;
            string erros = novoRegistro.Validacao();

            if (erros != "")
            {
                Console.WriteLine(erros);
            }
            repositorio.CadastrarRegistro(novoRegistro);
        }

        protected abstract EntidadeBase ObterDados();
    }
}
