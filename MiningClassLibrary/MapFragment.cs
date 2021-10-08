using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class MapFragment : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public List<Quadrant> KnownQuadrants { get; set; }
    }
}