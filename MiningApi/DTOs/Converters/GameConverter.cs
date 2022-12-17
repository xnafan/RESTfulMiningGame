using GenericDaoLibrary;
using MiningApi.Dtos;
using MiningDataAccessLayer.Extensions;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class GameConverter
    {

        public static MiningGame FromDto(this MiningGameDto gameDto)
        {
            var game = gameDto?.CopyPropertiesTo(new MiningGame());
            gameDto.MapSquares.ForEach(square => game.MapSquareValues[square.X, square.Y] = square.Value);
            return game;
        }
        public static MiningGameDto ToDto(this MiningGame game)
        {
            var gameDto = game?.CopyPropertiesTo(new MiningGameDto());
            gameDto.MapSquares = game.MapSquareValues.GetAllPositions().Select(tile => new MapSquareDto() {X = tile.X, Y = tile.Y, Value = game.MapSquareValues[tile.X, tile.Y]}).ToList();
            //gameDto.TeamNames = Teams.Select(team => team.Name);
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