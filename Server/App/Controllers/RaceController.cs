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
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet("api/race")]
        public async Task<IActionResult> ControllerGetAllRaces()
        {
            var races = await _raceRepository.GetRaces();
            return Ok(races);
        }

        [AllowAnonymous]
        [HttpGet("api/race/id/{raceId}")]
        public async Task<IActionResult> ControllerGetRaceById(int raceId)
        {
            var race = await _raceRepository.GetRaceByID(raceId);
            return Ok(race);
        }

        [AllowAnonymous]
        [HttpGet("api/race/title/{raceTitle}")]
        public async Task<IActionResult> ControllerGetRacesByTitle(string raceTitle)
        {
            var race = await _raceRepository.GetRacesByTitle(raceTitle);
            return Ok(race);
        }

        [AllowAnonymous]
        [HttpGet("api/race/play/{raceId}")]
        public async Task<ContentResult> ControllerPlayRace(int raceId)
        {
            var race = await _raceRepository.GetRaceByID(raceId);
            var page = await _webScraperService.Start(race.StartPage);
            return Content(page, "text/html");
        }

        [AllowAnonymous]
        [HttpGet("api/race/play/{raceId}/step")]
        public async Task<ContentResult> ControllerPlayRaceStep(int raceId,string current, string step)
        {
            var race = await _raceRepository.GetRaceByID(raceId);
            var page = await _webScraperService.Step(current, step);

            if (step == race.EndPage && page != null)
            {
                return Content("Victory!");
            }
            return Content(page);
        }

        [AllowAnonymous]
        [HttpPost("api/race")]
        public async Task<IActionResult> ControllerAddRace([Required] Race race)
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
