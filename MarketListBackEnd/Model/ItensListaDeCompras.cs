namespace MarketListBackEnd.Model
{
    public class ItensListaDeCompras
    {
        public int Id { get; set; }
        public string NomeItem { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public int ListaDeComprasId { get; set; }
    }
}
