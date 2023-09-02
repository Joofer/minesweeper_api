using Domain.RepositoryAbstractions;

namespace Persistence.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryDbContext _context;

    private IGameInfoRepository _gameInfoRepository;

    public RepositoryWrapper(RepositoryDbContext context)
    {
        _context = context;
    }

    public IGameInfoRepository GameInfoRepository
    {
        get
        {
            _gameInfoRepository ??= new GameInfoRepository(_context);
            return _gameInfoRepository;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync(cancellationToken);
}