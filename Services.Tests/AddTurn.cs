using Common;
using Contracts.Requests;
using Domain.Exceptions;
using Minesweeper.Exceptions;

namespace Services.Tests;

public class AddTurn : TestBase
{
    [Fact]
    public async Task ShouldAddTurnAsync()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
            row = 0,
            col = 0
        };

        // Act
        var result = await ServiceWrapper.TurnInfoService.AddTurnAsync(gameTurnRequest);

        // Assert
        Assert.Equal(gameInfo.Width, result.width);
        Assert.Equal(gameInfo.Height, result.height);
        Assert.Equal(gameInfo.MinesCount, result.mines_count);
        Assert.Equal(gameInfo.Completed, result.completed);
    }

    [Fact]
    public async Task ShouldThrowBoxOpenedException()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.Field[0][0] = 0;
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
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
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.Completed = true;
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
            row = 0,
            col = 0
        };

        // Act, Assert
        await Assert.ThrowsAsync<GameEndedException>(async () =>
            await ServiceWrapper.TurnInfoService.AddTurnAsync(gameTurnRequest));
    }
}