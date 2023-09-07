using CollectionManager;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Domain.RepositoryAbstractions;
using Minesweeper;
using Minesweeper.Game.Core;
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
        var field = List2d<int>.Identity(newGameRequest.height, newGameRequest.width, (int)BoxType.Closed);

        var gameInfo = new GameInfo
        {
            Width = newGameRequest.width,
            Height = newGameRequest.height,
            MinesCount = newGameRequest.mines_count,
            Completed = false,
            Field = field,
            OriginField =
                GameManager.CreateGame(newGameRequest.width, newGameRequest.height, newGameRequest.mines_count)
        };

        _repository.GameInfoRepository.Add(gameInfo);
        await _repository.SaveChangesAsync(cancellationToken);

        var strField = List2d<string>.Identity(newGameRequest.height, newGameRequest.width, " ");

        return new GameInfoResponse
        {
            game_id = gameInfo.Guid,
            width = gameInfo.Width,
            height = gameInfo.Height,
            mines_count = gameInfo.MinesCount,
            completed = false,
            field = strField
        };
    }
}