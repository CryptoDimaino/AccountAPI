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
    public class CodeController : ControllerBase
    {
        private readonly ILoggerManager _Logger;
        private readonly ICodeRepository _ICodeRepository;

        public CodeController(ILoggerManager Logger, ICodeRepository ICodeRepository)
        {
            _Logger = Logger;
            _ICodeRepository = ICodeRepository;
        }

        // GET api/v{version:apiVersion}/code/default
        [HttpGet("default")]
        public async Task<IActionResult> GetCodesDefault()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all Codes with the default information.");
                return Ok(await _ICodeRepository.GetAllCodesDefaultAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/code/{id}/default
        [HttpGet("{id}/default")]
        public async Task<IActionResult> GetCodeIdDefault(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying CODE with the id: {id} with default information.");
                return Ok(await _ICodeRepository.GetCodeByIdDefaultAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // POST api/v{version:apiVersion}/code/
        [HttpPost]
        public async Task<IActionResult> AddCode([FromBody] Code NewCode)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Adding CODE with the id: {NewCode.CodeId}");
                var thing = await _ICodeRepository.CreateCodeAsync(NewCode);
                return Ok(new { Id = thing });
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // PUT api/v{version:apiVersion}/code/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode([FromBody] Code UpdateCode)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Successfully updated the code with the id: {UpdateCode.CodeId}.");
                await _ICodeRepository.UpdateCodeAsync(UpdateCode);
                return Ok(new { Id = UpdateCode.CodeId });       
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/v{version:apiVersion}/code/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeId(int id)
        {
            try
            {
                Code CodeToDelete = await _ICodeRepository.GetCodeByIdDefaultAsync(id);
                if(CodeToDelete == null)
                {
                    _Logger.LogWarn(ControllerContext, $"Code with id: {id}, hasn't been found in database.");
                    return NoContent();
                }
                await _ICodeRepository.DeleteCodeAsync(CodeToDelete);
                _Logger.LogInfo(ControllerContext, $"Querying CODE with the id: {id} to delete.");
                return NoContent();
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/code/count
        [HttpGet("count")]
        public async Task<IActionResult> GetCodeCount()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying the total number of codes.");
                return Ok(await _ICodeRepository.CountNumberOfCodesAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/v{version:apiVersion}/code
        [HttpGet]
        public async Task<IActionResult> GetCodes()
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying all CODES.");
                return Ok(await _ICodeRepository.GetAllCodesAsync());
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        // GET api/v{version:apiVersion}/code/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCodeId(int id)
        {
            try
            {
                _Logger.LogInfo(ControllerContext, $"Querying Account with the id: {id}.");
                return Ok(await _ICodeRepository.GetCodeByIdAsync(id));
            }
            catch(Exception ex)
            {
                _Logger.LogError(ControllerContext, $"Error Message: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}