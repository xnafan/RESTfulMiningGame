using GenericDaoLibrary.Interfaces;
using MiningDataAccessLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningDataAccessLayer.Model;
public class MiningGame : IIdentifiable<string>
{
    #region Properties
    public string Id { get; set; } = ShortUIDTool.CreateShortId();
    public string Name { get; set; } = "Unnamed";
    public List<Team> Teams { get; set; } = new();
    public int MapSideLength { get; private set; } = 32;
    public int MapSquareProbePrice { get; set; } = 50;
    public int[,] MapSquareValues { get; set; }
    public int GetMapSquareValue(int column, int row)
    {
        if (!MapContainsCoordinate(column, row))
        {
            throw new ArgumentOutOfRangeException($"MapSquare ({column},{row}) was outside the game's map size [{MapSideLength},{MapSideLength}]");
        }
        return MapSquareValues[column, row];
    }
    public int InitialTeamFunding { get; set; } = 1000;
    #endregion

    #region Constructors
    public MiningGame(string id, string name, int mapSideLength = 32) : this()
    {
        Id = id;
        Name = name;
        MapSideLength = mapSideLength;
    }

    public MiningGame() => MapSquareValues = GenerateMap();

    #endregion

    #region Methods
    private int[,] GenerateMap()
    {
        Random random = new(Id.ToIntHash());
        int[,] map = new int[MapSideLength, MapSideLength];
        for (int i = 0; i < MapSideLength * MapSideLength / 5; i++)
        {
            map[random.Next(MapSideLength), random.Next(MapSideLength)] = random.Next(100);
        }
        return map.Smooth(10).ScaleValues(0,100);
    }

    private bool MapContainsCoordinate(int x, int y)
    {
        return x >= 0 && y >= 0 && x < MapSideLength && y < MapSideLength;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int y = 0; y < MapSideLength; y++)
        {
            for (int x = 0; x < MapSideLength; x++)
            {
                builder.Append(GetMapSquareValue(x, y).ToString("000") + ",");
            }
            builder.AppendLine();
        }
        return builder.ToString();
    } 
    #endregion

}