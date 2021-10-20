using System;
using System.Collections.Generic;

namespace ServiceClientClassLibrary.Model
{
    public class Auction 
    {
        public Guid Id { get; set; }
        public Team SellerTeam { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Price { get; set; }
    }
}