namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        protected string entidade;
        private int idContador = 1;
        public RepositorioBase repositorio;

        public TelaBase(string entidade, RepositorioBase repositorio)
        {
            this.entidade = entidade;
            this.repositorio = repositorio;
        }

        public abstract int OpcaoDoMenu();

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

        public abstract void Visualizar();

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Edição de {entidade}");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int id = ObterID();
            if (repositorio.IDExiste(id))
            {
                EntidadeBase registroAtualizado = ObterDados();
                repositorio.AtualizarRegistro(id, registroAtualizado);
            }
            else
            {
                Console.WriteLine("ID digitado não existe! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Editar();
                return;
            }
        }

        public void Deletar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Exclusão de {entidade}");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int id = ObterID();
            if (repositorio.IDExiste(id))
            {
                repositorio.DeletarRegistro(id);
            }
        }

        private int ObterID()
        {
            Console.Write("Digite o ID: ");
            return int.Parse(Console.ReadLine());
        }

        protected abstract EntidadeBase ObterDados();
    }
}
