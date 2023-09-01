using Domain.Entities;

namespace Domain.RepositoryAbstractions;

public interface ITurnInfoRepository : IRepositoryBase<TurnInfo>
{
    Task<IEnumerable<TurnInfo>> GetAllFromGameInfoAsync(object gameInfoKeyValue,
        CancellationToken cancellationToken = default);
}