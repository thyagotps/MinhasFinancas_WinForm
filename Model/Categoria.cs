namespace Model
{
    public enum TipoSinal
    {
        D,
        S
    }

    public class Categoria
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sinal { get; set; }
    }
}