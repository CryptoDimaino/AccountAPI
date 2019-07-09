using AccountAPI.Models;
using AccountAPI.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(Context Context) : base(Context)
        {

        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await GetAll().Include(a => a.GameAccounts).Include(p => p.Platform).ToListAsync();
        }

        public async Task<Account> GetAccountByIDAsync(int AccountId)
        {
            return await FindByCondition(a => a.AccountId == AccountId).FirstOrDefaultAsync();
        }

        public async Task<Account> GetAccountByNameAsync(string Name)
        {
            return await FindByCondition(a => a.Name == Name).FirstOrDefaultAsync();
        }

        public async Task CreateAccountAsync(Account NewAccount)
        {
            Create(NewAccount);
            await SaveAsync();
        }

        public async Task UpdateAccountAsync(Account AccountToUpdate)
        {
            Update(AccountToUpdate);
            await SaveAsync();
        }

        public async Task DeleteAccountAsync(Account AccountToDelete)
        {
            Delete(AccountToDelete);
            await SaveAsync();
        }

        public async Task<int> CountNumberOfAccountsAsync()
        {
            return await CountAsync();
        }
    }
}