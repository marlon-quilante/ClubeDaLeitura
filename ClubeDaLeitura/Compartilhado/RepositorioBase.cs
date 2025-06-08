namespace ClubeDaLeitura.Compartilhado
{
    public abstract class RepositorioBase
    {
        public List<EntidadeBase> listaRegistros = new List<EntidadeBase>();
        private int idContador = 1;

        public virtual void CadastrarRegistro(EntidadeBase registro)
        {
            registro.id = idContador;
            listaRegistros.Add(registro);
            idContador++;
        }

        public void AtualizarRegistro(int idParametro, EntidadeBase registroAtualizado)
        {
            foreach (EntidadeBase registro in listaRegistros)
            {
                if (idParametro == registro.id)
                {
                    registro.Atualizar(registroAtualizado);
                }
            }
        }

        public void DeletarRegistro(int id)
        {
            EntidadeBase registro = BuscarRegistroPorID(id);
            listaRegistros.Remove(registro);
        }

        public bool IDExiste(int id)
        {
            foreach (EntidadeBase registro in listaRegistros)
            {
                if (id == registro.id)
                    return true;
            }
            return false;
        }

        public EntidadeBase BuscarRegistroPorID(int id)
        {
            foreach (EntidadeBase registro in listaRegistros)
            {
                if (id == registro.id)
                    return registro;
            }
            return null;
        }
    }
}
