using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class QuadrantConverter
    {

        public static Quadrant FromDto(this QuadrantDto quadrantDto)
        {
            return quadrantDto.CopyPropertiesTo(new Quadrant());
        }
        public static QuadrantDto ToDto(this Quadrant quadrant)
        {
            return quadrant.CopyPropertiesTo(new QuadrantDto());
        }

        public static IEnumerable<Quadrant> FromDtos(this IEnumerable<QuadrantDto> quadrantDtos)
        {
            return quadrantDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<QuadrantDto> ToDtos(this IEnumerable<Quadrant> quadrants)
        {
            return quadrants.Select(dto => dto.ToDto());
        }
    }
}