using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningClassLibrary
{
    public class Auction : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Team SellerTeam { get; set; }
        public List<Quadrant> Quadrants { get; set; }
        public int Price { get; set; }
    }
}