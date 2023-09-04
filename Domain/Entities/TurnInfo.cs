using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TurnInfo
{
    [Key]
    public Guid Guid { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public DateTime DateTime { get; set; }
}