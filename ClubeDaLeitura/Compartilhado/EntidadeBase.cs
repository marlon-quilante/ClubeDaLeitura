using ClubeDaLeitura.ModuloAmigo;

namespace ClubeDaLeitura.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public abstract string Validacao(EntidadeBase registro, RepositorioBase repositorio);

        public abstract bool RegistroExiste(EntidadeBase registro, RepositorioBase repositorio);

        public abstract void Atualizar(EntidadeBase registroAtualizado);
    }
}
