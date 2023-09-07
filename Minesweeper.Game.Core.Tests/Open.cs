using Common;
using Minesweeper.Game.Core.Exceptions;

namespace Minesweeper.Game.Core.Tests;

public class Open
{
    [Fact]
    public void ShouldReturnOkTurnResponseCode()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();

        // Act
        var result = TurnManager.Turn(gameInfo.Field, gameInfo.OriginField, gameInfo.MinesCount, 0, 0);

        // Assert
        Assert.Equal((int)TurnResponseCode.Ok, result);
        Assert.Equal(0, gameInfo.Field[0][0]);
    }

    [Fact]
    public void ShouldReturnMineTurnResponseCode()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        var yPos = 2;
        var xPos = 2;

        // Act
        var result = TurnManager.Turn(gameInfo.Field, gameInfo.OriginField, gameInfo.MinesCount, xPos, yPos);

        // Assert
        Assert.Equal((int)TurnResponseCode.Mine, result);
    }

    [Fact]
    public void ShouldReturnEndTurnResponseCode()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.MinesCount = 1;
        gameInfo.Field = new List<List<int>>
        {
            new() { (int)BoxType.Closed, (int)BoxType.Closed, (int)BoxType.Closed },
            new() { (int)BoxType.Closed, (int)BoxType.Closed, (int)BoxType.Closed },
            new() { (int)BoxType.Closed, (int)BoxType.Closed, (int)BoxType.Closed },
        };
        gameInfo.OriginField = new List<List<int>>
        {
            new() { 0, 0, 0 },
            new() { 0, 1, 1 },
            new() { 0, 1, (int)BoxType.Mine },
        };

        // Act
        var result = TurnManager.Turn(gameInfo.Field, gameInfo.OriginField, gameInfo.MinesCount, 0, 0);

        // Assert
        Assert.Equal((int)TurnResponseCode.End, result);
        Assert.DoesNotContain((int)BoxType.Closed, gameInfo.Field.SelectMany(x => x).ToList());
    }

    [Fact]
    public void ShouldThrowBoxOpenedException()
    {
        // Arrange
        var gameInfo = GameInfoSamples.GetA();
        gameInfo.Field[0][0] = 0;

        // Act

        // Assert
        Assert.Throws<BoxOpenedException>(() => TurnManager.Turn(gameInfo.Field, gameInfo.OriginField, gameInfo.MinesCount, 0, 0));
    }
}