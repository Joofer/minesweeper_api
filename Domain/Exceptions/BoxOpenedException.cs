namespace Domain.Exceptions;

public sealed class BoxOpenedException : BadRequestException
{
    public BoxOpenedException(uint xPosition, uint yPosition) : base($"Bad request: ячейка ({xPosition}, {yPosition}) уже открыта.")
    {
    }
}