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
        private readonly Context _Context;
        private readonly IGameRepository _IGameRepository;
        private readonly IAccountRepository _IAccountRepository;
        public PlatformRepository(Context Context, IGameRepository IGameRepository, IAccountRepository IAccountRepository) : base(Context)
        {
            _Context = Context;
            _IGameRepository = IGameRepository;
            _IAccountRepository = IAccountRepository;
        }

        public async Task<IEnumerable<Platform>> GetAllPlatformsDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Platform> GetPlatformByIDDefaultAsync(int PlatformId)
        {
            return await FindByCondition(a => a.PlatformId == PlatformId).FirstOrDefaultAsync();
        }

        public async Task<int> CreatePlatformAsync(Platform PlatformToAdd)
        {
            if(!FindAnyByCondition(p => p.Name == PlatformToAdd.Name))
            {
                Create(PlatformToAdd);
                await SaveAsync();
                return PlatformToAdd.PlatformId;
            }
            return 0;
        }

        public async Task<int> UpdatePlatformAsync(int id, Platform PlatformToUpdate)
        {
            if(FindAnyByCondition(p => p.PlatformId == PlatformToUpdate.PlatformId))
            {
                if(FindAnyByCondition(p => p.Name == PlatformToUpdate.Name && p.PlatformId != PlatformToUpdate.PlatformId))
                {
                    return -2;
                }
                if((_Context.Accounts.Any(a => a.PlatformId == PlatformToUpdate.PlatformId) ||  _Context.Games.Any(g => g.PlatformId == PlatformToUpdate.PlatformId)))
                {
                    // Get platform and see if id and name are then same if they are save.
                    if(_Context.Platforms.Any(p => p.PlatformId == PlatformToUpdate.PlatformId && p.Name == PlatformToUpdate.Name))
                    {
                        Update(PlatformToUpdate);
                        await SaveAsync();
                        return PlatformToUpdate.PlatformId;
                    }
                    return -1;
                }
                Update(PlatformToUpdate);
                await SaveAsync();
                return PlatformToUpdate.PlatformId;
            }
            return 0;
        }

        public async Task<int> DeletePlatformAsync(Platform PlatformToDelete)
        {
            if(_Context.Games.Any(g => g.PlatformId == PlatformToDelete.PlatformId) || _Context.Accounts.Any(a => a.PlatformId == PlatformToDelete.PlatformId))
            {
                return 0;
            }
            Delete(PlatformToDelete);
            await SaveAsync();
            return PlatformToDelete.PlatformId;
        }

        public async Task<int> CountNumberOfPlatformsAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllPlatformsAsync()
        {
            return await GetAll().Include(p => p.Games).Select(p => new
            {
                Id = p.PlatformId,
                Platform = p.Name,
                GameCount = p.Games.Count()
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetAllPlatformsOnlyAsync()
        {
            return await GetAll().Select(p => new {
                Id = p.PlatformId,
                Platform = p.Name
            }).ToListAsync();
        }

        public async Task<object> GetPlatformByIdAsync(int PlatformId)
        {
            return await FindByCondition(p => p.PlatformId == PlatformId).Include(p => p.Games).Include(p => p.Accounts).Select(p => new {
                Id = p.PlatformId,
                Name = p.Name,
                URLToDocumentation = p.URLToDocumentation,
                p.CreatedAt,
                p.UpdatedAt,
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

        public bool DoesPlatformExist(int id)
        {
            return FindAnyByCondition(p => p.PlatformId == id);
        }
    }
}