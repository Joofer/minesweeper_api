using System.Linq.Expressions;

namespace Domain.RepositoryAbstractions;

public interface IRepositoryBase<TEntity>
{
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);
    Task<TEntity> FindAsync(object keyValue, CancellationToken cancellationToken = default);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task RemoveAsync(object keyValue, CancellationToken cancellationToken = default);
}