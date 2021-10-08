using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningApi.Dtos
{
    public class AuctionDto : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public Guid SellerTeamId { get; set; }
        public List<QuadrantDto> Quadrants { get; set; }
    }
}