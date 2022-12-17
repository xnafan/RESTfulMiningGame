using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class GameConverter
    {

        public static MiningGame FromDto(this MiningGameDto gameDto)
        {
            return gameDto.CopyPropertiesTo(new MiningGame());
        }
        public static MiningGameDto ToDto(this MiningGame game)
        {
            var gameDto = game.CopyPropertiesTo(new MiningGameDto());
           // gameDto.TeamNames = game.Teams.Select(team => team.Name);
            return gameDto;
        }

        public static IEnumerable<MiningGame> FromDtos(this IEnumerable<MiningGameDto> gameDtos)
        {
            return gameDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<MiningGameDto> ToDtos(this IEnumerable<MiningGame> games)
        {
            return games.Select(dto => dto.ToDto());
        }
    }
}