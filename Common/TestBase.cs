using Domain.RepositoryAbstractions;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

namespace Common;

public abstract class TestBase : IDisposable
{
    protected readonly RepositoryDbContext Context;
    protected readonly IRepositoryWrapper RepositoryWrapper;
    protected readonly IServiceWrapper ServiceWrapper;

    protected TestBase()
    {
        Context = GameInfosContextFactory.Create();
        RepositoryWrapper = new RepositoryWrapper(Context);
        ServiceWrapper = new ServiceWrapper(RepositoryWrapper);
    }

    public void Dispose() =>
        GameInfosContextFactory.Destroy(Context);
}