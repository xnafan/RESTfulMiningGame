using Microsoft.AspNetCore.Mvc;
using MiningDataAccessLayer.Interfaces;
using MiningDataAccessLayer.Model;
using System.Collections.Generic;

namespace MiningApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DigsController : ControllerBase
    {
        private readonly IMiningGameDao _dataAccess;

        public DigsController(IMiningGameDao dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public IEnumerable<MapSquare> GetKnownQuadrants()
        {
            return null;
        }
    }
}