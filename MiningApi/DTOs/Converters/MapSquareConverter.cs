using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class MapSquareConverter
    {

        public static MapSquare FromDto(this MapSquareDto mapSquareDto)
        {
            return mapSquareDto.CopyPropertiesTo(new MapSquare());
        }
        public static MapSquareDto ToDto(this MapSquare mapSquare)
        {
            return mapSquare.CopyPropertiesTo(new MapSquareDto());
        }

        public static IEnumerable<MapSquare> FromDtos(this IEnumerable<MapSquareDto> mapSquareDtos)
        {
            return mapSquareDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<MapSquareDto> ToDtos(this IEnumerable<MapSquare> mapSquares)
        {
            return mapSquares.Select(dto => dto.ToDto());
        }
    }
}