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

        public async Task<Game> GetGameByIDDefaultAsync(int GameId)
        {
            return await FindByCondition(g => g.GameId == GameId).FirstOrDefaultAsync();
        }

        public async Task CreateGameAsync(Game GameToAdd)
        {
            Create(GameToAdd);
            await SaveAsync();
        }

        public async Task UpdateGameAsync(Game GameToUpdate)
        {
            Update(GameToUpdate);
            await SaveAsync();
        }

        public async Task DeleteGameAsync(Game GameToDelete)
        {
            Delete(GameToDelete);
            await SaveAsync();
        }
        public async Task<int> CountNumberOfGamesAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<GamesDTO>> GetAllGamesAsync()
        {
            return await GetAll().Include(g => g.Platform).Include(g => g.Codes).ThenInclude(c => c.Account).Select(g => new GamesDTO()
            {
                GameId = g.GameId,
                GameTitle = g.Name,
                PlatformName = g.Platform.Name,
                NumberOfAccounts = g.Codes.Count()
            }).ToListAsync();
        }

        public async Task<object> GetGameByIDAsync(int GameId)
        {
            return await FindByCondition(g => g.GameId == GameId).Include(g => g.Platform).Include(g => g.Codes).ThenInclude(c => c.Account).ThenInclude(a => a.EmailAccount).Select(g => new 
            {
                GameId = g.GameId,
                GameTitle = g.Name,
                PlatformName = g.Platform.Name,
                ReleaseDate = g.ReleaseDate,
                URLToDocumentation = g.URLToDocumentation,
                Accounts = g.Codes.Select(c => new
                {
                    CodeString = c.CodeString,
                    AccountId = c.Account.AccountId,
                    Username = c.Account.Username,
                    Password = c.Account.Password,
                    Email = c.Account.EmailAccount.Email,
                    EmailPassword = c.Account.EmailAccount.EmailPassword
                })
            }).FirstOrDefaultAsync();
        }
    }
}