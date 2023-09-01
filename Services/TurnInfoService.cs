using Contracts.Requests;
using Domain.Exceptions;
using Domain.RepositoryAbstractions;
using Minesweeper;
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
        var gameInfo = await _repository.GameInfoRepository.FindAsync(gameTurnRequest.game_id, cancellationToken) ??
                       throw new GameInfoNotFoundException(gameTurnRequest.game_id);

        if (gameInfo.Completed)
            throw new GameEndedException();

        var result = TurnManager.Open(gameInfo.Field, gameInfo.OriginField, gameTurnRequest.col, gameTurnRequest.row);
        if (result) gameInfo.Completed = false;

        await _repository.SaveChangesAsync(cancellationToken);
    }
}