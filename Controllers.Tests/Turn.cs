using Common;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;

namespace Controllers.Tests;

public class Turn : TestBase
{
    private readonly TurnInfoController _controller;

    public Turn() =>
        _controller = new TurnInfoController(ServiceWrapper);

    [Fact]
    public async Task ShouldReturnOkAsync()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
            col = 0,
            row = 0
        };

        // Act
        var result = await _controller.TurnAsync(gameTurnRequest, CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ShouldReturnBadRequestWithBoxOpenedExceptionAsync()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.Field[0][0] = 0;
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
            col = 0,
            row = 0
        };

        // Act
        var result = await _controller.TurnAsync(gameTurnRequest, CancellationToken.None);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task ShouldReturnBadRequestWithGameEndedExceptionAsync()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.Completed = true;
        Context.GameInfos.Add(gameInfo);
        await Context.SaveChangesAsync();
        var gameTurnRequest = new GameTurnRequest
        {
            game_id = gameInfo.Guid,
            col = 0,
            row = 0
        };

        // Act
        var result = await _controller.TurnAsync(gameTurnRequest, CancellationToken.None);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}