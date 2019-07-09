using AccountAPI.Models;
using AccountAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(Context Context) : base(Context)
        {

        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await GetAll().Include(p => p.Games).ToListAsync();
        }

        public async Task<Platform> GetPlatformByIDAsync(int PlatformId)
        {
            return await FindByCondition(a => a.PlatformId == PlatformId).FirstOrDefaultAsync();
        }

        public async Task<Platform> GetPlatformByNameAsync(string Name)
        {
            return await FindByCondition(a => a.Name == Name).FirstOrDefaultAsync();
        }

        public async Task CreatePlatformAsync(Platform NewPlatform)
        {
            Create(NewPlatform);
            await SaveAsync();
        }

        public async Task UpdatePlatformAsync(Platform PlatformToUpdate)
        {
            Update(PlatformToUpdate);
            await SaveAsync();
        }

        public async Task DeletePlatformAsync(Platform PlatformToDelete)
        {
            Delete(PlatformToDelete);
            await SaveAsync();
        }

        public async Task<int> CountNumberOfPlatformsAsync()
        {
            return await CountAsync();
        }
    }
}