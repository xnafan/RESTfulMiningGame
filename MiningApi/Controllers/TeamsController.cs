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
    private ITeamDao _teamDataAccess;

    public TeamsController(ITeamDao teamDataAccess) => _teamDataAccess = teamDataAccess;

    [ApiKeyAuthenticate]
    [HttpGet]
    public ActionResult<IEnumerable<TeamDto>> Get()
    {
        return Ok(_teamDataAccess.GetAll().ToDtos());
    }

    [ApiKeyAuthenticate]
    [HttpGet("{id}")]
    public ActionResult<TeamDto> Get(string id)
    {
        return Ok(_teamDataAccess.GetById(id).ToDto());
    }

    [ApiKeyAuthenticate]
    [HttpPost]
    public ActionResult Post([FromBody] TeamDto teamToAdd)
    {
       return Ok( _teamDataAccess.Add(teamToAdd.FromDto()));
    }


    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] TeamDto teamToUpdate)
    {
        if (_teamDataAccess.Update(teamToUpdate.FromDto()))
        {
            return Ok();
        }
        return NotFound();
        
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        if (_teamDataAccess.Delete(id))
        {
            return Ok();
        }
        return NotFound();
    }
}