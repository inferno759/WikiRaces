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
using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpGet("api/leaderboard")]
        public async Task<IActionResult> ControllerGetAllLeaderboardLines()
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLines();
            return Ok(leaderboardLines);
        }

        [AllowAnonymous]
        [HttpGet("api/leaderboard/user/{userId}")]
        public async Task<IActionResult> ControllerGetLeaderboardLineByUser(int userId)
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLinesByUser(userId);
            return Ok(leaderboardLines);
        }

        [AllowAnonymous]
        [HttpGet("api/leaderboard/race/{raceId}")]
        public async Task<IActionResult> ControllerGetLeaderboardLineByRace(int raceId)
        {
            var leaderboardLines = await _leaderboardLineRepository.GetLeaderboardLinesByRace(raceId);
            return Ok(leaderboardLines);
        }

        [AllowAnonymous]
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
