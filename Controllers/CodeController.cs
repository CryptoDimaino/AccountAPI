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

using Microsoft.AspNetCore.Http;

namespace AccountAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly ICodeRepository _ICodeRepository;

        private IHttpContextAccessor _accessor;

        public CodeController(ILoggerManager Logger, ICodeRepository ICodeRepository, IHttpContextAccessor accessor)
        {
            _Logger = Logger;
            _ICodeRepository = ICodeRepository;
            _accessor = accessor;
        }

        [HttpGet("ip")]
        public IActionResult GetIp()
        {
            return Content(_accessor.HttpContext.Connection.RemoteIpAddress.ToString());
        }

        // GET api/v{version:apiVersion}/code/default
        [HttpGet("default")]
        public async Task<IActionResult> GetCodesDefault()
        {
            var Response = new ListResponse<Code>();
            try
            {
                Response.Model = await _ICodeRepository.GetAllCodesDefaultAsync();
                Response.Message = "Querying all codes with default information.";
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

        // GET api/v{version:apiVersion}/code/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetCodeIdDefault(int id)
        {
            var Response = new SingleResponse<Code>();
            try
            {
                Response.Model = await _ICodeRepository.GetCodeByIdDefaultAsync(id);
                Response.Message = $"Querying Code with the id: {id} with default information.";
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

        // POST api/v{version:apiVersion}/code/
        [HttpPost]
        public async Task<IActionResult> AddCode([FromBody] Code NewCode)
        {
            var Response = new SingleResponse<Code>();            
            try
            {
                await _ICodeRepository.CreateCodeAsync(NewCode);
                if(NewCode.CodeId == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Code you are trying to add was already found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"{NewCode.CodeId}";
                    Response.Model = NewCode;
                    _Logger.LogInfo(ControllerContext, $"The Code with the id: {NewCode.CodeId} was added to the database.");
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

        // PUT api/v{version:apiVersion}/code/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode([FromBody] Code UpdateCode)
        {
            var Response = new SingleResponse<Code>();
            try
            {
                int result = await _ICodeRepository.UpdateCodeAsync(UpdateCode);
                if(result == 0)
                {
                    Response.DidError = true;
                    Response.Message = $"The Code with the id: {UpdateCode.CodeId} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Message = $"Successfully updated the code with the id: {UpdateCode.CodeId}.";
                    Response.Model = UpdateCode;
                    _Logger.LogInfo(ControllerContext, $"Code with the id: {UpdateCode.CodeId} has been updated.");
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

        // DELETE api/v{version:apiVersion}/code/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeId(int id)
        {
            var Response = new SingleResponse<Code>();
            try
            {
                if(!_ICodeRepository.DoesCodeExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Code with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Code CodeToDelete = await _ICodeRepository.GetCodeByIdDefaultAsync(id);
                    await _ICodeRepository.DeleteCodeAsync(CodeToDelete);
                    Response.Message = $"Querying code with the id: {CodeToDelete.CodeId} to delete.";
                    Response.Model = CodeToDelete;
                    _Logger.LogInfo(ControllerContext, $"Code with the id: {CodeToDelete.CodeId} has been deleted.");
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

        // GET api/v{version:apiVersion}/code/count
        [HttpGet("count")]
        public async Task<IActionResult> GetCodeCount()
        {
            var Response = new SingleResponse<int>();
            try
            {
                Response.Model = await _ICodeRepository.CountNumberOfCodesAsync();
                Response.Message =  $"Querying the total number of codes.";
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

        // GET api/v{version:apiVersion}/code
        [HttpGet]
        public async Task<IActionResult> GetCodes()
        {
            var Response = new ListResponse<object>();
            try
            {
                Response.Model = await _ICodeRepository.GetAllCodesAsync();
                Response.Message = $"Querying all Codes.";
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

        // GET api/v{version:apiVersion}/code/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCodeId(int id)
        {
            var Response = new SingleResponse<object>();
            try
            {
                if(!_ICodeRepository.DoesCodeExist(id))
                {
                    Response.DidError = true;
                    Response.Message = $"The Code with the id: {id} was not found in the database.";
                    _Logger.LogError(ControllerContext, Response.Message);
                }
                else
                {
                    Response.Model = await _ICodeRepository.GetCodeByIdAsync(id);
                    Response.Message = $"Querying Code with the id: {id}.";
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