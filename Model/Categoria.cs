namespace Model
{
    public enum TipoSinal
    {
        D,
        S
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sinal { get; set; }

        public string DisplayMember()
        {
            return $"{Id} - {Descricao}";
        }
    }
}