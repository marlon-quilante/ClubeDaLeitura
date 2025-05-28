namespace ClubeDaLeitura.Compartilhado
{
    public abstract class RepositorioBase
    {
        public List<EntidadeBase> listaRegistros = new List<EntidadeBase>();

        public void CadastrarRegistro(EntidadeBase registro)
        {
            listaRegistros.Add(registro);            
        }
    }
}
