namespace MarketListBackEnd.Model
{
    public class ListaDeCompras
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_criacao { get; set; }
        public string Descricao { get; set; }
        public int Usuario_Id { get; set; }
    }
}
