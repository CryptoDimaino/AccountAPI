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
    public class EmailAccountController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IEmailAccountRepository _IEmailAccountRepository;
        private readonly Context _Context;

        public EmailAccountController(ILoggerManager Logger, IEmailAccountRepository IEmailAccountRepository, Context Context)
        {
            _Logger = Logger;
            _IEmailAccountRepository = IEmailAccountRepository;
            _Context = Context;
        }
    
        // GET api/v{version:apiVersion}/emailaccount/default
        [HttpGet("default")]
        public async Task<IActionResult> GetEmailAccountsDefault()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all EmailAccounts with the default information.");
                return Ok(await _IEmailAccountRepository.GetAllEmailAccountsDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/emailaccount/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetEmailAccountIdDefault(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying EmailAccount with the id: {id} with default information.");
                return Ok(await _IEmailAccountRepository.GetEmailAccountByIdDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/v{version:apiVersion}/emailaccount
        [HttpPost]
        public async Task<IActionResult> AddEmailAccount([FromBody] EmailAccount NewEmailAccount)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Adding EmailAccount with the id: {NewEmailAccount.EmailAccountId}");
                await _IEmailAccountRepository.CreateEmailAccountAsync(NewEmailAccount);
                if(NewEmailAccount.EmailAccountId == 0)
                {
                    return Ok(new { Error = "EmailAccount already exists."});
                }
                return Ok(new { Id = NewEmailAccount.EmailAccountId });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/v{version:apiVersion}/emailaccount/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmailAccount([FromBody] EmailAccount UpdateEmailAccount)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Successfully updated the emailaccount with the id: {UpdateEmailAccount.EmailAccountId}.");
                await _IEmailAccountRepository.UpdateEmailAccountAsync(UpdateEmailAccount);
                return Ok(new { Id = UpdateEmailAccount.EmailAccountId });       
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/v{version:apiVersion}/emailaccount/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailAccountId(int id)
        {
            try
            {
                EmailAccount EmailAccountToDelete = await _IEmailAccountRepository.GetEmailAccountByIdDefaultAsync(id);
                if(EmailAccountToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"EmailAccount with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                // NOTE: This will delete all relations to other tables such as codes.
                string accountids = await _IEmailAccountRepository.DeleteEmailAccountAsync(EmailAccountToDelete);
                _Logger.LogInfo(ControllerContext, $"Querying EmailAccount with the id: {id} to delete, all deleted the emails with the ids:{accountids}.");
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/EmailAccount/count
        [HttpGet("count")]
        public async Task<IActionResult> GetEmailAccountCount()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying the total number of EmailAccounts.");
                return Ok(await _IEmailAccountRepository.CountNumberOfEmailAccountsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/EmailAccount
        [HttpGet]
        public async Task<IActionResult> GetEmailAccounts()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all EmailAccounts.");
                return Ok(await _IEmailAccountRepository.GetAllEmailAccountsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/v{version:apiVersion}/EmailAccount/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailAccountId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying EmailAccount with the id: {id}.");
                return Ok(await _IEmailAccountRepository.GetEmailAccountByIdAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}