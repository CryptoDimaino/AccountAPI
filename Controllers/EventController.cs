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

        public EventController(ILoggerManager Logger, IEventRepository IEventRepository)
        {
            _Logger = Logger;
            _IEventRepository = IEventRepository;
        }
    
        // GET api/v{version:apiVersion}/Event/default
        [HttpGet("default")]
        public async Task<IActionResult> GetEventsDefault()
        {
            var Response = new ListResponse<Event>();
            try
            {
                Response.Model = await _IEventRepository.GetAllEventsDefaultAsync();                
                Response.Message = "Querying all events with default information.";
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

        // GET api/v{version:apiVersion}/Event/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetEventIdDefault(int id)
        {
            var Response = new SingleResponse<Event>();
            try
            {
                if(!_IEventRepository.DoesEventExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"Event with the id: {id} was not found.";
                    _Logger.LogError(ControllerContext, $"Event with the id: {id} was not found");
                }
                else
                {
                    Response.Model = await _IEventRepository.GetEventByIdDefaultAsync(id);
                    Response.Message = $"Querying Event with the id: {id} with default information.";
                    _Logger.LogInfo(ControllerContext, Response.Message);
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

        // POST api/v{version:apiVersion}/Event
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event NewEvent)
        {
            var Response = new SingleResponse<Event>();
            try
            {
                await _IEventRepository.CreateEventAsync(NewEvent);
                if(NewEvent.EventId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Event you are trying to add was already found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{NewEvent.EventId}";
                    Response.Model = NewEvent;
                    _Logger.LogInfo(ControllerContext, $"The Event with the id: {NewEvent.EventId} was added to the database.");
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

        // PUT api/v{version:apiVersion}/Event/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent([FromBody] Event UpdateEvent)
        {
            var Response = new SingleResponse<Event>();
            try
            {
                int result = await _IEventRepository.UpdateEventAsync(UpdateEvent);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {UpdateEvent.EventId} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{UpdateEvent.EventId}";
                    Response.Model = UpdateEvent;
                    _Logger.LogInfo(ControllerContext, $"Event with the id: {UpdateEvent.EventId} has been updated.");
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

        // DELETE api/v{version:apiVersion}/Event/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventId(int id)
        {
            var Response = new SingleResponse<Event>();
            try
            {
                if(!_IEventRepository.DoesEventExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Event with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Event EventToDelete = await _IEventRepository.GetEventByIdDefaultAsync(id);
                    await _IEventRepository.DeleteEventAsync(EventToDelete);
                    Response.Message = $"{EventToDelete.EventId}";
                    Response.Model = EventToDelete;
                    _Logger.LogInfo(ControllerContext, $"Event with the id: {EventToDelete.EventId} has been deleted.");
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

        // GET api/v{version:apiVersion}/Event/count
        [HttpGet("count")]
        public async Task<IActionResult> GetEventCount()
        {
            var Response = new SingleResponse<int>();
            try
            {
                Response.Model = await _IEventRepository.CountNumberOfEventsAsync();
                Response.Message =  $"Querying the total number of events.";
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

        // GET api/v{version:apiVersion}/Event
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _IEventRepository.GetAllEventsAsync();                
                Response.Message = $"Querying all Accounts.";
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

        // Get api/v{version:apiVersion}/Event/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_IEventRepository.DoesEventExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Event with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Model = await _IEventRepository.GetEventByIdAsync(id);                    
                    Response.Message = $"Querying Account with the id: {id}.";
                    _Logger.LogInfo(ControllerContext, Response.Message);
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
    }
}