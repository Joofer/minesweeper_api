// ReSharper disable InconsistentNaming
namespace Contracts.Models.Requests;

public class NewGameRequest
{
    public uint width { get; set; }
    public uint height { get; set; }
    public uint mines_count { get; set; }
}