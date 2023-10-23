namespace Model.ModuloCartao
{
    public class Cartao
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        public string DisplayMember => $"{Id} - {Descricao}";
    }
}
