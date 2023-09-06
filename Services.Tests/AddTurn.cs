using Common;
using Contracts.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Minesweeper.Exceptions;

namespace Services.Tests;

public class AddTurn : TestBase
{
    private readonly GameInfo _gameInfo = GameInfoSamples.GetA();

    public AddTurn()
    {
        Context.GameInfos.Add(_gameInfo);
        Context.SaveChanges();
    }

    [Fact]
    public async Task ShouldAddTurnAsync()
    {
        // Arrange
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = _gameInfo.Guid,
            row = 0,
            col = 0
        };

        // Act
        var result = await ServiceWrapper.TurnInfoService.AddTurnAsync(gameTurnRequest);

        // Assert
        Assert.Equal(_gameInfo.Width, result.width);
        Assert.Equal(_gameInfo.Height, result.height);
        Assert.Equal(_gameInfo.MinesCount, result.mines_count);
        Assert.Equal(_gameInfo.Completed, result.completed);
    }

    [Fact]
    public async Task ShouldThrowBoxOpenedException()
    {
        // Arrange
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = _gameInfo.Guid,
            row = 0,
            col = 0
        };

        // Act, Assert
        await Assert.ThrowsAsync<BoxOpenedException>(async () =>
            await ServiceWrapper.TurnInfoService.AddTurnAsync(gameTurnRequest));
    }

    [Fact]
    public async Task ShouldThrowGameEndedException()
    {
        // Arrange
        _gameInfo.Completed = true;
        Context.GameInfos.Update(_gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = _gameInfo.Guid,
            row = 0,
            col = 0
        };

        // Act, Assert
        await Assert.ThrowsAsync<GameEndedException>(async () =>
            await ServiceWrapper.TurnInfoService.AddTurnAsync(gameTurnRequest));
    }
}