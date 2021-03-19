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
    public class LeaderboardLineController : ControllerBase
    {

        private readonly ILeaderBoardLineRepository _leaderboardLineRepository;

        public LeaderboardLineController(ILeaderBoardLineRepository leaderboardLineRepository)
        {
            _leaderboardLineRepository = leaderboardLineRepository;
        }


        [HttpGet("api/leaderboard")]
        public async Task<IActionResult> ControllerGetAllLeaderboardLines()
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLines();
            return Ok(leaderboardLines);
        }

        [HttpGet("api/leaderboard/{user}")]
        public async Task<IActionResult> ControllerGetLeaderboardLineByUser(User user)
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLinesByUser(user);
            return Ok(leaderboardLines);
        }

        [HttpGet("api/leaderboard/{race}")]
        public async Task<IActionResult> ControllerGetLeaderboardLineByRace(Race race)
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLinesByRace(race);
            return Ok(leaderboardLines);
        }

        [HttpPost("api/leaderboard")]
        public async Task<IActionResult> ControllerAddLeaderboardLine([Required] LeaderboardLine leaderboardLine)
        {
            await _leaderboardLineRepository.AddLeaderboardLine(leaderboardLine);
            return Ok();
        }

        /*
        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */

    }
}
