namespace Domain.Entities;

public class GameInfo
{
    public Guid Guid { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int MinesCount { get; set; }
    public bool Completed { get; set; }
    public List<List<string>> Field { get; set; } = new();
    public List<List<string>> OriginField { get; set; } = new();
    public List<TurnInfo> TurnInfos { get; set; } = new();
}