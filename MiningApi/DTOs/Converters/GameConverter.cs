using GenericDataAccessClassLibrary;
using MiningApi.Dtos;
using MiningClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class GameConverter
    {

        public static Game FromDto(this GameDto gameDto)
        {
            return new Game() { Id = gameDto.Id, Name = gameDto.Name };
        }
        public static GameDto ToDto(this Game game)
        {
            var gameDto = game.CopyPropertiesTo(new GameDto());
            gameDto.TeamNames = game.Teams.Select(team => team.Name);
            return gameDto;

        }

        public static IEnumerable<Game> FromDtos(this IEnumerable<GameDto> gameDtos)
        {
            return gameDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<GameDto> ToDtos(this IEnumerable<Game> games)
        {
            return games.Select(dto => dto.ToDto());
        }
    }
}