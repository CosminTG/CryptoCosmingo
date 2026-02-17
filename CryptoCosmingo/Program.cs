using CryptoCosmingo.Config;
using CryptoCosmingo.Data;
using CryptoCosmingo.Repositories;
using CryptoCosmingo.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("DB_CONNECTION no está configurada en el archivo .env");
}

builder.Services.AddSingleton(new DatabaseConfig
{
    ConnectionString = connectionString
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<ISymbolService, SymbolService>();

DatabaseInit.CreateTables(connectionString);

var app = builder.Build();
app.MapControllers();
app.Run();
