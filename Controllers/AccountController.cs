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

        private readonly Context _Context;

        public AccountController(ILoggerManager Logger, IAccountRepository IAccountRepository, Context Context)
        {
            _Logger = Logger;
            _IAccountRepository = IAccountRepository;
            _Context = Context;
        }

        // GET api/v{version:apiVersion}/account/default
        [HttpGet("default")]
        public async Task<IActionResult> GetAccountsDefault()
        {
            var Response = new ListResponse<Account>();
            try
            {
                var Accounts = await _IAccountRepository.GetAllAccountsDefaultAsync();
                Response.Message = "Querying all accounts with default information.";
                Response.Model = Accounts;
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

        // GET api/v{version:apiVersion}/account/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetAccountIdDefault(int id)
        {
            var Response = new SingleResponse<Account>();
            try
            {
                var Account = await _IAccountRepository.GetAccountByIdDefaultAsync(id);
                Response.Message = $"Querying Account with the id: {id} with default information.";
                Response.Model = Account;
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

        // POST api/v{version:apiVersion}/account
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] Account NewAccount)
        {
            var Response = new SingleResponse<Account>();
            try
            {
                await _IAccountRepository.CreateAccountAsync(NewAccount);
                if(NewAccount.AccountId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Account you are trying to add was already found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{NewAccount.AccountId}";
                    Response.Model = NewAccount;
                    _Logger.LogInfo(ControllerContext, $"The Account with the id: {NewAccount.AccountId} was added to the database.");
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

        // PUT api/v{version:apiVersion}/account/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] Account UpdateAccount)
        {
            var Response = new SingleResponse<Account>();
            try
            {
                int result = await _IAccountRepository.UpdateAccountAsync(UpdateAccount);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {UpdateAccount.AccountId} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else if(result == -2)
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {UpdateAccount.AccountId} WOW BROWN CHICKEN BROWN COW!.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    
                    Response.Message = $"{UpdateAccount.AccountId}";
                    Response.Model = UpdateAccount;
                    _Logger.LogInfo(ControllerContext, $"Account with the id: {UpdateAccount.AccountId} has been updated.");
                }     
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = "Internal Server Error.";
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
            }
            return Response.ToHttpResponse();

            // _Context.Accounts.Update(UpdateAccount);
            // _Context.SaveChanges();

            
            // return Ok(UpdateAccount);
        }

        // DELETE api/v{version:apiVersion}/account/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountId(int id)
        {
            var Response = new SingleResponse<Account>();
            try
            {
                if(!_IAccountRepository.DoesAccountExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Account AccountToDelete = await _IAccountRepository.GetAccountByIdDefaultAsync(id);
                    int result = await _IAccountRepository.DeleteAccountAsync(AccountToDelete);
                    if(result == 0)
                    {
                        Response.DidError = true;
                        Response.Message = $"The Account with the id: {id} cannot be delete while there are still codes attached to the account.";
                    }
                    else if(result == -1)
                    {
                        Response.DidError = true;
                        Response.Message = $"The Account with the id: {id} cannot be delete while it is checked out to an event.";
                    }
                    else
                    {
                        Response.Message = $"The Account with the id: {AccountToDelete.AccountId} has been deleted.";
                        Response.Model = AccountToDelete;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.DidError = true;
                Response.Message = $"Internal Server Error. Error Message: {ex.Message}";
                _Logger.LogError(ControllerContext, Response.Message);
            }
            return Response.ToHttpResponse();
        }

        // GET api/v{version:apiVersion}/account/count
        [HttpGet("count")]
        public async Task<IActionResult> GetAccountCount()
        {
            var Response = new SingleResponse<int>();
            try
            {
                int NumOfAccounts = await _IAccountRepository.CountNumberOfAccountsAsync();
                Response.Message =  $"Querying the total number of accounts.";
                Response.Model = NumOfAccounts;
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

        // GET api/v{version:apiVersion}/account
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var Response = new ListResponse<object>();
            try
            {
                var Accounts = await _IAccountRepository.GetAllAccountsAsync();
                Response.Message = $"Querying all Accounts.";
                Response.Model = Accounts;
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

        // Get api/v{version:apiVersion}/account/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_IAccountRepository.DoesAccountExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    var Account = await _IAccountRepository.GetAccountByIdAsync(id);
                    Response.Message = $"Querying Account with the id: {id}.";
                    Response.Model = Account;
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

        // Get api/v{version:apiVersion}/account/check
        [HttpGet("check")]
        public async Task<IActionResult> CheckAccount(int PlatformId, int EmailAccountId)
        {
            var Response = new SingleResponse<object>();
            try
            {
                var AccountsPlatformsList = await _IAccountRepository.AccountsAndPlatforms();
                Response.Model = AccountsPlatformsList;
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