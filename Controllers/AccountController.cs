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
    public class AccountController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly IAccountRepository _IAccountRepository;

        public AccountController(ILoggerManager Logger, IAccountRepository IAccountRepository)
        {
            _Logger = Logger;
            _IAccountRepository = IAccountRepository;
        }

        // GET api/Account
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Accounts!");
                return Ok(await _IAccountRepository.GetAllAccountsAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/Account/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Account with the id: {id}");
                return Ok(await _IAccountRepository.GetAccountByIDAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/Account/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetAccountByName(string Name)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying for the Account with the name: {Name}");
                return Ok(await _IAccountRepository.GetAccountByNameAsync(Name));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/Account/CreateNewAccount
        [HttpPost("CreateNewAccount")]
        public async Task<IActionResult> CreateNewAccount()
        {
            Console.WriteLine("Here");
            int Count = await _IAccountRepository.CountNumberOfAccountsAsync();
            Account NewAccount = new Account()
            {
                Name = "Account" + Count,
                Password = "Password" + Count,
                Email = $"Account{Count}@gmail.com",
                EmailPassword = "",
                CheckedOutStatus = false,
                EventLocation = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                // AccountProfileId = 1
            };

            try
            {
                _Logger.LogInfo(ControllerContext, $"Name: {NewAccount.Name}");
                await _IAccountRepository.CreateAccountAsync(NewAccount);
                return NoContent();
            }  
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Interal Server Error.");
            }
        }

        // PUT api/account/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id)
        {
            try
            {
                Account AccountToUpdate = await _IAccountRepository.GetAccountByIDAsync(id);
                if(AccountToUpdate == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Warning: Account was not found with the id: {id}");
                    return StatusCode(500, "Internal Server Error.");
                }
                _Logger.LogInfo(ControllerContext, $"Chipset with the id: {id} has been updated.");

                AccountToUpdate.UpdatedAt = DateTime.Now;
                await _IAccountRepository.UpdateAccountAsync(AccountToUpdate);
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // DELETE api/account/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            _Logger.LogWarn(ControllerContext, $"Deleting a account will also delete te account profile linked and all the information in table.");
            try
            {
                Account AccountToDelete = await _IAccountRepository.GetAccountByIDAsync(id);
                if(AccountToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Account with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                _Logger.LogInfo(ControllerContext, $"Chipset with id: {id} has been deleted");
                await _IAccountRepository.DeleteAccountAsync(AccountToDelete);
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/account/count
        [HttpGet("count")]
        public async Task<IActionResult> GetNumberOfAccounts()
        {
            try
            {
                int NumOfAccounts = await _IAccountRepository.CountNumberOfAccountsAsync();
                _Logger.LogInfo(ControllerContext, $"There are {NumOfAccounts} accounts!");
                return Ok(NumOfAccounts);
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}