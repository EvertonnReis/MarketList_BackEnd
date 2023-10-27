namespace MarketListBackEnd.Model
{
    public class ListaDeCompras
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
    }
}
