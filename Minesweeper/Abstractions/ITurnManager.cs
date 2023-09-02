namespace Minesweeper.Abstractions;

public interface ITurnManager
{
    static abstract int Open(List<List<int>> field, List<List<int>> originField, int minesCount, int xPosition, int yPosition);
}