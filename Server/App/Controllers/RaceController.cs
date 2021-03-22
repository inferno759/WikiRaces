using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Library;
using Library.Interfaces;
using Library.Model;
using Data;
using App.Service;


namespace App.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;
        private readonly WebScraperService _webScraperService;

        public RaceController(IRaceRepository raceRepository, WebScraperService webScraperService)
        {
            _raceRepository = raceRepository;
            _webScraperService = webScraperService;
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

        [HttpGet("api/race/play/{raceId}")]
        public async Task<IActionResult> ControllerPlayRace(int raceId)
        {
            var race = await _raceRepository.GetRaceByID(raceId);
            var page = await _webScraperService.Start(race.StartPage);
            return Ok();
        }

        [HttpGet("api/race/play")]
        public async Task<IActionResult> ControllerPlayRaceStep(string current, string step)
        {
            var page = await _webScraperService.Step(current, step);
            return Ok();
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
