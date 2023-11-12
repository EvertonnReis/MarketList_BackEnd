using MarketListBackEnd.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using MarketListBackEnd;

var builder = WebApplication.CreateBuilder(args);

// CONEXÃO DB
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var connectionString = "Server=localhost;Port=3306;Database=marketlist;User=root;Password=;";
    return new MySqlConnection(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IGrupoRepositorio, GrupoRepositorio>();
builder.Services.AddScoped<IItensListaDeComprasRepositorio, ItensListaDeComprasRepositorio>();
builder.Services.AddScoped<IListaDeComprasRepositorio, ListaDeComprasRepositorio>();

// JWT TOKEN

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


// CORS

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// CORS

app.UseCors();

app.UseRouting();

// Permite qualquer origem, método e cabeçalho
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();    

app.MapControllers();

app.Run();
