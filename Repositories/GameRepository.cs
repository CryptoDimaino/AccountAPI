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
        private readonly Context _Context;
        public GameRepository(Context Context) : base(Context)
        {
            _Context = Context;
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
            // If the game name doesn't exist with the platform create a new game.
            if(!FindAnyByCondition(g => g.Name == GameToAdd.Name && g.PlatformId == GameToAdd.PlatformId))
            {
                Create(GameToAdd);
                await SaveAsync();
                return GameToAdd.GameId;
            }
            return 0;
        }

        public async Task<int> UpdateGameAsync(int id, Game GameToUpdate)
        {
            // Checks to make sure GameId exists.
            if(FindAnyByCondition(g => g.GameId == GameToUpdate.GameId))
            {
                // Pulls game with the id provided to be able to check if accounts exists and the PlatformId
                var game = await FindByCondition(g => g.GameId == id).Include(g => g.Codes).ThenInclude(c => c.Account).Select(g => new {
                    Id = g.GameId,
                    PlatformId = g.PlatformId,
                    NumberOfAccounts = g.Codes.Count()
                }).FirstOrDefaultAsync();

                // Checks if the edit is trying to change the platform and if accounts exist
                if(game.PlatformId != GameToUpdate.PlatformId && game.NumberOfAccounts > 0)
                {
                    return 1;
                }
                else
                {
                    Update(GameToUpdate);
                    await SaveAsync();
                    return GameToUpdate.GameId;   
                }
            }
            return 0;
        }

        public async Task<int> DeleteGameAsync(Game GameToDelete)
        {
            if(_Context.Codes.Any(c => c.GameId == GameToDelete.GameId))
            {
                return 0;
            }
            Delete(GameToDelete);
            await SaveAsync();
            return GameToDelete.GameId;
        }


        public async Task DeleteGameAndCodesAsync(Game GameToDelete)
        {
            var CodesList = await _Context.Codes.Where(c => c.GameId == GameToDelete.GameId).ToListAsync();
            _Context.Codes.RemoveRange(CodesList);
            Delete(GameToDelete);
            await SaveAsync();
        }

        // Counts the number of games
        public async Task<int> CountNumberOfGamesAsync()
        {
            return await CountAsync();
        }

        // Returns an object of all games with specific properties
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

        // Returns a game with specific properties and inclues all accounts and codes
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