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

namespace AccountAPI.Repositories
{
    public class PlatformRepository : GenericRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(Context Context) : base(Context)
        {

        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Platform> GetPlatformByIDDefaultAsync(int PlatformId)
        {
            return await FindByCondition(a => a.PlatformId == PlatformId).FirstOrDefaultAsync();
        }

        public async Task CreatePlatformAsync(Platform PlatformToAdd)
        {
            Create(PlatformToAdd);
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

        public async Task<IEnumerable<object>> GetAllPlatformsAsync()
        {
            return await GetAll().Include(p => p.Games).Select(p => new PlatformDTO()
            {
                PlatformId = p.PlatformId,
                Name = p.Name,
                Games = p.Games.Select(g => new PlatformGameDTO()
                {
                    Name = g.Name
                })
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllPlatformsOnlyAsync()
        {
            return await GetAll().Select(p => new {
                PlatformID = p.PlatformId,
                Platform = p.Name
            }).ToListAsync();
        }

        public async Task<object> GetPlatformByIdAsync(int PlatformId)
        {
            return await FindByCondition(p => p.PlatformId == PlatformId).Include(p => p.Games).Include(p => p.Accounts).Select(p => new {
                Id = p.PlatformId,
                Name = p.Name,
                URLToDocumentation = p.URLToDocumentation,
                Games = p.Games.Select(g => new {
                    Id = g.GameId,
                    Name = g.Name,
                }),
                Accounts = p.Accounts.Select(a => new {
                    Id = a.AccountId,
                    Username = a.Username
                })
            }).FirstOrDefaultAsync();
        }
    }
}