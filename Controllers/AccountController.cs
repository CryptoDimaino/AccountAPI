﻿using System;
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
                    Response.Message = $"The Account with the id: {NewAccount.AccountId} was already found in the database.";
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
                    await _IAccountRepository.DeleteAccountAsync(AccountToDelete);
                    Response.Message = $"{AccountToDelete.AccountId}";
                    Response.Model = AccountToDelete;
                    _Logger.LogInfo(ControllerContext, $"Account with the id: {AccountToDelete.AccountId} has been deleted.");
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

        // GET api/v{version:apiVersion}/account/count
        [HttpGet("count")]
        public async Task<IActionResult> GetAccountCount()
        {
            var Response = new SingleResponse<Account>();
            try
            {
                int NumOfAccounts = await _IAccountRepository.CountNumberOfAccountsAsync();
                Response.Message =  $"Querying the total number of accounts.";
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
                var Account = await _IAccountRepository.GetAccountByIdAsync(id);
                Response.Message = $"Querying Account with the id: {id}.";
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
    }
}