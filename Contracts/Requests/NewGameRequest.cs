// ReSharper disable InconsistentNaming
namespace Contracts.Requests;

public class NewGameRequest
{
    public int width { get; set; }
    public int height { get; set; }
    public int mines_count { get; set; }
}