using Domain.Entities;

namespace Domain.Exceptions;

public sealed class TurnInfoNotFoundException : NotFoundException
{
    public TurnInfoNotFoundException(object keyValue) : base($"Not found: объект {nameof(TurnInfo)} с идентификатором {keyValue} не найден.")
    {
    }
}