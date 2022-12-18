using GenericDaoLibrary;
using GenericDaoLibrary.Interfaces;
using System.Collections.Generic;
namespace MiningDataAccessLayer.Model;
public class Team : IIdentifiable<string>
{
    public string Id { get; set; } = ShortUIDTool.CreateShortId();
    public string Name { get; set; }
    public int AccountBalance { get; set; }
    public List<MapSquare> KnownMapSquares { get; set; } = new();
}