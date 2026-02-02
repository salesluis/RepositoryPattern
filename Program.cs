using Microsoft.EntityFrameworkCore;
using RepositoryStore.Data;
using RepositoryStore.Repositories;
using RepositoryStore.Repositories.Abstractions;
using RepositoryStore.Routes;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
builder.Services.AddDbContext<AppDbContext>(o
    => o.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapProductRoutes();

app.Run();
