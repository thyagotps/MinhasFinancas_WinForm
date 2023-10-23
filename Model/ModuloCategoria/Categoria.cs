namespace Model.ModuloCategoria
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }

        public string DisplayMember => $"{Id} - {Descricao} - {Tipo}";
    }
}