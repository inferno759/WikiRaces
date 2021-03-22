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
using App.Service;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;


namespace App.Controllers
{
    //[Route("api/[controller]")]
    
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly HttpClient httpClient = new HttpClient();

        public UserController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }


        [HttpGet("api/user")]
        public async Task<IActionResult> ControllerGetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        /*
        [HttpGet("api/user/id/{userId}")]
        public async Task<IActionResult> ControllerGetUserById(int id)
        {

           
        }
        */



        [HttpGet("api/user/name/{username}")]
        public async Task<IActionResult> ControllerGetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            return Ok(user);

        }
        [HttpPost("api/user")]
        public async Task<IActionResult> ControllerAddUser([Required] Library.Model.User user)
        {
            await _userRepository.AddUser(user);
            return Ok();
        }
        [HttpGet("api/user")]
        public async Task<IActionResult> ControllerCheckLogin(string username, string password)
        {
            bool userExists = await _userRepository.CheckUserInfoExists(username, password);
            return Ok(userExists);

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
