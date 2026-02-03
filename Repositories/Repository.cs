using Microsoft.EntityFrameworkCore;
using RepositoryStore.Repositories.Abstractions;

namespace RepositoryStore.Repositories;

public abstract class Repository<T>(DbContext context) 
    : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>() ;
    
    public async Task<List<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken)
    {
        var itens =  await _dbSet
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return itens;
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _dbSet.FindAsync(id, cancellationToken);
        return item;
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> RemoveAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}