using System.Collections.Generic;
namespace MiningApi.Dtos;
public class MiningGameDto 
{
    public string Id { get; set; } 
    public string Name { get; set; }
    public List<string> TeamNames { get; set; } = new();
    public int MapSideLength { get; set; }
    public int InitialTeamFunding { get; set; }
    public int MapSquareProbePrice { get; set; }
}