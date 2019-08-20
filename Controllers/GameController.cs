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
            var Response = new ListResponse<Game>();
            try
            {
                Response.Model = await _IGameRepository.GetAllGamesDefaultAsync();
                Response.Message = "Querying all games with default information.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // Get api/v{version:apiVersion}/game/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetGameIdDefault(int id)
        {
            var Response = new SingleResponse<Game>();
            try
            {
                if(!_IGameRepository.DoesGameExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Game with the id: {id} was not found in the database.";
                }
                else
                {
                    Response.Model = await _IGameRepository.GetGameByIdDefaultAsync(id);
                    Response.Message = $"Querying Game with the id: {id} with default information.";
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // POST api/v{version:apiVersion}/game
        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game NewGame)
        {
            var Response = new SingleResponse<Game>();
            try
            {
                await _IGameRepository.CreateGameAsync(NewGame);
                if(NewGame.GameId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Game you are trying to add was already found in the database.";
                }
                else
                {
                    Response.Message = $"The Game with the id: {NewGame.GameId} was added to the database.";
                    Response.Model = NewGame;
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogError(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // PUT api/v{version:apiVersion}/game/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] Game UpdateGame)
        {
            var Response = new SingleResponse<Game>();
            try
            {
                int result = await _IGameRepository.UpdateGameAsync(id, UpdateGame);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Game with the id: {UpdateGame.GameId} was not found in the database.";
                }
                else if(result == 1)
                {
                    Response.DidError = true;
                    Response.Message = $"The games platform cannot be changed while accounts exist because they all belong to that game and platform.";
                }
                else
                {
                    Response.Message = $"Game with the id: {UpdateGame.GameId} has been updated.";
                    Response.Model = UpdateGame;
                }    
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogError(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // DELETE api/v{version:apiVersion}/game/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameId(int id)
        {
            var Response = new SingleResponse<Game>();
            try
            {
                if(!_IGameRepository.DoesGameExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Game with the id: {id} was not found in the database.";
                }
                else
                {
                    Game GameToDelete = await _IGameRepository.GetGameByIdDefaultAsync(id);
                    int result = await _IGameRepository.DeleteGameAsync(GameToDelete);
                    if(result == 0)
                    {
                        Response.DidError = true;
                        Response.Message = $"The Game with the id: {id} cannot be delete while there are still codes/accounts attached to the game.";
                    }
                    else
                    {
                        Response.Message = $"The Game with the id: {GameToDelete.GameId} has been deleted.";
                        Response.Model = GameToDelete;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogError(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // DELETE api/v{version:apiVersion}/game/{id}/confirm
        [HttpDelete("{id}/confirm")]
        public async Task<IActionResult> DeleteGameIdAndCodes(int id)
        {
            var Response = new SingleResponse<Game>();
            try
            {
                if(!_IGameRepository.DoesGameExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Game with the id: {id} was not found in the database.";
                }
                else
                {
                    Game GameToDelete = await _IGameRepository.GetGameByIdDefaultAsync(id);
                    int result = await _IGameRepository.DeleteGameAsync(GameToDelete);
                    if(result == 0)
                    {
                        Response.DidError = true;
                        Response.Message = $"The Game with the id: {GameToDelete.GameId} has been deleted.";
                        await _IGameRepository.DeleteGameAndCodesAsync(GameToDelete);
                    }
                    else
                    {
                        Response.Message = $"The Game with the id: {GameToDelete.GameId} has been deleted.";
                        Response.Model = GameToDelete;
                    }
                }
                
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogError(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/game/count
        [HttpGet("count")]
        public async Task<IActionResult> GetGameCount()
        {
            var Response = new SingleResponse<int>();
            try
            {
                Response.Model = await _IGameRepository.CountNumberOfGamesAsync();
                Response.Message =  $"Querying the total number of games.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }
        
        // GET api/v{version:apiVersion}/game
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _IGameRepository.GetAllGamesAsync();
                Response.Message = $"Querying all Games.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);  
            return Response.ToHttpResponse();
        }

        // Get api/v{version:apiVersion}/game/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_IGameRepository.DoesGameExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Game with the id: {id} was not found in the database.";
                }
                else
                {
                    Response.Model = await _IGameRepository.GetGameByIdAsync(id);
                    Response.Message = $"Querying Game with the id: {id}.";
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogError(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }
    }
}