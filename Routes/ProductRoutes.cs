
using RepositoryStore.Entities;
using RepositoryStore.Repositories.Abstractions;

namespace RepositoryStore.Routes;

public static class ProductRoutes
{
    public static void MapProductRoutes(this WebApplication app)
    {
        var prefix = app.MapGroup("v1/products");

        prefix.MapGet("/", async (IProductRepository repository)
            => await repository.GetAllAsync(0, 25, new CancellationToken()));

        prefix.MapGet("/{id:int}", async (IProductRepository repository, int id) =>
        {
            var product = await repository.GetByIdAsync(id,  new CancellationToken());
            if (product is null)
                return Results.NotFound("Product not found");
            return Results.Ok(product);
        });

        prefix.MapPost("/", async (IProductRepository repository, Product product) =>
        {
            await repository.CreateAsync(product, new CancellationToken());
            return Results.Created($"v1/products/{product.Id}", product);
        });
        
        prefix.MapPut("/", async (IProductRepository repository, Product product) =>
        {
            await repository.UpdateAsync(product, new CancellationToken());
            Results.Ok($"Product with id:{product.Id} updated successfully");
        });
        
        prefix.MapDelete("/{id:int}", async (int id, IProductRepository repository) =>
        {
            var productExist = await repository.GetByIdAsync(id, new CancellationToken());
            return productExist is null 
                ? Results.NotFound("Product not found") 
                : Results.Ok(productExist);
        });
    }
}