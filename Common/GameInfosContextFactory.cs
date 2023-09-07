using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Common;

public class GameInfosContextFactory
{
    public static RepositoryDbContext Create()
    {
        var options = new DbContextOptionsBuilder<RepositoryDbContext>()
            .UseCosmos("https://apps.documents.azure.com:443/", "<key>","<testing_database>")
            .Options;
        var context = new RepositoryDbContext(options);
        return context;
    }

    public static void Destroy(RepositoryDbContext context) =>
        context.Dispose();

}