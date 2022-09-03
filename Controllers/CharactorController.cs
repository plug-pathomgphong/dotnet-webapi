using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Services.CharactorService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactorController : ControllerBase
    {
        private readonly ICharactorService _charactorService;
        public CharactorController(ICharactorService charactorService)
        {
            _charactorService = charactorService; // this.charactorService = charactorService
            
        }
        [HttpGet("GetAll")] // Set route name and swagger
        public ActionResult<List<Charactor>> Get()
        {
            return Ok(_charactorService.GetAllCharactor());
        }

        [HttpGet("{id}")] // For swagger generate
        public ActionResult<Charactor> GetSingle(int id)
        {
            return Ok(_charactorService.GetCharactorById(id));
        }
        [HttpPost] // For swagger generate
        public ActionResult<List<Charactor>> AddCharactor(Charactor newCharactor)
        {
            return Ok(_charactorService.AddCharactor(newCharactor));
        }

    }
}