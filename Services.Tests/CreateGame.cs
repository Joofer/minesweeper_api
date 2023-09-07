using Common;
using Contracts.Requests;

namespace Services.Tests;

public class CreateGame : TestBase
{
    [Fact]
    public async Task ShouldCreateGameAsync()
    {
        // Arrange
        var newGameRequest = new NewGameRequest
        {
            width = 10,
            height = 10,
            mines_count = 10
        };

        // Act
        var result = await ServiceWrapper.GameInfoService.CreateGameAsync(newGameRequest);

        // Assert
        Assert.Equal(newGameRequest.width, result.width);
        Assert.Equal(newGameRequest.height, result.height);
        Assert.Equal(newGameRequest.mines_count, result.mines_count);
    }
}