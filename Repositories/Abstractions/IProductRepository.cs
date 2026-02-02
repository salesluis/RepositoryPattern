using RepositoryStore.Entities;

namespace RepositoryStore.Repositories.Abstractions;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(int skip, int take, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(int id,CancellationToken cancellationToken);
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> RemoveAsync(Product product, CancellationToken cancellationToken);
}