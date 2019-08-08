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
    public class AccountController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IAccountRepository _IAccountRepository;

        public AccountController(ILoggerManager Logger, IAccountRepository IAccountRepository)
        {
            _Logger = Logger;
            _IAccountRepository = IAccountRepository;
        }

        // GET api/v{version:apiVersion}/account/default
        [HttpGet("default")]
        public async Task<IActionResult> GetAccountsDefault()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Accounts with the default information.");
                return Ok(await _IAccountRepository.GetAllAccountsDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/account/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetAccountIdDefault(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Account with the id: {id} with default information.");
                return Ok(await _IAccountRepository.GetAccountByIdDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/v{version:apiVersion}/account
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] Account NewAccount)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Adding Account with the id: {NewAccount.AccountId}");
                await _IAccountRepository.CreateAccountAsync(NewAccount);
                return Ok(new { Id = NewAccount.AccountId });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/v{version:apiVersion}/account/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] Account UpdateAccount)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Successfully updated the game with the id: {UpdateAccount.AccountId}.");
                await _IAccountRepository.UpdateAccountAsync(UpdateAccount);
                return Ok(new { Id = UpdateAccount.AccountId });       
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/v{version:apiVersion}/account/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountId(int id)
        {
            try
            {
                Account AccountToDelete = await _IAccountRepository.GetAccountByIdDefaultAsync(id);
                if(AccountToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Game with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                // NOTE: This will delete all relations to other tables such as codes.
                _Logger.LogInfo(ControllerContext, $"Querying game with the id: {id} to delete.");
                await _IAccountRepository.DeleteAccountAsync(await _IAccountRepository.GetAccountByIdDefaultAsync(id));
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/account/count
        [HttpGet("count")]
        public async Task<IActionResult> GetAccountCount()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying the total number of accounts.");
                return Ok(await _IAccountRepository.CountNumberOfAccountsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/account
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Accounts.");
                return Ok(await _IAccountRepository.GetAllAccountsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // Get api/v{version:apiVersion}/account/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Account with the id: {id}.");
                return Ok(await _IAccountRepository.GetAccountByIdAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}