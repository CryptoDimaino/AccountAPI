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
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IGameRepository _IGameRepository;
        private readonly Context _Context;

        public GameController(ILoggerManager Logger, IGameRepository IGameRepository, Context Context)
        {
            _Logger = Logger;
            _IGameRepository = IGameRepository;
            _Context = Context;
        }

        // GET api/game
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                // var response = new ListResponse<GameDTO>();
                // response

                _Logger.LogInfo(ControllerContext, $"Querying all Games!");
                return Ok(await _IGameRepository.GetAllGamesAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/game/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Game with the id: {id}");
                return Ok(await _IGameRepository.GetGameByIDAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/game
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game NewGame)
        {
                _Logger.LogWarn(ControllerContext, "This is a test.");

            if(ModelState.IsValid)
            {
                _Logger.LogWarn(ControllerContext, "No God No God NOOOOOOOOO");
                return BadRequest(ModelState);
            }
            try
            {
                await _IGameRepository.AddGameAsync(NewGame);
                _Logger.LogInfo(ControllerContext, $"Adding Game with the id: {NewGame.GameId}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/game/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameId(int id)
        {
            try
            {
                // NOTE: This will delete all relations to other tables such as codes.
                _Logger.LogInfo(ControllerContext, $"Querying game with the id: {id} to delete.");
                await _IGameRepository.DeleteGameAsync(await _IGameRepository.DefaultGetGameByIDAsync(id));
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}