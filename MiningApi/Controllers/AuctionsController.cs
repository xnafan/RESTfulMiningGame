using Microsoft.AspNetCore.Mvc;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;

namespace MiningApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        IMapSquareDao _dataAccess;

        public AuctionsController(IMapSquareDao dataAccess) => _dataAccess = dataAccess;

        [HttpGet]
        public IEnumerable<Auction> Get(string gameUid)
        {
            return _dataAccess.GetAll();
        }

        // GET api/<AuctionsController>/5
        [HttpGet("{id}")]
        public Auction Get(int id)
        {
            return _dataAccess.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Auction auction) => _dataAccess.Add(auction);

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Auction auction) => _dataAccess.Update(auction);

        [HttpDelete("{id}")]
        public void Delete(int id) => _dataAccess.Delete(id);
    }
}