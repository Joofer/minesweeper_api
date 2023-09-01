// ReSharper disable InconsistentNaming
namespace Contracts.Requests;

public class GameTurnRequest
{
    public Guid game_id { get; set; }
    public int col { get; set; }
    public int row { get; set; }
}