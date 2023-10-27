using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<int> InsertAsync(Usuario usuario);
        Task<int> UpdateAsync(Usuario usuario);
        Task<int> DeleteAsync(int id);
    }
}
