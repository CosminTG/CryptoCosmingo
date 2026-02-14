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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton(new DatabaseConfig
{
    ConnectionString = connectionString
});

builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();
builder.Services.AddScoped<ISymbolService, SymbolService>();

var app = builder.Build();

DatabaseInit.CreateTables(connectionString);

app.MapControllers();
app.Run();
