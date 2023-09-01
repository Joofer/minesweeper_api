namespace Domain.RepositoryAbstractions;

public interface IRepositoryWrapper
{
    public IGameInfoRepository GameInfoRepository { get; set; }
    public ITurnInfoRepository TurnInfoRepository { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}