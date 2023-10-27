using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public class ListaDeComprasRepositorio : IListaDeComprasRepositorio
    {
        private readonly IDbConnection _connection;

        public ListaDeComprasRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<ListaDeCompras>> GetAllAsync()
        {
            return await _connection.QueryAsync<ListaDeCompras>("SELECT * FROM ListaDeCompras");
        }

        public async Task<ListaDeCompras> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<ListaDeCompras>("SELECT * FROM ListaDeCompras WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> InsertAsync(ListaDeCompras listaDeCompras)
        {
            return await _connection.ExecuteAsync("INSERT INTO ListaDeCompras (Nome, Data_criacao, Descricao, Usuario_Id) VALUES (@Nome, @Data_criacao, @Descricao, @Usuario_Id)", listaDeCompras);
        }

        public async Task<int> UpdateAsync(ListaDeCompras listaDeCompras)
        {
            return await _connection.ExecuteAsync("UPDATE ListaDeCompras SET Nome = @Nome, Data_criacao = @Data_criacao, Descricao = @Descricao, Usuario_Id = @Usuario_Id WHERE Id = @Id", listaDeCompras);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync("DELETE FROM ListaDeCompras WHERE Id = @Id", new { Id = id });
        }
    }
}
