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
    public interface IGameRepository : IGenericRepository<Game>
    {
        // Default Options
        Task<IEnumerable<Game>> GetAllGamesDefaultAsync();
        Task<Game> GetGameByIdDefaultAsync(int GameId);
        Task<int> CreateGameAsync(Game GameToAdd);
        Task<int> UpdateGameAsync(Game GameToUpdate);
        Task<int> DeleteGameAsync(Game GameToDelete);
        Task<int> CountNumberOfGamesAsync();

        // Project Specific
        Task<IEnumerable<object>> GetAllGamesAsync();
        Task<object> GetGameByIdAsync(int GameId);
        Task<IEnumerable<Game>> GetAllGamesByPlatformId(int id);
    }
}