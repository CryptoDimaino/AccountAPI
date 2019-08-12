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
    public class PlatformController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IPlatformRepository _IPlatformRepository;

        public PlatformController(ILoggerManager Logger, IPlatformRepository IPlatformRepository)
        {
            _Logger = Logger;
            _IPlatformRepository = IPlatformRepository;
        }

        /// <summary>
        /// Get all of the platforms in the database and returns the default information found in the model.
        /// GET api/v{version:apiVersion}/game/default
        /// </summary>
        /// <returns>
        /// Response Message and DidError or Model.
        /// </returns>
        [HttpGet("default")]
        public async Task<IActionResult> GetAllPlatformsDefaultAsync()
        {
            var Response = new ListResponse<Platform>();
            try
            {
                var Platforms = await _IPlatformRepository.GetAllPlatformsDefaultAsync();
                Response.Message = "Querying all platforms with default information.";
                Response.Model = Platforms;
                _Logger.LogInfo(ControllerContext, Response.Message);
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/game/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetPlatformByIDDefaultAsync(int id)
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                var Platform = await _IPlatformRepository.GetPlatformByIDDefaultAsync(id);
                Response.Message = $"Querying platform with the id: {id} with default information.";
                Response.Model = Platform;
                _Logger.LogInfo(ControllerContext, Response.Message);
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // POST api/v{version:apiVersion}/Platform
        [HttpPost]
        public async Task<IActionResult> AddPlatform([FromBody] Platform NewPlatform)
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                await _IPlatformRepository.CreatePlatformAsync(NewPlatform);
                if(NewPlatform.PlatformId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Platform with the Name: {NewPlatform.Name} was already found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{NewPlatform.PlatformId}";
                    Response.Model = NewPlatform;
                    _Logger.LogInfo(ControllerContext, $"The Platform with the Name: {NewPlatform.Name} was added to the database.");
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // PUT api/v{version:apiVersion}/Platform/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatform([FromBody] Platform UpdatePlatform)
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                int result = await _IPlatformRepository.UpdatePlatformAsync(UpdatePlatform);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Platform with the id: {UpdatePlatform.PlatformId} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{UpdatePlatform.PlatformId}";
                    Response.Model = UpdatePlatform;
                    _Logger.LogInfo(ControllerContext, $"Platform with the id: {UpdatePlatform.PlatformId} has been updated.");
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // DELETE api/v{version:apiVersion}/Platform/delete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                if(!_IPlatformRepository.DoesPlatformExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Platform with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Platform PlatformToDelete = await _IPlatformRepository.GetPlatformByIDDefaultAsync(id);
                    await _IPlatformRepository.DeletePlatformAsync(PlatformToDelete);
                    Response.Message = $"{PlatformToDelete.PlatformId}";
                    Response.Model = PlatformToDelete;
                    _Logger.LogInfo(ControllerContext, $"Platform with the id: {PlatformToDelete.PlatformId} has been deleted.");
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/Platform/count
        [HttpGet("count")]
        public async Task<IActionResult> GetNumberOfPlatforms()
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                int NumOfPlatforms = await _IPlatformRepository.CountNumberOfPlatformsAsync();
                Response.Message =  $"There are {NumOfPlatforms} platforms!";
                Response.Model = null;
                _Logger.LogInfo(ControllerContext, Response.Message);
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/Platform
        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Platforms Names with Id.");
                return Ok(await _IPlatformRepository.GetAllPlatformsOnlyAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/v{version:apiVersion}/Platform/GetPlatformsAndGames
        [HttpGet("GetPlatformsAndGames")]
        public async Task<IActionResult> GetPlatformsAndGames()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Platforms With Games!");
                return Ok(await _IPlatformRepository.GetAllPlatformsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/Platform/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Platform with the id: {id} and list of games and accounts");
                return Ok(await _IPlatformRepository.GetPlatformByIdAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}