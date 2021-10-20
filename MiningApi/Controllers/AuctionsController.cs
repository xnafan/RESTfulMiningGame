using Microsoft.AspNetCore.Mvc;
using MiningClassLibrary;
using MiningDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiningApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        IAuctionDataAccess _dataAccess;

        public AuctionsController(IAuctionDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/<AuctionsController>
        [HttpGet]
        public IEnumerable<Auction> Get()
        {
            return _dataAccess.GetAll();
        }

        // GET api/<AuctionsController>/5
        [HttpGet("{id}")]
        public Auction Get(Guid id)
        {
            return _dataAccess.GetById(id);
        }

        // POST api/<AuctionsController>
        [HttpPost]
        public void Post([FromBody] Auction auction)
        {
            _dataAccess.Add(auction);
        }

        // PUT api/<AuctionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Auction auction)
        {
            _dataAccess.Update(auction);
        }

        // DELETE api/<AuctionsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _dataAccess.Delete(id);
        }
    }
}