using Domain.RepositoryAbstractions;
using Persistence;
using Persistence.Repositories;

namespace Common;

public abstract class TestBase
{
    protected static readonly RepositoryDbContext Context = GameInfosContextFactory.Create();
    protected static readonly IRepositoryWrapper RepositoryWrapper = new RepositoryWrapper(Context);
}