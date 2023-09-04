using Minesweeper.Abstractions;
using Minesweeper.Exceptions;

namespace Minesweeper;

public class TurnManager : ITurnManager
{
    /// <summary>
    /// Открывает ячейку (xPosition, yPosition).
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    /// <param name="minesCount">количество мин</param>
    /// <param name="xPosition">позиция ячейки x</param>
    /// <param name="yPosition">позиция ячейки y</param>
    /// <returns>true, если в ячейке есть мина, иначе - false</returns>
    public static int Open(List<List<int>> field, List<List<int>> originField, int minesCount, int xPosition, int yPosition)
    {
        if (IsOpened(field, yPosition, xPosition)) throw new BoxOpenedException(xPosition, yPosition);

        field[yPosition][xPosition] = originField[yPosition][xPosition];

        switch (field[yPosition][xPosition])
        {
            case 0:
                try { Open(field, originField, minesCount, xPosition - 1, yPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition - 1, yPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition, yPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition + 1, yPosition + 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition + 1, yPosition); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition + 1, yPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                try { Open(field, originField, minesCount, xPosition, yPosition - 1); }
                catch (Exception)
                {
                    // ignore
                }
                break;

            case (int)BoxType.Mine:
                return (int)TurnResponseCode.Mine;
        }

        return IsEnded(field, minesCount) ? (int)TurnResponseCode.End : (int)TurnResponseCode.Ok;
    }

    /// <summary>
    /// Проверяет открыты ли все ячейки, кроме ячеек с минами.
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="minesCount">количество мин</param>
    /// <returns></returns>
    private static bool IsEnded(IReadOnlyList<List<int>> field, int minesCount)
    {
        return field.SelectMany(x => x).Count(x => x != (int)BoxType.Closed) == field.Count * field[0].Count - minesCount;
    }

    /// <summary>
    /// Проверяет открыта ли ячейка.
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="yPosition">позиция ячейки y</param>
    /// <param name="xPosition">позиция ячейки x</param>
    /// <returns></returns>
    private static bool IsOpened(IReadOnlyList<List<int>> field, int yPosition, int xPosition)
    {
        return field[yPosition][xPosition] != (int)BoxType.Closed;
    }
}