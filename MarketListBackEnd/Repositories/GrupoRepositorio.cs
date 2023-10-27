using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Importe o namespace correto para MySqlConnection
using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly IDbConnection _connection;

        public GrupoRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Grupo>> GetAllAsync()
        {
            return await _connection.QueryAsync<Grupo>("SELECT * FROM Grupo");
        }

        public async Task<Grupo> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Grupo>("SELECT * FROM Grupo WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> InsertAsync(Grupo grupo)
        {
            return await _connection.ExecuteAsync("INSERT INTO Grupo (ListaDeCompras_Id, Usuario_Id) VALUES (@ListaDeCompras_Id, @Usuario_Id)", grupo);
        }

        public async Task<int> UpdateAsync(Grupo grupo)
        {
            return await _connection.ExecuteAsync("UPDATE Grupo SET ListaDeCompras_Id = @ListaDeCompras_Id, Usuario_Id = @Usuario_Id WHERE Id = @Id", grupo);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync("DELETE FROM Grupo WHERE Id = @Id", new { Id = id });
        }
    }
}