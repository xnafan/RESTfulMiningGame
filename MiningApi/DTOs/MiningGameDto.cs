using GenericDaoLibrary;
using System.Collections.Generic;
namespace MiningApi.Dtos;
public class MiningGameDto 
{
    public string Id { get; set; } = ShortUIDTool.CreateShortId();
    public string Name { get; set; }
    public List<TeamDto> Teams { get; set; } = new();
    public int MapRowCount { get; set; }
    public int MapColumnCount { get; set; }
    public int Seed { get; set; }
}