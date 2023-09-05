using Microsoft.EntityFrameworkCore;
using Repository.Tests.Common;

namespace Repository.Tests;

public class CreateGameInfo : TestBase
{
    [Fact]
    public async Task ShouldCreateGameInfoAsync()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var width = 10;
        var height = 10;
        var minesCount = 10;
        var completed = false;

        // Act
        RepositoryWrapper.GameInfoRepository.Add(new()
        {
            Guid = guid,
            Width = width,
            Height = height,
            MinesCount = minesCount,
            Completed = completed
        });
        await RepositoryWrapper.SaveChangesAsync();

        // Assert
        Assert.NotNull(await Context.GameInfos.SingleOrDefaultAsync(x =>
            x.Guid == guid &&
            x.Width == width &&
            x.Height == height &&
            x.MinesCount == minesCount &&
            x.Completed == completed));
    }
}