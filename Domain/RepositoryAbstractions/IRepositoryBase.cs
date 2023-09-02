using System.Linq.Expressions;

namespace Domain.RepositoryAbstractions;

public interface IRepositoryBase<TEntity>
{
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
    Task<TEntity> FindAsync(object keyValue, CancellationToken cancellationToken = default);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}