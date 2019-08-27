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
        private readonly Context _Context;
        private readonly ICodeRepository _ICodeRepository;
        public AccountRepository(Context Context, ICodeRepository ICodeRepository) : base(Context)
        {
            _Context = Context;
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
            if(_Context.Codes.Any(c => (c.PlatformId == AccountToDelete.PlatformId && c.EmailAccountId == AccountToDelete.EmailAccountId)))
            {
                return 0;
            }
            else if(_Context.Accounts.Any(a => a.EventId == AccountToDelete.EventId) && AccountToDelete.EventId != null)
            // else if(AccountToDelete.EventId != null)
            {
                return -1;
            }
            Delete(AccountToDelete);
            await SaveAsync();
            return AccountToDelete.AccountId;
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
            return await FindByCondition(a => a.AccountId == AccountId).Include(a => a.Codes).Include(a => a.EmailAccount).Include(a => a.Platform).Include(a => a.Event).Select(a => new 
            {
                Id = a.AccountId,
                Username = a.Username,
                Password = a.Password,
                Email = a.EmailAccount.Email,
                EmailPassword = a.EmailAccount.EmailPassword,
                PlatformId = a.Platform.PlatformId,
                Platform = a.Platform.Name,
                EventId = (int?)a.Event.EventId,
                Event = a.Event.Name,
                Codes = a.Codes.Select(c => new {
                    CodeId = c.CodeId,
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

        // public bool DoesAccountExistIds(int PlatformId, int EmailAccountId)
        // {
        //     return FindAnyByCondition(a => a.PlatformId == PlatformId, );
        // }

        public async Task<IEnumerable<AccountPlatform>> AccountsAndPlatforms()
        {
            return await GetAll().Select(a => new AccountPlatform {
                PlatformId = (int)a.PlatformId,
                EmailAccountId = (int)a.EmailAccountId
            }).ToListAsync();
        }
    }
}