using System.Collections.Generic;
namespace MiningApi.Dtos;
public class TeamDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int AccountBalance { get; set; }
    public List<MapSquareDto> KnownMapSquares { get; set; } = new List<MapSquareDto>();
}