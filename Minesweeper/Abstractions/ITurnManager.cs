namespace Minesweeper.Abstractions;

public interface ITurnManager
{
    static abstract bool Open(List<List<string>> field, List<List<string>> originField, int xPosition, int yPosition);
}