using System;
using System.Collections.Generic;

namespace ServiceClientClassLibrary.Model
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public List<MapSquareDto> KnownMapSquares{ get; set; } = new();
    }
}