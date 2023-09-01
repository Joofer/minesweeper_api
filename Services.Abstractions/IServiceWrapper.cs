namespace Services.Abstractions;

public interface IServiceWrapper
{
    public IGameInfoService GameInfoService { get; }
    public ITurnInfoService TurnInfoService { get; }
}