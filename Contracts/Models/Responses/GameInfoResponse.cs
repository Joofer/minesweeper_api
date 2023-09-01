// ReSharper disable InconsistentNaming
namespace Contracts.Models.Responses;

public class GameInfoResponse
{
    public Guid game_id { get; set; }
    public uint width { get; set; }
    public uint height { get; set; }
    public uint mines_count { get; set; }
    public bool completed { get; set; }
    public List<List<string>> field { get; set; } = new();
}