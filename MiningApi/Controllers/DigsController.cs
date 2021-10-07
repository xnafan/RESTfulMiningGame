using Microsoft.AspNetCore.Mvc;
using MiningClassLibrary;
using MiningDataAccessLayer;
using System.Collections.Generic;

namespace MiningApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DigsController : ControllerBase
    {
        private readonly IGameDataAccess _dataAccess;

        public DigsController(IGameDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public IEnumerable<Quadrant> GetKnownQuadrants()
        {
            return null;
        }



    }
}
