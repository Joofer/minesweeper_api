using Contracts.Requests;
using Contracts.Responses;

namespace Services.Abstractions;

public interface IGameInfoService
{
    Task<GameInfoResponse> CreateGameAsync(NewGameRequest newGameRequest,
        CancellationToken cancellationToken = default);
}