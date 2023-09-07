namespace Minesweeper.Game.Core.Tests;

public class CreateGame
{
    [Fact]
    public void ShouldCreateGameField()
    {
        // Arrange
        int width = 10;
        int height = 10;
        int minesCount = 10;

        // Act
        var result = GameManager.CreateGame(width, height, minesCount);

        // Assert
        Assert.Equal(width, result[0].Count);
        Assert.Equal(height, result.Count);
        Assert.Equal(minesCount, result.SelectMany(x => x).Count(x => x == (int)BoxType.Mine));
    }
}