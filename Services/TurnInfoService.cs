using Contracts.Requests;
using Domain.RepositoryAbstractions;
using Services.Abstractions;

namespace Services;

internal sealed class TurnInfoService : ITurnInfoService
{
    private readonly IRepositoryWrapper _repository;

    public TurnInfoService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task AddTurnAsync(GameTurnRequest gameTurnRequest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}