using System;
using System.Collections.Generic;

namespace MiningApi.Dtos
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AccountBalance { get; set; }
        public IEnumerable<QuadrantDto> KnownQuadrants { get; set; } = new List<QuadrantDto>();
    }
}