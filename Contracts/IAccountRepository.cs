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
    public interface IAccountRepository : IGenericRepository<Account>
    {
        // Default Options
        Task<IEnumerable<Account>> GetAllAccountsDefaultAsync();
        Task<Account> GetAccountByIdDefaultAsync(int AccountId);
        Task<string> CreateAccountAsync(Account AccountToAdd);
        Task<string> UpdateAccountAsync(Account AccountToUpdate);
        Task<string> DeleteAccountAsync(Account AccountToDelete);
        Task<int> CountNumberOfAccountsAsync();

        // Project Specific
        Task<IEnumerable<object>> GetAllAccountsAsync();
        Task<object> GetAccountByIdAsync(int AccountId);
        Task<IEnumerable<Account>> GetAllAccountsByPlatformId(int id);
    }
}