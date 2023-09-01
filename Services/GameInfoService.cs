using CollectionManager;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Domain.RepositoryAbstractions;
using Minesweeper;
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
        var field = List2d<string>.Identity(newGameRequest.height, newGameRequest.width, " ");

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

        await _repository.GameInfoRepository.AddAsync(gameInfo, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new GameInfoResponse
        {
            game_id = gameInfo.Guid,
            width = gameInfo.Width,
            height = gameInfo.Height,
            completed = false,
            field = field
        };
    }
}