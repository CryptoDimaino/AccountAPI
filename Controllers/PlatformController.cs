using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountAPI.Contracts;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using AccountAPI.Repositories;
// using AccountAPI.Helpers;

namespace AccountAPI.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/Platform
        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Platforms!");
                return Ok(await _IPlatformRepository.GetAllPlatformsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/Platform/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformtId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Platform with the id: {id}");
                return Ok(await _IPlatformRepository.GetPlatformByIDAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/Platform/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetPlatformByName(string Name)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying for the Platform with the name: {Name}");
                return Ok(await _IPlatformRepository.GetPlatformByNameAsync(Name));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/Platform/CreateNewPlatform
        [HttpPost("CreateNewPlatform")]
        public async Task<IActionResult> CreateNewPlatform()
        {
            Console.WriteLine("Here");
            int Count = await _IPlatformRepository.CountNumberOfPlatformsAsync();
            Platform NewPlatform = new Platform()
            {
                Name = "Platform " + Count,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            try
            {
                _Logger.LogInfo(ControllerContext, $"Name: {NewPlatform.Name}");
                await _IPlatformRepository.CreatePlatformAsync(NewPlatform);
                return NoContent();
            }  
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Interal Server Error.");
            }
        }

        // PUT api/Platform/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlatform(int id)
        {
            try
            {
                Platform PlatformToUpdate = await _IPlatformRepository.GetPlatformByIDAsync(id);
                if(PlatformToUpdate == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Warning: Platform was not found with the id: {id}");
                    return StatusCode(500, "Internal Server Error.");
                }
                _Logger.LogInfo(ControllerContext, $"Platform with the id: {id} has been updated.");

                PlatformToUpdate.UpdatedAt = DateTime.Now;
                await _IPlatformRepository.UpdatePlatformAsync(PlatformToUpdate);
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // DELETE api/Platform/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            try
            {
                Platform PlatformToDelete = await _IPlatformRepository.GetPlatformByIDAsync(id);
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

        // GET api/Platform/count
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
    }
}