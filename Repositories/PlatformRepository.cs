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
        private readonly IGameRepository _IGameRepository;
        private readonly IAccountRepository _IAccountRepository;
        public PlatformRepository(Context Context, IGameRepository IGameRepository, IAccountRepository IAccountRepository) : base(Context)
        {
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

        public async Task<int> UpdatePlatformAsync(Platform PlatformToUpdate)
        {
            if(FindAnyByCondition(p => p.PlatformId == PlatformToUpdate.PlatformId))
            {
                Update(PlatformToUpdate);
                await SaveAsync();
                return PlatformToUpdate.PlatformId;
            }
            return 0;
        }

        public async Task<int> DeletePlatformAsync(Platform PlatformToDelete)
        {
            if(FindAnyByCondition(p => p.PlatformId == PlatformToDelete.PlatformId))
            {
                var Accounts = await _IAccountRepository.GetAllAccountsByPlatformId(PlatformToDelete.PlatformId);
                foreach(var account in Accounts)
                {
                    await _IAccountRepository.DeleteAccountAsync(account);
                }

                var Games = await _IGameRepository.GetAllGamesByPlatformId(PlatformToDelete.PlatformId);
                foreach(var game in Games)
                {
                    await _IGameRepository.DeleteGameAsync(game);
                }
                Delete(PlatformToDelete);
                await SaveAsync();
                return PlatformToDelete.PlatformId;
            }
            return 0;
            
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