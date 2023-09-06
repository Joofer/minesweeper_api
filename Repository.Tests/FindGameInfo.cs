using Common;

namespace Repository.Tests;

public class FindGameInfo : TestBase
{
    [Fact]
    public async Task ShouldFindGameInfoAsync()
    {
        // Arrange
        var original = GameInfoSamples.GetA();
        Context.GameInfos.Add(original);
        await Context.SaveChangesAsync();

        // Act
        var repositoryFound = await RepositoryWrapper.GameInfoRepository.FindAsync(original.Guid);

        // Assert
        Assert.Equal(original, repositoryFound);
    }
}