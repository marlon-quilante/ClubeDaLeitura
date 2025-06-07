namespace ClubeDaLeitura.Compartilhado
{
    public abstract class TelaBase
    {
        protected string entidade;
        private RepositorioBase repositorioBase;

        public TelaBase(string entidade, RepositorioBase repositorio)
        {
            this.entidade = entidade;
            repositorioBase = repositorio;
        }

        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Cadastro de {entidade}");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            EntidadeBase novoRegistro = ObterDados();
            string erros = novoRegistro.Validacao(novoRegistro, repositorioBase);
            Console.WriteLine();
            if (erros != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Cadastrar();
                return;
            }
            repositorioBase.CadastrarRegistro(novoRegistro);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cadastro realizado com sucesso!");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Edição de {entidade}");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int id = ObterID();
            Console.WriteLine();
            if (repositorioBase.IDExiste(id))
            {
                EntidadeBase registroAtualizado = ObterDados();
                registroAtualizado.id = id;
                string erros = registroAtualizado.Validacao(registroAtualizado, repositorioBase);
                Console.WriteLine();
                if (erros != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(erros);
                    Console.ResetColor();
                    Console.WriteLine("Pressione ENTER para tentar novamente...");
                    Console.ReadLine();
                    Editar();
                    return;
                }
                repositorioBase.AtualizarRegistro(id, registroAtualizado);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Edição realizada com sucesso!");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("ID digitado não existe! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Editar();
                return;
            }
        }

        public virtual void Deletar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Exclusão de {entidade}");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            int id = ObterID();

            EntidadeBase registro = repositorioBase.BuscarRegistroPorID(id);

            bool temRestricao = TemRestricaoDeExclusao(registro);

            if (temRestricao)
            {
                Console.WriteLine();
                Console.WriteLine("Não é possível excluir este registro pois ele possui alguma restrição! Pressione ENTER para voltar...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            if (repositorioBase.IDExiste(id))
            {
                repositorioBase.DeletarRegistro(id);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exclusão realizada com sucesso!");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Registro não encontrado por esse ID! Pressione ENTER para tentar novamente...");
                Console.ReadLine();
                Deletar();
                return;
            }
        }

        public virtual void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"{entidade}s");
            Console.WriteLine("------------------------");

            Console.WriteLine();

            ApresentarCabecalhoTabela();

            foreach (EntidadeBase registro in repositorioBase.listaRegistros)
            {
                ApresentarLinhaTabela(registro);
            }
            Console.WriteLine("\nPressione ENTER para voltar...");
            Console.ReadLine();
        }

        protected abstract void ApresentarLinhaTabela(EntidadeBase registro);

        protected abstract void ApresentarCabecalhoTabela();

        public int ObterID()
        {
            Console.Write($"ID{entidade}: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorioBase.IDExiste(id))
                return id;
            else
            {
                Console.WriteLine();
                Console.Write("ID não localizado! Pressione ENTER para tentar novamente...");
                Console.WriteLine();
                Console.ReadLine();
                return ObterID();
            }
        }

        public abstract int OpcaoDoMenu();

        protected abstract bool TemRestricaoDeExclusao(EntidadeBase registro);        

        protected abstract EntidadeBase ObterDados();
    }
}
