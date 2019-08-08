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
        public AccountRepository(Context Context) : base(Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Account> GetAccountByIdDefaultAsync(int AccountId)
        {
            return await FindByCondition(a => a.AccountId == AccountId).FirstOrDefaultAsync();
        }

        public async Task CreateAccountAsync(Account AccountToAdd)
        {
            Create(AccountToAdd);
            await SaveAsync();
        }

        public async Task UpdateAccountAsync(Account AccountToUpdate)
        {
            Update(AccountToUpdate);
            await SaveAsync();
        }

        public async Task<string> DeleteAccountAsync(Account AccountToDelete)
        {
            string codeIdsToDelete = "";
            var CodeListToDelete = _Context.Codes.Where(c => (c.EmailAccountId == AccountToDelete.EmailAccountId && c.PlatformId == AccountToDelete.PlatformId));
            foreach(var code in CodeListToDelete)
            {
                codeIdsToDelete += $" {code.CodeId}";
            }
            _Context.Codes.RemoveRange(CodeListToDelete);
            Delete(AccountToDelete);
            await SaveAsync();
            return codeIdsToDelete;
        }

        public async Task<int> CountNumberOfAccountsAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllAccountsAsync()
        {
            return await GetAll().Include(a => a.EmailAccount).Include(a => a.Platform).Include(a => a.Event).Include(a => a.Codes).Select(a => new 
            {
                Id = a.AccountId,
                Username = a.Username,
                Password = a.Password,
                Email = a.EmailAccount.Email,
                EmailPassword = a.EmailAccount.EmailPassword,
                Platform = a.Platform.Name,
                Event = a.Event.Name
                // Codes = a.Codes.Select(c => new {
                //     Code = CodeString
                // })
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
    }
}