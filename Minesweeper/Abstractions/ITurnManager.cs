namespace Minesweeper.Abstractions;

public interface ITurnManager
{
    /// <summary>
    /// Открывает ячейку (xPosition, yPosition).
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    /// <param name="xPosition">позиция ячейки x</param>
    /// <param name="yPosition">позиция ячейки y</param>
    /// <returns>true, если в ячейке есть мина, иначе - false</returns>
    static abstract bool Open(List<List<string>> field, List<List<string>> originField, int xPosition, int yPosition);
}