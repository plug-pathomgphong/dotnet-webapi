using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactorController : ControllerBase
    {
        private static List<Charactor> charactors = new List<Charactor>{
            new Charactor(),
            new Charactor{Name= "Sam"}
        };

        [HttpGet("GetAll")] // Set route name and swagger
        public ActionResult<List<Charactor>> Get()
        {
            return Ok(charactors);
        }

        [HttpGet] // For swagger generate
        public ActionResult<Charactor> GetSingle()
        {
            return Ok(charactors[0]);
        }
    }
}