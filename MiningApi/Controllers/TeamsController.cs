using Microsoft.AspNetCore.Mvc;
using MiningApi.Authentication;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace MiningApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private ITeamDao _teamDao;
    private IMiningGameDao _miningGameDao;
    public TeamsController(ITeamDao teamDao, IMiningGameDao miningGameDao)
    {
        _teamDao = teamDao;
        _miningGameDao = miningGameDao;
    }

    [ApiKeyAuthenticate]
    [HttpGet]
    public ActionResult<IEnumerable<TeamDto>> Get()
    {
        return Ok(_teamDao.GetAll().ToDtos());
    }

    [HttpGet("/api/games/{gameId}/teams/{teamId}/accesstoken")]
    public ActionResult<string> GetAccessToken(string gameId, string teamId)
    {
        return Ok(TokenAuthenticationTool.GenerateToken(gameId, teamId));
    }

    [ApiKeyAuthenticate]
    [HttpGet("/api/games/{gameId}/teams")]
    public ActionResult<string> GetTeamsForGame(string gameId)
    {
        return Ok(_miningGameDao.GetById(gameId).Teams);
    }

    [ApiKeyAuthenticate]
    [HttpGet("{id}")]
    public ActionResult<TeamDto> Get(string id)
    {
        return Ok(_teamDao.GetById(id).ToDto());
    }

    [ApiKeyAuthenticate]
    [HttpPost]
    public ActionResult Post([FromBody] TeamDto teamToAdd)
    {
       return Ok( _teamDao.Add(teamToAdd.FromDto()));
    }


    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] TeamDto teamToUpdate)
    {
        if (_teamDao.Update(teamToUpdate.FromDto()))
        {
            return Ok();
        }
        return NotFound();
        
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        if (_teamDao.Delete(id))
        {
            return Ok();
        }
        return NotFound();
    }
}