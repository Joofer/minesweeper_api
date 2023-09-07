using Domain.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected RepositoryDbContext Context;

    protected RepositoryBase(RepositoryDbContext context) =>
        Context = context;

    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default) =>
    await Context.Set<TEntity>().ToListAsync(cancellationToken);

    public async Task<TEntity> FindAsync(object keyValue, CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().FindAsync(keyValue, cancellationToken) ?? throw new InvalidOperationException();

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken) ??
        throw new InvalidOperationException();

    public void Add(TEntity entity) =>
        Context.Set<TEntity>().Add(entity);

    public void Update(TEntity entity) =>
        Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) =>
        Context.Set<TEntity>().Remove(entity);
}