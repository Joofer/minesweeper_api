namespace Domain.Entities;

public class GameInfo
{
    public Guid Guid { get; set; }
    public uint Width { get; set; }
    public uint Height { get; set; }
    public uint MinesCount { get; set; }
    public bool Completed { get; set; }
    public List<List<string>> Field { get; set; } = new();
    public List<TurnInfo> TurnInfos { get; set; } = new();
}