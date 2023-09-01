using CollectionManager;
using Minesweeper.Abstractions;

namespace Minesweeper;

public class GameManager : IGameManager
{
    public static List<List<string>> CreateGame(int width, int height, int minesCount)
    {
        var field = List2d<int>.Identity(height, width);
        Populate(field, minesCount);
        return List2d<int>.ToStringType(field);
    }

    /// <summary>
    /// Заполнить игровое поле minesCount минами.
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="minesCount">количество мин</param>
    private static void Populate(IReadOnlyList<List<int>> field, int minesCount)
    {
        Random rnd = new();
        var k = 0;
        while (k < minesCount)
        {
            var xPosition = rnd.Next(field[0].Count);
            var yPosition = rnd.Next(field.Count);

            if (field[xPosition][yPosition] == -1) continue;

            field[xPosition][yPosition] = -1;
            IncreaseNeighbors(field, xPosition, yPosition);
            k++;
        }
    }

    /// <summary>
    /// Увеличить число в соседних клетках на 1.
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="xPosition">позиция x</param>
    /// <param name="yPosition">позиция y</param>
    private static void IncreaseNeighbors(IReadOnlyList<List<int>> field, int xPosition, int yPosition)
    {
        try { field[xPosition - 1][yPosition - 1] += field[xPosition - 1][yPosition - 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition - 1][yPosition] += field[xPosition - 1][yPosition] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition - 1][yPosition + 1] += field[xPosition - 1][yPosition + 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition][yPosition + 1] += field[xPosition][yPosition + 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition + 1][yPosition + 1] += field[xPosition + 1][yPosition + 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition + 1][yPosition] += field[xPosition + 1][yPosition] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition + 1][yPosition - 1] += field[xPosition + 1][yPosition - 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
        try { field[xPosition][yPosition - 1] += field[xPosition][yPosition - 1] >= 0 ? 1 : 0; }
        catch (Exception)
        {
            // ignore
        }
    }
}