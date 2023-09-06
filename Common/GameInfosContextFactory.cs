using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Common;

public class GameInfosContextFactory
{
    public static RepositoryDbContext Create()
    {
        var options = new DbContextOptionsBuilder<RepositoryDbContext>()
            .UseCosmos("https://apps.documents.azure.com:443/", "hyQNoQ4yhFqj1eEPX6PJJZwlRx4TWBGvtnnNd87ujKzZrKU6r5SzRzoa1k59w26ssKEQNCsXnaHmACDbTuE1tg==","minesweeper_test")
            .Options;
        var context = new RepositoryDbContext(options);
        return context;
    }

    public static void Destroy(RepositoryDbContext context) =>
        context.Dispose();

}