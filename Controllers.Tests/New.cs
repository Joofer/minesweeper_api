using Common;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;

namespace Controllers.Tests;

public class New : TestBase
{
    private readonly GameInfoController _controller;

    public New() =>
        _controller = new GameInfoController(ServiceWrapper);

    [Fact]
    public async Task ShouldReturnOkAsync()
    {
        // Arrange
        var newGameRequest = new NewGameRequest
        {
            width = 10,
            height = 10,
            mines_count = 10
        };

        // Act
        var result = await _controller.NewAsync(newGameRequest, CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}