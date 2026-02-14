using DotNetEnv;
var builder = WebApplication.CreateBuilder(args);
Env.Load();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();