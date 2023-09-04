using CollectionManager;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
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

    public async Task<GameInfoResponse> AddTurnAsync(GameTurnRequest gameTurnRequest,
        CancellationToken cancellationToken = default)
    {
        var gameInfo = await _repository.GameInfoRepository.FindAsync(gameTurnRequest.game_id, cancellationToken) ??
                       throw new GameInfoNotFoundException(gameTurnRequest.game_id);

        if (gameInfo.Completed)
            throw new GameEndedException();

        var turnInfo = new TurnInfo
        {
            Guid = Guid.NewGuid(),
            Column = gameTurnRequest.col,
            Row = gameTurnRequest.row,
            DateTime = DateTime.Now
        };

        gameInfo.TurnInfos.Add(turnInfo);

        var result = TurnManager.Open(gameInfo.Field, gameInfo.OriginField, gameInfo.MinesCount, gameTurnRequest.col, gameTurnRequest.row);
        if (result != (int)TurnResponseCode.Ok) gameInfo.Completed = true;

        await _repository.SaveChangesAsync(cancellationToken);

        var strField = List2d<int>.ToStringType(gameInfo.Field);
        foreach (var row in strField)
        {
            for (var i = 0; i < row.Count; i++)
            {
                if (row[i] == ((int)BoxType.Closed).ToString())
                    row[i] = row[i].Replace(((int)BoxType.Closed).ToString(), " ");
                else
                    row[i] = result switch
                    {
                        (int)TurnResponseCode.Mine => row[i].Replace(((int)BoxType.Mine).ToString(), "X"),
                        (int)TurnResponseCode.End => row[i].Replace(((int)BoxType.Mine).ToString(), "M"),
                        _ => row[i]
                    };
            }
        }

        return new GameInfoResponse
        {
            game_id = gameInfo.Guid,
            width = gameInfo.Width,
            height = gameInfo.Height,
            mines_count = gameInfo.MinesCount,
            completed = gameInfo.Completed,
            field = strField
        };
    }
}