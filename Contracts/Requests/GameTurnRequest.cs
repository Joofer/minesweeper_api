// ReSharper disable InconsistentNaming
namespace Contracts.Requests;

public class GameTurnRequest
{
    public required Guid game_id { get; set; }
    public required int col { get; set; }
    public required int row { get; set; }
}