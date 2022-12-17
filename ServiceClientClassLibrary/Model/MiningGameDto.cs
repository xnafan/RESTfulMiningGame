using System;
using System.Collections.Generic;

namespace ServiceClientClassLibrary.Model
{
    public class MiningGameDto 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> TeamNames { get; set; } = new();
        public int MapSideLength { get; set; }
    }
}