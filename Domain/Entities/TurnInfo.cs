namespace Domain.Entities;

public class TurnInfo
{
    public Guid Guid { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public DateTime DateTime { get; set; }
}