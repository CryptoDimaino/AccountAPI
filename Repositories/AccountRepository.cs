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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ICodeRepository _ICodeRepository;
        public AccountRepository(Context Context, ICodeRepository ICodeRepository) : base(Context)
        {
            _ICodeRepository = ICodeRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsDefaultAsync()
        {
            return await GetAll().OrderBy(a => a.AccountId).ToListAsync();
        }

        public async Task<Account> GetAccountByIdDefaultAsync(int AccountId)
        {
            return await FindByCondition(a => a.AccountId == AccountId).FirstOrDefaultAsync();
        }

        public async Task<int> CreateAccountAsync(Account AccountToAdd)
        {
            if(!FindAnyByCondition(a => (a.EmailAccountId == AccountToAdd.EmailAccountId && a.PlatformId == AccountToAdd.PlatformId)))
            {
                AccountToAdd.AccountId = GetNextAccountId() + 1;
                Create(AccountToAdd);
                await SaveAsync();
                return AccountToAdd.AccountId;
            }
            return 0;
        }

        public async Task<int> UpdateAccountAsync(Account AccountToUpdate)
        {
            if(FindAnyByCondition(a => a.AccountId == AccountToUpdate.AccountId))
            {
                Update(AccountToUpdate);
                await SaveAsync();
                return AccountToUpdate.AccountId;
            }
            return 0;
        }

        public async Task<int> DeleteAccountAsync(Account AccountToDelete)
        {
            if(FindAnyByCondition(a => a.AccountId == AccountToDelete.AccountId))
            {
                var CodeL = await _ICodeRepository.GetAllCodesByAccount((int)AccountToDelete.EmailAccountId, (int)AccountToDelete.PlatformId);
                foreach(var code in CodeL)
                {
                    await _ICodeRepository.DeleteCodeAsync(code);
                }
                Delete(AccountToDelete);
                await SaveAsync();
                return AccountToDelete.AccountId;
            }
            return 0;
        }

        public async Task<int> CountNumberOfAccountsAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllAccountsAsync()
        {
            return await GetAll().Include(a => a.EmailAccount).Include(a => a.Platform).Include(a => a.Event).Include(a => a.Codes).OrderBy(a => a.AccountId)
            .Select(a => new 
            {
                Id = a.AccountId,
                Username = a.Username,
                Password = a.Password,
                Email = a.EmailAccount.Email,
                EmailPassword = a.EmailAccount.EmailPassword,
                Platform = a.Platform.Name,
                Event = a.Event.Name
            }).ToListAsync();
        }

        public async Task<object> GetAccountByIdAsync(int AccountId)
        {
            return await FindByCondition(a => a.AccountId == AccountId).Include(a => a.EmailAccount).Include(a => a.Platform).Include(a => a.Event).Include(a => a.Codes).Select(a => new 
            {
                Id = a.AccountId,
                Username = a.Username,
                Password = a.Password,
                Email = a.EmailAccount.Email,
                EmailPassword = a.EmailAccount.EmailPassword,
                Platform = a.Platform.Name,
                Event = a.Event.Name,
                Codes = a.Codes.Select(c => new {
                    Code = c.CodeString
                })
            }).FirstOrDefaultAsync();
        }

        public int GetNextAccountId()
        {
            return GetAll().Max(a => a.AccountId);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsByPlatformId(int id)
        {
            return await FindByCondition(a => a.PlatformId == id).OrderBy(a => a.AccountId).ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsByEmailAccountId(int id)
        {
            return await FindByCondition(a => a.EmailAccountId == id).OrderBy(a => a.AccountId).ToListAsync();
        }

        public bool DoesAccountExist(int id)
        {
            return FindAnyByCondition(a => a.AccountId == id);
        }
    }
}