namespace Domain.RepositoryAbstractions;

public interface IRepositoryWrapper
{
    public IGameInfoRepository GameInfoRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}