using Repository.Tests.Common;

namespace Repository.Tests;

public class FindGameInfo : TestBase
{
    [Fact]
    public async Task ShouldFindGameInfoAsync()
    {
        // Arrange
        var guid = GameInfosContextFactory.GameInfoA.Guid;
        var original = GameInfosContextFactory.GameInfoA;

        // Act
        var repositoryFound = await RepositoryWrapper.GameInfoRepository.FindAsync(guid);

        // Assert
        Assert.Equal(original, repositoryFound);
    }
}