using GenericDaoLibrary;
using Microsoft.AspNetCore.Mvc;
using MiningApi.Authentication;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
namespace MiningApi.Controllers;

[ApiKeyAuthenticate]
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private IMiningGameDao _gameDataAccess;
    public GamesController(IMiningGameDao gameDataAccess) => _gameDataAccess = gameDataAccess;

    [HttpGet]
    public ActionResult<IEnumerable<MiningGameDto>> Get() => Ok(_gameDataAccess.GetAll().ToDtos());

    [HttpGet("{id}")]
    public ActionResult<MiningGameDto> Get(string id) => Ok(_gameDataAccess.GetById(id).ToDto());

    [HttpPost]
    public ActionResult Post([FromBody] MiningGameDto gameToAdd) => Ok(_gameDataAccess.Add(gameToAdd.FromDto()));

    [HttpPut]
    public ActionResult Put([FromBody] MiningGameDto gameToUpdate)
    {
        if (_gameDataAccess.Update(gameToUpdate.FromDto()))
        {
            return Ok();
        }
        return NotFound();
        
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        if (_gameDataAccess.Delete(id))
        {
            return Ok();
        }
        return NotFound();
    }
}