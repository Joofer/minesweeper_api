using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class GameInfo
{
    [Key]
    public Guid Guid { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int MinesCount { get; set; }
    public bool Completed { get; set; }
    public List<List<int>> Field { get; set; } = new();
    public List<List<int>> OriginField { get; set; } = new();
    public List<TurnInfo> TurnInfos { get; set; } = new();
}