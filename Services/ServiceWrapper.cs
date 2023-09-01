using Domain.RepositoryAbstractions;
using Services.Abstractions;

namespace Services;

public sealed class ServiceWrapper : IServiceWrapper
{
    private readonly Lazy<IGameInfoService> _gameInfoService;
    private readonly Lazy<ITurnInfoService> _turnInfoService;

    public ServiceWrapper(IRepositoryWrapper repository)
    {
        _gameInfoService = new Lazy<IGameInfoService>(() => new GameInfoService(repository));
        _turnInfoService = new Lazy<ITurnInfoService>(() => new TurnInfoService(repository));
    }

    public IGameInfoService GameInfoService => _gameInfoService.Value;
    public ITurnInfoService TurnInfoService => _turnInfoService.Value;
}