using MarketListBackEnd.Model;
using MarketListBackEnd.Repositories;
using MarketListBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketListBackEnd.Controllers
{
    [Route("v1/account")]
    public class HomeController: Controller
    {
        [HttpPost]
        [Route("login")]    
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            // Recupera o usuário
            var user = UsuarioRepositorio.Get(model.Nome_usuario, model.Senha);

            // Verifica se o usuário existe
            if (user == null)
                return (new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
