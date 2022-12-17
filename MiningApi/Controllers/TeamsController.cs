using Microsoft.AspNetCore.Mvc;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;


namespace MiningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private ITeamDao _teamDataAccess;

        public TeamsController(ITeamDao teamDataAccess) => _teamDataAccess = teamDataAccess;

        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> Get()
        {
            return Ok(_teamDataAccess.GetAll().ToDtos());
        }

        [HttpGet("{id}")]
        public ActionResult<TeamDto> Get(Guid id)
        {
            return Ok(_teamDataAccess.GetById(id).ToDto());
        }

        [HttpPost]
        public ActionResult Post([FromBody] TeamDto teamToAdd)
        {
           return Ok( _teamDataAccess.Add(teamToAdd.FromDto()));

        }

        [HttpPut]
        public ActionResult Put([FromBody] TeamDto teamToUpdate)
        {
            if (_teamDataAccess.Update(teamToUpdate.FromDto()))
            {
                return Ok();
            }
            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (_teamDataAccess.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}