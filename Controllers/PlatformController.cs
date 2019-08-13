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
                Response.Model = await _IPlatformRepository.GetAllPlatformsDefaultAsync();
                Response.Message = "Querying all platforms with default information.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/game/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetPlatformByIDDefaultAsync(int id)
        {
            var Response = new SingleResponse<Platform>();
            try
            {
                if(!_IPlatformRepository.DoesPlatformExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Platform with the id: {id} was not found in the database.";
                }
                else
                {
                    Response.Model = await _IPlatformRepository.GetPlatformByIDDefaultAsync(id);
                    Response.Message = $"Querying Platform with the id: {id}.";
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
                }
                else
                {
                    Response.Message = $"The Platform with the Name: {NewPlatform.Name} was added to the database.";
                    Response.Model = NewPlatform;
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
                }
                else
                {
                    Response.Message = $"Platform with the id: {UpdatePlatform.PlatformId} has been updated.";
                    Response.Model = UpdatePlatform;
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
                }
                else
                {
                    Platform PlatformToDelete = await _IPlatformRepository.GetPlatformByIDDefaultAsync(id);
                    await _IPlatformRepository.DeletePlatformAsync(PlatformToDelete);
                    Response.Message = $"Platform with the id: {PlatformToDelete.PlatformId} has been deleted.";
                    Response.Model = PlatformToDelete;
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

        // GET api/v{version:apiVersion}/Platform/count
        [HttpGet("count")]
        public async Task<IActionResult> GetNumberOfPlatforms()
        {
            var Response = new SingleResponse<int>();
            try
            {
                Response.Model = await _IPlatformRepository.CountNumberOfPlatformsAsync();
                Response.Message =  $"There are {Response.Model} platforms!";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);  
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/Platform
        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _IPlatformRepository.GetAllPlatformsOnlyAsync();
                Response.Message =  $"Querying all Platforms Names with id.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";                
            }
            _Logger.LogInfo(ControllerContext, Response.Message);  
            return Response.ToHttpResponse();
        }

        // Get api/v{version:apiVersion}/Platform/GetPlatformsAndGames
        [HttpGet("GetPlatformsAndGames")]
        public async Task<IActionResult> GetPlatformsAndGames()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _IPlatformRepository.GetAllPlatformsAsync();
                Response.Message = $"Querying all Platforms.";
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
            }
            _Logger.LogInfo(ControllerContext, Response.Message);  
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/Platform/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_IPlatformRepository.DoesPlatformExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Platform with the id: {id} was not found in the database.";
                }
                else
                {
                    Response.Model = await _IPlatformRepository.GetPlatformByIdAsync(id);
                    Response.Message = $"Querying Platform with the id: {id}.";
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