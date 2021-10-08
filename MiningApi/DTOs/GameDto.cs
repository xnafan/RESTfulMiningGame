using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningApi.Dtos
{
    public class GameDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GameAreaHeightInQuadrants { get; set; }
        public int GameAreaWidthInQuadrants { get; set; }
        public IEnumerable<string> TeamNames { get; set; }
    }
}