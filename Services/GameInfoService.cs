using Contracts.Requests;
using Contracts.Responses;
using Domain.RepositoryAbstractions;
using Services.Abstractions;

namespace Services;

internal sealed class GameInfoService : IGameInfoService
{
    private readonly IRepositoryWrapper _repository;

    public GameInfoService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<GameInfoResponse> CreateGameAsync(NewGameRequest newGameRequest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}