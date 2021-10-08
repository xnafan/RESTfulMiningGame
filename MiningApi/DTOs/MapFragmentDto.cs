using GenericDataAccessClassLibrary.Interfaces.Generic;
using System;
using System.Collections.Generic;

namespace MiningApi.Dtos
{
    public class MapFragmentDto : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public List<QuadrantDto> KnownQuadrants { get; set; }
    }
}