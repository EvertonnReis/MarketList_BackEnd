using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public class ItensListaDeComprasRepositorio : IItensListaDeComprasRepositorio
    {
        private readonly IDbConnection _connection;

        public ItensListaDeComprasRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<ItensListaDeCompras>> GetAllAsync()
        {
            return await _connection.QueryAsync<ItensListaDeCompras>("SELECT * FROM ItensListaDeCompras");
        }

        public async Task<ItensListaDeCompras> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<ItensListaDeCompras>("SELECT * FROM ItensListaDeCompras WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> InsertAsync(ItensListaDeCompras item)
        {
            return await _connection.ExecuteAsync("INSERT INTO ItensListaDeCompras (Nome_item, Descricao, Status, ListaDeCompras_Id) VALUES (@Nome_item, @Descricao, @Status, @ListaDeCompras_Id)", item);
        }

        public async Task<int> UpdateAsync(ItensListaDeCompras item)
        {
            return await _connection.ExecuteAsync("UPDATE ItensListaDeCompras SET Nome_item = @Nome_item, Descricao = @Descricao, Status = @Status, ListaDeCompras_Id = @ListaDeCompras_Id WHERE Id = @Id", item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync("DELETE FROM ItensListaDeCompras WHERE Id = @Id", new { Id = id });
        }
    }
}
