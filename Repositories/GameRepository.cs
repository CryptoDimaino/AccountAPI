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
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(Context Context) : base(Context)
        {

        }

        public async Task<IEnumerable<Game>> GetAllGamesDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Game> GetGameByIdDefaultAsync(int GameId)
        {
            return await FindByCondition(g => g.GameId == GameId).FirstOrDefaultAsync();
        }

        public async Task<int> CreateGameAsync(Game GameToAdd)
        {
            if(!FindAnyByCondition(g => g.Name == GameToAdd.Name && g.PlatformId == GameToAdd.PlatformId))
            {
                Create(GameToAdd);
                await SaveAsync();
                return GameToAdd.GameId;
            }
            return 0;
        }

        public async Task<int> UpdateGameAsync(Game GameToUpdate)
        {
            if(FindAnyByCondition(g => g.GameId == GameToUpdate.GameId))
            {
                Update(GameToUpdate);
                await SaveAsync();
                return GameToUpdate.GameId;
            }
            return 0;
        }

        public async Task<int> DeleteGameAsync(Game GameToDelete)
        {
            if(FindAnyByCondition(g => g.GameId == GameToDelete.GameId))
            {
                Delete(GameToDelete);
                await SaveAsync();
                return GameToDelete.GameId;
            }
            return 0;
        }
        public async Task<int> CountNumberOfGamesAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllGamesAsync()
        {
            return await GetAll().Include(g => g.Platform).Include(g => g.Codes).ThenInclude(c => c.Account).OrderBy(g => g.GameId).Select(g => new
            {
                Id = g.GameId,
                Title = g.Name,
                Platform = g.Platform.Name,
                NumberOfAccounts = g.Codes.Count()
            }).ToListAsync();
        }

        public async Task<object> GetGameByIdAsync(int GameId)
        {
            return await FindByCondition(g => g.GameId == GameId).Include(g => g.Platform).Include(g => g.Codes).ThenInclude(c => c.Account).ThenInclude(a => a.EmailAccount).Select(g => new 
            {
                Id = g.GameId,
                Title = g.Name,
                Platform = g.Platform.Name,
                ReleaseDate = g.ReleaseDate,
                URLToDocumentation = g.URLToDocumentation,
                Accounts = g.Codes.Select(c => new
                {
                    CodeId = c.CodeId,
                    Code = c.CodeString,
                    Id = (int?)c.Account.AccountId,
                    Username = c.Account.Username,
                    Password = c.Account.Password,
                    Email = c.Account.EmailAccount.Email,
                    EmailPassword = c.Account.EmailAccount.EmailPassword
                })
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetAllGamesByPlatformId(int id)
        {
            return await FindByCondition(g => g.PlatformId == id).ToListAsync();
        }

        public bool DoesGameExist(int id)
        {
            return FindAnyByCondition(a => a.GameId == id);
        }
    }
}