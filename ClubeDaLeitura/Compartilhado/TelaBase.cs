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
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Cadastro de {entidade}");
            Console.WriteLine("------------------------");

            EntidadeBase novoRegistro = ObterDados();
            novoRegistro.id = idContador;
            string erros = novoRegistro.Validacao(novoRegistro, repositorio);
            Console.WriteLine();
            if (erros != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Cadastro();
                return;
            }
            Console.WriteLine("Cadastro realizado com sucesso!");
            idContador++;
            repositorio.CadastrarRegistro(novoRegistro);
        }

        protected abstract EntidadeBase ObterDados();
    }
}
