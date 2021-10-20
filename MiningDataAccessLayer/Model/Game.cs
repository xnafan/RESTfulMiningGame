using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningDataAccessLayer.Model
{
    public class Game : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; } = new();
        public int GameAreaHeightInQuadrants { get; set; }
        public int GameAreaWidthInQuadrants { get; set; }
        public int Seed { get; set; }
    }
}