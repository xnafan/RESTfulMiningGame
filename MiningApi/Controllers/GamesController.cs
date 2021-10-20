using Microsoft.AspNetCore.Mvc;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer;
using System;
using System.Collections.Generic;


namespace MiningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private IGameDataAccess _gameDataAccess;

        public GamesController(IGameDataAccess gameDataAccess)
        {
            _gameDataAccess = gameDataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> Get()
        {
            return Ok(_gameDataAccess.GetAll().ToDtos());
        }

        [HttpGet("{id}")]
        public ActionResult<GameDto> Get(Guid id)
        {
            return Ok(_gameDataAccess.GetById(id).ToDto());
        }

        [HttpPost]
        public ActionResult Post([FromBody] GameDto gameToAdd)
        {
           return Ok( _gameDataAccess.Add(gameToAdd.FromDto()));

        }

        [HttpPut]
        public ActionResult Put([FromBody] GameDto gameToUpdate)
        {
            if (_gameDataAccess.Update(gameToUpdate.FromDto()))
            {
                return Ok();
            }
            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (_gameDataAccess.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}