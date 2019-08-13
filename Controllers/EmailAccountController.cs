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

        public EmailAccountController(ILoggerManager Logger, IEmailAccountRepository IEmailAccountRepository)
        {
            _Logger = Logger;
            _IEmailAccountRepository = IEmailAccountRepository;
        }
    
        // GET api/v{version:apiVersion}/emailaccount/default
        [HttpGet("default")]
        public async Task<IActionResult> GetEmailAccountsDefault()
        {
            var Response = new ListResponse<EmailAccount>();
            try
            {
                Response.Model = await _IEmailAccountRepository.GetAllEmailAccountsDefaultAsync();
                Response.Message = "Querying all EmailAccounts with default information.";
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

        // GET api/v{version:apiVersion}/emailaccount/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetEmailAccountIdDefault(int id)
        {
            var Response = new SingleResponse<EmailAccount>();
            try
            {
                Response.Model = await _IEmailAccountRepository.GetEmailAccountByIdDefaultAsync(id);                
                Response.Message = $"Querying EmailAccount with the id: {id} with default information.";
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

        // POST api/v{version:apiVersion}/emailaccount
        [HttpPost]
        public async Task<IActionResult> AddEmailAccount([FromBody] EmailAccount NewEmailAccount)
        {
            var Response = new SingleResponse<EmailAccount>();
            try
            {
                await _IEmailAccountRepository.CreateEmailAccountAsync(NewEmailAccount);
                if(NewEmailAccount.EmailAccountId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The EmailAccount you are trying to add was already found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{NewEmailAccount.EmailAccountId}";
                    Response.Model = NewEmailAccount;
                    _Logger.LogInfo(ControllerContext, $"The EmailAccount with the id: {NewEmailAccount.EmailAccountId} was added to the database.");
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

        // PUT api/v{version:apiVersion}/emailaccount/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmailAccount([FromBody] EmailAccount UpdateEmailAccount)
        {
            var Response = new SingleResponse<EmailAccount>();
            try
            {
                int result = await _IEmailAccountRepository.UpdateEmailAccountAsync(UpdateEmailAccount);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Account with the id: {UpdateEmailAccount.EmailAccountId} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{UpdateEmailAccount.EmailAccountId}";
                    Response.Model = UpdateEmailAccount;
                    _Logger.LogInfo(ControllerContext, $"EmailAccount with the id: {UpdateEmailAccount.EmailAccountId} has been updated.");
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

        // DELETE api/v{version:apiVersion}/emailaccount/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailAccountId(int id)
        {
            var Response = new SingleResponse<EmailAccount>();
            try
            {
                if(!_IEmailAccountRepository.DoesEmailAccountExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The EmailAccount with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    EmailAccount EmailAccountToDelete = await _IEmailAccountRepository.GetEmailAccountByIdDefaultAsync(id);
                    await _IEmailAccountRepository.DeleteEmailAccountAsync(EmailAccountToDelete);
                    Response.Message = $"{EmailAccountToDelete.EmailAccountId}";
                    Response.Model = EmailAccountToDelete;
                    _Logger.LogInfo(ControllerContext, $"EmailAccount with the id: {EmailAccountToDelete.EmailAccountId} has been deleted.");
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

        // GET api/v{version:apiVersion}/EmailAccount/count
        [HttpGet("count")]
        public async Task<IActionResult> GetEmailAccountCount()
        {
            var Response = new SingleResponse<int>();
            try
            {
                Response.Model = await _IEmailAccountRepository.CountNumberOfEmailAccountsAsync();
                Response.Message =  $"Querying the total number of EmailAccounts.";
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

        // GET api/v{version:apiVersion}/EmailAccount
        [HttpGet]
        public async Task<IActionResult> GetEmailAccounts()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _IEmailAccountRepository.GetAllEmailAccountsAsync();
                Response.Message = $"Querying all EmailAccounts.";
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

        // Get api/v{version:apiVersion}/EmailAccount/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailAccountId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_IEmailAccountRepository.DoesEmailAccountExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The EmailAccount with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Model = await _IEmailAccountRepository.GetEmailAccountByIdAsync(id);
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