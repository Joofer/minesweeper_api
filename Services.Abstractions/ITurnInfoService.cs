using Contracts.Requests;

namespace Services.Abstractions;

public interface ITurnInfoService
{
    Task AddTurnAsync(GameTurnRequest gameTurnRequest, CancellationToken cancellationToken = default);
}