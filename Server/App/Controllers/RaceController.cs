using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Library.Interfaces;
using Library.Model;
using Data;
using System.ComponentModel.DataAnnotations;


namespace App.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }


        [HttpGet("api/race")]
        public async Task<IActionResult> ControllerGetAllRaces()
        {
            var races = await _raceRepository.GetRaces();
            return Ok(races);
        }

        [HttpGet("api/race/id/{raceId}")]
        public async Task<IActionResult> ControllerGetRaceById(int raceId)
        {
            var race = await _raceRepository.GetRaceByID(raceId);
            return Ok(race);
        }

        [HttpGet("api/race/title/{raceTitle}")]
        public async Task<IActionResult> ControllerGetRacesByTitle(string raceTitle)
        {
            var race = await _raceRepository.GetRacesByTitle(raceTitle);
            return Ok(race);
        }

        [HttpPost("api/race")]
        public async Task<IActionResult> ControllerAddRace([Required] Library.Model.Race race)
        {
            await _raceRepository.AddRace(race);
            return Ok();
        }

        /*
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
