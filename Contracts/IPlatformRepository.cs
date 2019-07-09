 using AccountAPI.Models;
using AccountAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
// using AccountAPI.DTOs;

namespace AccountAPI.Contracts
{
    public interface IPlatformRepository : IGenericRepository<Platform>
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIDAsync(int PlatformId);
        Task<Platform> GetPlatformByNameAsync(string Name);
        Task CreatePlatformAsync(Platform NewPlatform);
        Task UpdatePlatformAsync(Platform PlatformToUpdate);
        Task DeletePlatformAsync(Platform PlatformToDelete);
        Task<int> CountNumberOfPlatformsAsync();
    }
}