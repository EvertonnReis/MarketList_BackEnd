namespace MarketListBackEnd.Model
{
    public class ItensListaDeCompras
    {
        public int Id { get; set; }
        public string Nome_item { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public int ListaDeCompras_Id { get; set; }
    }
}
