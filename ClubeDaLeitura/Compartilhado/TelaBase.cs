using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        protected string entidade;
        private int idContador = 1;
        private RepositorioBase repositorioBase;

        public TelaBase(string entidade, RepositorioBase repositorio)
        {
            this.entidade = entidade;
            this.repositorioBase = repositorio;
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
            string erros = novoRegistro.Validacao(novoRegistro, repositorioBase);
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
            repositorioBase.CadastrarRegistro(novoRegistro);
        }

        public abstract void Visualizar();

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Edição de {entidade}");
            Console.WriteLine("------------------------");

            int id = ObterID();
            Console.WriteLine();
            if (repositorioBase.IDExiste(id))
            {
                EntidadeBase registroAtualizado = ObterDados();
                repositorioBase.AtualizarRegistro(id, registroAtualizado);
            }
            else
            {
                Console.WriteLine("ID digitado não existe! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Editar();
                return;
            }
        }

        public abstract void Deletar();

        public int ObterID()
        {
            Console.WriteLine();
            Console.Write($"ID{entidade}: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorioBase.IDExiste(id))
                return id;
            else
            {
                Console.WriteLine();
                Console.Write("ID não localizado! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                return ObterID();
            }
        }

        protected abstract EntidadeBase ObterDados();
    }
}
