using MarketListBackEnd.Repositories;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

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

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
