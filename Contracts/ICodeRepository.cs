using AccountAPI.Models;
using AccountAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccountAPI.DTOs;

namespace AccountAPI.Contracts
{
    public interface ICodeRepository : IGenericRepository<Code>
    {
        // Default Options
        Task<IEnumerable<Code>> GetAllCodesDefaultAsync();
        Task<Code> GetCodeByIdDefaultAsync(int CodeId);
        Task<int> CreateCodeAsync(Code CodeToAdd);
        Task UpdateCodeAsync(Code CodeToUpdate);
        Task DeleteCodeAsync(Code CodeToDelete);
        Task<int> CountNumberOfCodesAsync();

        // Project Specific
        Task<IEnumerable<object>> GetAllCodesAsync();
        Task<object> GetCodeByIdAsync(int CodeId);
    }
}