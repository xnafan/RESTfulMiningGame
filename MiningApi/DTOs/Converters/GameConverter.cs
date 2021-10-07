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
            return new GameDto() { Id = game.Id, Name = game.Name };
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