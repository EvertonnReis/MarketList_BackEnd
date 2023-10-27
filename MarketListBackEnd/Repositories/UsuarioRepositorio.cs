using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MarketListBackEnd.Model;

namespace MarketListBackEnd.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IDbConnection _connection;

        public UsuarioRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _connection.QueryAsync<Usuario>("SELECT * FROM Usuario");
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuario WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> InsertAsync(Usuario usuario)
        {
            return await _connection.ExecuteAsync("INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)", usuario);
        }

        public async Task<int> UpdateAsync(Usuario usuario)
        {
            return await _connection.ExecuteAsync("UPDATE Usuario SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE Id = @Id", usuario);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _connection.ExecuteAsync("DELETE FROM Usuario WHERE Id = @Id", new { Id = id });
        }
    }
}
