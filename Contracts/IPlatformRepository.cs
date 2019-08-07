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
    public interface IPlatformRepository : IGenericRepository<Platform>
    {
        // Default Options
        Task<IEnumerable<Platform>> GetAllPlatformsDefaultAsync();
        Task<Platform> GetPlatformByIDDefaultAsync(int PlatformId);
        Task CreatePlatformAsync(Platform PlatformToAdd);
        Task UpdatePlatformAsync(Platform PlatformToUpdate);
        Task DeletePlatformAsync(Platform PlatformToDelete);
        Task<int> CountNumberOfPlatformsAsync();

        // Project Specific
        Task<IEnumerable<object>> GetAllPlatformsAsync();
        Task<IEnumerable<object>> GetAllPlatformsOnlyAsync();
        Task<object> GetPlatformByIdAsync(int PlatformId);
    }
}