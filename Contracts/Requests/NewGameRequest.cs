// ReSharper disable InconsistentNaming
namespace Contracts.Requests;

public class NewGameRequest
{
    public required int width { get; set; }
    public required int height { get; set; }
    public required int mines_count { get; set; }
}