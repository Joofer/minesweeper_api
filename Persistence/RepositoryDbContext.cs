using Domain.Entities;
using MaikeBing.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class RepositoryDbContext : DbContext
{
    public DbSet<GameInfo> GameInfos { get; set; } = null!;

    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseLiteDB("liteDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
}