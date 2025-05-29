namespace ClubeDaLeitura.Compartilhado
{
    public class RepositorioBase
    {
        public List<EntidadeBase> listaRegistros = new List<EntidadeBase>();
        public EntidadeBase entidadeBase;

        public void CadastrarRegistro(EntidadeBase registro)
        {
            listaRegistros.Add(registro);
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
