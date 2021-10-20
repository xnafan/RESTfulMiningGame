using System;
using System.Collections.Generic;

namespace ServiceClientClassLibrary.Model
{
    public class Game 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> TeamNames { get; set; } = new();
        public int GameAreaHeightInQuadrants { get; set; }
        public int GameAreaWidthInQuadrants { get; set; }
        public int Seed { get; set; }
    }
}