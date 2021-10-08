using GenericDataAccessClassLibrary;
using MiningApi.Dtos;
using MiningClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.DTOs.Converters
{
    public static class TeamConverter
    {
        public static Team FromDto(this TeamDto teamDto)
        {
            return teamDto.CopyPropertiesTo(new Team()); ;
        }
        public static TeamDto ToDto(this Team team)
        {
            var teamDto = team.CopyPropertiesTo(new TeamDto());
            teamDto.KnownQuadrants.AddRange(team.KnownQuadrants.ToDtos());
            return teamDto;
        }

        public static IEnumerable<Team> FromDtos(this IEnumerable<TeamDto> teamDtos)
        {
            return teamDtos.Select(dto => dto.FromDto());
        }
        public static IEnumerable<TeamDto> ToDtos(this IEnumerable<Team> teams)
        {
            return teams.Select(dto => dto.ToDto());
        }
    }
}