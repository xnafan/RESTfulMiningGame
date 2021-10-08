using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class Game : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public int AreaHeightInQuadrants { get; set; }
        public int AreaWidthInQuadrants { get; set; }
        public int Seed { get; set; }
    }
}