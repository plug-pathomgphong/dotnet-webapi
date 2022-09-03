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
        public async Task<ActionResult<ServiceResponse<List<Charactor>>>> Get()
        {
            return Ok(await _charactorService.GetAllCharactor());
        }

        [HttpGet("{id}")] // For swagger generate
        public async Task<ActionResult<ServiceResponse<Charactor>>> GetSingle(int id)
        {
            return Ok(await _charactorService.GetCharactorById(id));
        }
        [HttpPost] // For swagger generate
        public async Task<ActionResult<ServiceResponse<List<Charactor>>>> AddCharactor(Charactor newCharactor)
        {
            return Ok(await _charactorService.AddCharactor(newCharactor));
        }

    }
}