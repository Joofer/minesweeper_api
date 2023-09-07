using Domain.Entities;
using Mapster;

namespace Common;

public class GameInfoSamples
{
    private static readonly GameInfo GameInfoA = new()
    {
        Width = 10,
        Height = 10,
        MinesCount = 10,
        Completed = false,
        Field = new List<List<int>>
        {
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 }
        },
        OriginField = new List<List<int>>
        {
            new() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new() { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new() { 0, 1, -1, 1, 1, 1, 1, 1, 1, 1 },
            new() { 0, 1, 1, 1, 1, -1, 2, 2, -1, 1 },
            new() { 0, 0, 0, 0, 1, 1, 2, -1, 2, 1 },
            new() { 0, 0, 0, 0, 0, 0, 2, 2, 2, 0 },
            new() { 1, 1, 0, 0, 1, 2, 3, -1, 2, 1 },
            new() { -1, 2, 0, 0, 1, -1, -1, 2, 2, -1 },
            new() { -1, 2, 0, 0, 1, 2, 2, 1, 1, 1 },
            new() { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        }
    };
    private static readonly GameInfo GameInfoB = new()
    {
        Width = 10,
        Height = 10,
        MinesCount = 10,
        Completed = false,
        Field = new List<List<int>>
        {
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 },
            new() { -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 }
        },
        OriginField = new List<List<int>>
        {
            new() { 0, 1, -1, 1, 0, 1, 1, 1, 0, 0 },
            new() { 0, 1, 1, 1, 0, 1, -1, 1, 1, 1 },
            new() { 1, 1, 0, 0, 0, 1, 1, 1, 1, -1 },
            new() { -1, 2, 1, 1, 0, 0, 0, 0, 1, 1 },
            new() { 1, 2, -1, 1, 0, 0, 0, 0, 0, 0 },
            new() { 0, 1, 2, 3, 2, 1, 1, 1, 1, 0 },
            new() { 0, 0, 1, -1, -1, 1, 2, -1, 2, 0 },
            new() { 0, 1, 2, 3, 2, 1, 2, -1, 2, 0 },
            new() { 0, 1, -1, 1, 0, 0, 1, 1, 1, 0 },
            new() { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 }
        }
    };

    public static GameInfo GetA()
    {
        var gameInfo = GameInfoA.Adapt<GameInfo>();
        gameInfo.Guid = Guid.NewGuid();
        return gameInfo;
    }

    public static GameInfo GetB()
    {
        var gameInfo = GameInfoB.Adapt<GameInfo>();
        gameInfo.Guid = Guid.NewGuid();
        return gameInfo;
    }
}