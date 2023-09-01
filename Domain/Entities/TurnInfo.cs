namespace Domain.Entities;

public class TurnInfo
{
    public Guid Guid { get; set; }
    public uint Column { get; set; }
    public uint Row { get; set; }
}