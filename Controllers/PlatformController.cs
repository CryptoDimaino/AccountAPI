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

        // GET api/v{version:apiVersion}/game/default
        [HttpGet("default")]
        public async Task<IActionResult> GetAllPlatformsDefaultAsync()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all platforms with default information.");
                return Ok(await _IPlatformRepository.GetAllPlatformsDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/game/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetPlatformByIDDefaultAsync(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying platform with the id: {id} with default information.");
                return Ok(await _IPlatformRepository.GetPlatformByIDDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/v{version:apiVersion}/Platform
        [HttpPost]
        public async Task<IActionResult> AddPlatform([FromBody] Platform NewPlatform)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Name: {NewPlatform.PlatformId}");
                await _IPlatformRepository.CreatePlatformAsync(NewPlatform);
                return Ok(new { Id = NewPlatform.PlatformId });
            }  
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Interal Server Error.");
            }
        }

        // PUT api/v{version:apiVersion}/Platform/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatform([FromBody] Platform UpdatePlatform)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Platform with the id: {UpdatePlatform.PlatformId} has been updated.");
                await _IPlatformRepository.UpdatePlatformAsync(UpdatePlatform);
                return Ok(new { Id = UpdatePlatform.PlatformId });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // DELETE api/v{version:apiVersion}/Platform/delete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            try
            {
                Platform PlatformToDelete = await _IPlatformRepository.GetPlatformByIDDefaultAsync(id);
                if(PlatformToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Platform with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                _Logger.LogInfo(ControllerContext, $"Platform with id: {id} has been deleted.");
                await _IPlatformRepository.DeletePlatformAsync(PlatformToDelete);
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/Platform/count
        [HttpGet("count")]
        public async Task<IActionResult> GetNumberOfPlatforms()
        {
            try
            {
                int NumOfPlatforms = await _IPlatformRepository.CountNumberOfPlatformsAsync();
                _Logger.LogInfo(ControllerContext, $"There are {NumOfPlatforms} platforms!");
                return Ok(NumOfPlatforms);
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
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