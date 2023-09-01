// ReSharper disable InconsistentNaming
namespace Contracts.Models.Requests;

public class GameTurnRequest
{
    public Guid game_id { get; set; }
    public uint col { get; set; }
    public uint row { get; set; }
}