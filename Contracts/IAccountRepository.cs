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
        Task<IEnumerable<AccountsDTO>> GetAllAccountsAsync();
        Task<Account> GetAccountByIDAsync(int AccountId);
        Task<Account> GetAccountByNameAsync(string Name);
        Task CreateAccountAsync(Account NewAccount);
        Task UpdateAccountAsync(Account AccountToUpdate);
        Task DeleteAccountAsync(Account AccountToDelete);
        Task<int> CountNumberOfAccountsAsync();

        Task<IEnumerable<AccountDTO>> GetAllAccountDTOAsync();
    }
}