using System;
using System.Collections.Generic;

namespace ServiceClientClassLibrary.Model
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public List<Quadrant> KnownQuadrants { get; set; } = new();
    }
}