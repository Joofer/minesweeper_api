using CollectionManager;
using Mapster;
using Minesweeper.Game.Core.Abstractions;
using Minesweeper.Game.Core.Exceptions;

namespace Minesweeper.Game.Core;

public class TurnManager : ITurnManager
{
    /// <summary>
    /// Делает ход в ячейке (xPosition, yPosition).
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    /// <param name="minesCount">количество мин</param>
    /// <param name="xPosition">позиция ячейки x</param>
    /// <param name="yPosition">позиция ячейки y</param>
    /// <returns>true, если в ячейке есть мина, иначе - false</returns>
    public static int Turn(List<List<int>> field, List<List<int>> originField, int minesCount, int xPosition,
        int yPosition)
    {
        var result = Open(field, originField, minesCount, xPosition, yPosition);
        if (result == (int)TurnResponseCode.End)
            Reveal(field, originField);
        return result;
    }

    /// <summary>
    /// Открывает ячейку (xPosition, yPosition).
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    /// <param name="minesCount">количество мин</param>
    /// <param name="xPosition">позиция ячейки x</param>
    /// <param name="yPosition">позиция ячейки y</param>
    /// <returns>true, если в ячейке есть мина, иначе - false</returns>
    private static int Open(List<List<int>> field, List<List<int>> originField, int minesCount, int xPosition, int yPosition)
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
    /// Открывает все ячейки.
    /// </summary>
    /// <param name="field">игровое поле</param>
    /// <param name="originField">полное поле</param>
    private static void Reveal(IReadOnlyList<List<int>> field, IReadOnlyList<List<int>> originField)
    {
        for (var i = 0; i < field.Count; i++)
            for (var j = 0; j < field[0].Count; j++)
                field[i][j] = originField[i][j];
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