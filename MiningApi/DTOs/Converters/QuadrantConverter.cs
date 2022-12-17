using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class QuadrantConverter
    {

        public static MapSquare FromDto(this MapSquareDto quadrantDto)
        {
            return quadrantDto.CopyPropertiesTo(new MapSquare());
        }
        public static MapSquareDto ToDto(this MapSquare quadrant)
        {
            return quadrant.CopyPropertiesTo(new MapSquareDto());
        }

        public static IEnumerable<MapSquare> FromDtos(this IEnumerable<MapSquareDto> quadrantDtos)
        {
            return quadrantDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<MapSquareDto> ToDtos(this IEnumerable<MapSquare> quadrants)
        {
            return quadrants.Select(dto => dto.ToDto());
        }
    }
}