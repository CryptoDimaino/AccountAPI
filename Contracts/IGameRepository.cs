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
        Task<IEnumerable<GamesDTO>> GetAllGamesAsync();
        Task<object> GetGameByIDAsync(int GameId);
        Task DeleteGameAsync(Game GameToDelete);
        Task<Game> DefaultGetGameByIDAsync(int GameId);
        Task AddGameAsync(Game GameToAdd);
    }
}