namespace CollectionManager.Tests;

public class Identity
{
    [Fact]
    public void ShouldReturnIdentityMatrix()
    {
        // Arrange

        // Act
        var result = List2d<int>.Identity(5, 5);

        // Assert
        foreach (var row in result)
            Assert.DoesNotContain(row, x => x != default);
    }
}