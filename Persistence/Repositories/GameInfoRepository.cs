using Domain.Entities;
using Domain.RepositoryAbstractions;

namespace Persistence.Repositories;

internal sealed class GameInfoRepository : RepositoryBase<GameInfo>, IGameInfoRepository
{
    public GameInfoRepository(RepositoryDbContext context) : base(context)
    {
    }
}