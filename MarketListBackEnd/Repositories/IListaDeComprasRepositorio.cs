using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public interface IListaDeComprasRepositorio
    {
        Task<IEnumerable<ListaDeCompras>> GetAllAsync();
        Task<ListaDeCompras> GetByIdAsync(int id);
        Task<int> InsertAsync(ListaDeCompras listaDeCompras);
        Task<int> UpdateAsync(ListaDeCompras listaDeCompras);
        Task<int> DeleteAsync(int id);
    }
}
