using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountAPI.Contracts;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using AccountAPI.Repositories;
using AccountAPI.Services;

namespace AccountAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IGameRepository _IGameRepository;

        public GameController(ILoggerManager Logger, IGameRepository IGameRepository)
        {
            _Logger = Logger;
            _IGameRepository = IGameRepository;
        }

        // GET api/v{version:apiVersion}/game/default
        [HttpGet("default")]
        public async Task<IActionResult> GetGamesDefault()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all games with default information.");
                return Ok(await _IGameRepository.GetAllGamesDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // Get api/v{version:apiVersion}/game/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetGameIdDefault(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Game with the id: {id} with default information.");
                return Ok(await _IGameRepository.GetGameByIDDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/v{version:apiVersion}/game
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game NewGame)
        {
            try
            {
                await _IGameRepository.CreateGameAsync(NewGame);
                _Logger.LogInfo(ControllerContext, $"Adding Game with the id: {NewGame.GameId}");
                return Ok(new { Id = NewGame.GameId });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/v{version:apiVersion}/game/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame([FromBody] Game UpdateGame)
        {
            try
            {
                await _IGameRepository.UpdateGameAsync(UpdateGame);
                _Logger.LogInfo(ControllerContext, $"Successfully updated the game with the id: {UpdateGame.GameId}.");
                return NoContent();       
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/v{version:apiVersion}/game/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameId(int id)
        {
            try
            {
                // NOTE: This will delete all relations to other tables such as codes.
                _Logger.LogInfo(ControllerContext, $"Querying game with the id: {id} to delete.");
                await _IGameRepository.DeleteGameAsync(await _IGameRepository.GetGameByIDDefaultAsync(id));
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/game/count
        [HttpGet("count")]
        public async Task<IActionResult> GetGameCount()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying the total number of games.");
                return Ok(await _IGameRepository.CountNumberOfGamesAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        
        // GET api/v{version:apiVersion}/game
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Games with Platform and Number of Accounts.");
                return Ok(await _IGameRepository.GetAllGamesAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/v{version:apiVersion}/game/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Game with the id: {id} with a list of Accounts and their Codes.");
                return Ok(await _IGameRepository.GetGameByIDAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}