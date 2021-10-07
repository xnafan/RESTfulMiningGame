using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class Auction : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid SellerTeamId { get; set; }
        public List<Quadrant> KnownQuadrants { get; set; }
        public int Price { get; set; }
    }
}