using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class Team : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public List<Quadrant> KnownQuadrants { get; set; } = new List<Quadrant>();
    }
}