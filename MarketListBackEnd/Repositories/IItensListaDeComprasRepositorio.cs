using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public interface IItensListaDeComprasRepositorio
    {
        Task<IEnumerable<ItensListaDeCompras>> GetAllAsync();
        Task<ItensListaDeCompras> GetByIdAsync(int id);
        Task<int> InsertAsync(ItensListaDeCompras item);
        Task<int> UpdateAsync(ItensListaDeCompras item);
        Task<int> DeleteAsync(int id);
    }
}
