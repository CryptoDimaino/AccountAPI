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
    public class EventController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IEventRepository _IEventRepository;
        private readonly Context _Context;

        public EventController(ILoggerManager Logger, IEventRepository IEventRepository, Context Context)
        {
            _Logger = Logger;
            _IEventRepository = IEventRepository;
            _Context = Context;
        }
    
        // GET api/v{version:apiVersion}/Event/default
        [HttpGet("default")]
        public async Task<IActionResult> GetEventsDefault()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Events with the default information.");
                return Ok(await _IEventRepository.GetAllEventsDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/Event/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetEventIdDefault(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Event with the id: {id} with default information.");
                return Ok(await _IEventRepository.GetEventByIdDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/v{version:apiVersion}/Event
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event NewEvent)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Adding Event with the id: {NewEvent.EventId}");
                await _IEventRepository.CreateEventAsync(NewEvent);
                if(NewEvent.EventId == 0)
                {
                    return Ok(new { Error = "Event already exists."});
                }
                return Ok(new { Id = NewEvent.EventId });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/v{version:apiVersion}/Event/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent([FromBody] Event UpdateEvent)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Successfully updated the Event with the id: {UpdateEvent.EventId}.");
                await _IEventRepository.UpdateEventAsync(UpdateEvent);
                return Ok(new { Id = UpdateEvent.EventId });       
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/v{version:apiVersion}/Event/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventId(int id)
        {
            try
            {
                Event EventToDelete = await _IEventRepository.GetEventByIdDefaultAsync(id);
                if(EventToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Event with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                // NOTE: This will delete all relations to other tables such as codes.
                await _IEventRepository.DeleteEventAsync(EventToDelete);
                _Logger.LogInfo(ControllerContext, $"Querying Event with the id: {id} to delete, all deleted the emails with the ids:.");
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/Event/count
        [HttpGet("count")]
        public async Task<IActionResult> GetEventCount()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying the total number of Events.");
                return Ok(await _IEventRepository.CountNumberOfEventsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/Event
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Events.");
                return Ok(await _IEventRepository.GetAllEventsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/v{version:apiVersion}/Event/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Event with the id: {id}.");
                return Ok(await _IEventRepository.GetEventByIdAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}