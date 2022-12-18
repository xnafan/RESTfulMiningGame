using Microsoft.AspNetCore.Mvc;
using MiningApi.Authentication;
using MiningApi.Dtos;
using MiningApi.DTOs.Converters;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;
using System.Net;

namespace MiningApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionsController : ControllerBase
{
    IMiningGameDao _miningGameDao;
    IAuctionDao _auctionDao;
    ITeamDao _teamDao;

    public AuctionsController(IAuctionDao auctionDao, IMiningGameDao miningDao, ITeamDao teamDao)
    {
        _miningGameDao = miningDao;
        _auctionDao = auctionDao;
        _teamDao = teamDao;
    }

    [HttpGet("games/{gameId}/auctions")]
    public IEnumerable<Auction> Get(string gameId)
    {
        return _miningGameDao.GetById(gameId).Auctions;
    }

    [HttpGet("{id}")]
    public Auction Get(int id)
    {
        return _auctionDao.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromHeader(Name=TokenAuthenticationTool.HEADER_NAME)] string authenticationToken, [FromBody] AuctionDto auctionDto)
    {
        if (!TokenAuthenticationTool.ValidateToken(authenticationToken))
        {
            var auction = auctionDto.FromDto();
            var gameAndTeamInfo = TokenAuthenticationTool.Parse(authenticationToken);
            _miningGameDao.GetById(gameAndTeamInfo.GameId).Auctions.Add(auction);
            _auctionDao.Add(auction);
            return Ok();
        }
        return Unauthorized();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] AuctionDto auction) => _auctionDao.Update(auction.FromDto());

    [HttpDelete("{id}")]
    public void Delete(int id) => _auctionDao.Delete(id);
}