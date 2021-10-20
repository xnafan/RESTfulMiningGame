using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningDataAccessLayer.Model
{
    public class Auction : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Team SellerTeam { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Price { get; set; }
    }
}