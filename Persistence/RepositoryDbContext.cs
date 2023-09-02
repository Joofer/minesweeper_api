using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class RepositoryDbContext : DbContext
{
    public DbSet<GameInfo> GameInfos { get; set; } = null!;

    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
    }
}