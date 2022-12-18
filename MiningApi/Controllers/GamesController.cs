using Microsoft.AspNetCore.Mvc;
using MiningApi.Authentication;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer.Extensions;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MiningApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private IMiningGameDao _gameDao;
    private ITeamDao _teamDao;
    public GamesController(IMiningGameDao gameDao, ITeamDao teamDao)
    {
        _gameDao = gameDao;
        _teamDao = teamDao;
    }

    [HttpGet]
    [ApiKeyAuthenticate]
    public ActionResult<IEnumerable<MiningGameDto>> Get() => Ok(_gameDao.GetAll().ToDtos());

    [HttpGet("{gameId}/mapsquares")]
    [ApiKeyAuthenticate]
    public ActionResult<IEnumerable<MapSquareDto>> GetMap(string gameId)
    {
        var game = _gameDao.GetById(gameId);
        var mapSquareDtos = game.MapSquareValues.GetAllPositions().Select(tile => new MapSquareDto() { X = tile.X, Y = tile.Y, Value = game.MapSquareValues[tile.X, tile.Y] }).ToList();
        return Ok(mapSquareDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<MiningGameDto> Get(string id) => Ok(_gameDao.GetById(id).ToDto());

    [HttpPost]
    [ApiKeyAuthenticate]
    public ActionResult Post([FromBody] MiningGameDto gameToAdd) => Ok(_gameDao.Add(gameToAdd.FromDto()));

    [HttpPost("{gameId}/explore/{x}/{y}")]
    public ActionResult<MapSquareDto> Explore([FromHeader(Name = TokenAuthenticationTool.HEADER_NAME)] string authenticationToken, int x, int y)
    {
        var gameAndTeamInfo = TokenAuthenticationTool.Parse(authenticationToken);

        var game = _gameDao.GetById(gameAndTeamInfo.GameId);
        if(x < 0 || y < 0 || x >= game.MapSideLength || y >= game.MapSideLength)
        {
            return BadRequest($"Coordinate ({x},{y}) was outside the map");
        }

        var team = _teamDao.GetById(gameAndTeamInfo.TeamId);

        if(team.AccountBalance < game.MapSquareProbePrice)
        {
            return BadRequest($"Insufficient balance in team account. Current balance is {team.AccountBalance} and price for exploring map square is {game.MapSquareProbePrice}");
        }

        var mapSquareValue = game.GetMapSquareValue(x, y);
        var mapSquare = new MapSquare() { Value = mapSquareValue, X = x, Y = y };
        team.KnownMapSquares.Add(mapSquare);
        team.AccountBalance -= game.MapSquareProbePrice;
        _teamDao.Update(team);

        return Ok(mapSquare);
    }

    [HttpPut]
    [ApiKeyAuthenticate]
    public ActionResult Put([FromBody] MiningGameDto gameToUpdate)
    {
        if (_gameDao.Update(gameToUpdate.FromDto()))
        {
            return Ok();
        }
        return NotFound();
        
    }

    [HttpDelete("{id}")]
    [ApiKeyAuthenticate]
    public ActionResult Delete(string id)
    {
        if (_gameDao.Delete(id))
        {
            return Ok();
        }
        return NotFound();
    }
}