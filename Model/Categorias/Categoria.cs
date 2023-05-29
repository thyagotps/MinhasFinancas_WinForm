namespace Model.Categorias
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        public string DisplayMember()
        {
            return $"{Id} - {Descricao}";
        }
    }
}