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
    public class CodeRepository : GenericRepository<Code>, ICodeRepository
    {
        private readonly Context _Context;
        public CodeRepository(Context Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Code>> GetAllCodesDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Code> GetCodeByIdDefaultAsync(int CodeId)
        {
            return await FindByCondition(c => c.CodeId == CodeId).FirstOrDefaultAsync();
        }

        public async Task<int> CreateCodeAsync(Code CodeToAdd)
        {
            if(!FindAnyByCondition(c => (c.EmailAccountId == CodeToAdd.EmailAccountId && c.PlatformId == CodeToAdd.PlatformId && c.GameId == CodeToAdd.GameId)))
            {
                Create(CodeToAdd);
                await SaveAsync();
                return CodeToAdd.CodeId;
            }
            return 0;
        }

        public async Task<int> UpdateCodeAsync(Code CodeToUpdate)
        {
            if(!FindAnyByCondition(c => (c.EmailAccountId == CodeToUpdate.EmailAccountId && c.PlatformId == CodeToUpdate.PlatformId && c.GameId == CodeToUpdate.GameId)))
            {
                Update(CodeToUpdate);
                await SaveAsync();
                return CodeToUpdate.CodeId;
            }
            return 0;
        }

        public async Task<int> DeleteCodeAsync(Code CodeToDelete)
        {
            if(FindAnyByCondition(c => (c.EmailAccountId == CodeToDelete.EmailAccountId && c.PlatformId == CodeToDelete.PlatformId && c.GameId == CodeToDelete.GameId)))
            {
                Delete(CodeToDelete);
                await SaveAsync();
                return CodeToDelete.CodeId;
            }
            return 0;
        }

        public async Task<int> CountNumberOfCodesAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllCodesAsync()
        {
            return await GetAll().Include(c => c.Account).Include(c => c.Game).Select(c => new {
                Id = c.CodeId,
                Code = c.CodeString,
                Used = c.UsedStatus,
                Account = c.Account.Username,
                Game = c.Game.Name
            }).ToListAsync();
        }

        public async Task<object> GetCodeByIdAsync(int CodeId)
        {
            return await FindByCondition(c => c.CodeId == CodeId).Include(c => c.Account).Include(c => c.Game).Select(c => new {
                Id = c.CodeId,
                Code = c.CodeString,
                Used = c.UsedStatus,
                AccountId = c.Account.AccountId,
                Account = c.Account.Username,
                GameId = c.Game.GameId,
                Game = c.Game.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Code>> GetAllCodesByAccount(int EmailAccountId, int PlatformId)
        {
            return await FindByCondition(c => (c.EmailAccountId == EmailAccountId && c.PlatformId == PlatformId)).ToListAsync();
        }

        public bool DoesCodeExist(int id)
        {
            return FindAnyByCondition(c => c.CodeId == id);
        }
    }
}