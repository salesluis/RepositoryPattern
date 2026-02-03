namespace RepositoryStore.Repositories.Abstractions;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
    Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<T?> RemoveAsync(T entity, CancellationToken cancellationToken);
}