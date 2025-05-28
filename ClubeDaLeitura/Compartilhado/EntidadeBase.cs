namespace ClubeDaLeitura.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public bool TelefoneValido(string telefone)
        {
            if (telefone.Length < 14 || telefone.Length > 15 || telefone[0] != '(' ||
                telefone[3] != ')' || (!telefone.Substring(5, 6).Contains('-')) || telefone[4] != ' ')
                return false;

            return true;
        }

        public abstract string Validacao();
    }
}
