using Contracts.Requests;
using Contracts.Responses;

namespace Services.Abstractions;

public interface ITurnInfoService
{
    Task<GameInfoResponse> AddTurnAsync(GameTurnRequest gameTurnRequest, CancellationToken cancellationToken = default);
}