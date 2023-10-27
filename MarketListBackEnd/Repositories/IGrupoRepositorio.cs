using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public interface IGrupoRepositorio
    {
        Task<IEnumerable<Grupo>> GetAllAsync();
        Task<Grupo> GetByIdAsync(int id);
        Task<int> InsertAsync(Grupo grupo);
        Task<int> UpdateAsync(Grupo grupo);
        Task<int> DeleteAsync(int id);
    }
}
