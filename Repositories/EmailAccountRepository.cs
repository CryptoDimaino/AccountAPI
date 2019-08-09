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
    public class EmailAccountRepository : GenericRepository<EmailAccount>, IEmailAccountRepository
    {
        private readonly Context _Context;
        private readonly IAccountRepository _IAccountRepository;
        public EmailAccountRepository(Context Context, IAccountRepository IAccountRepository) : base(Context)
        {
            _IAccountRepository = IAccountRepository;
            _Context = Context;
        }

        public async Task<IEnumerable<EmailAccount>> GetAllEmailAccountsDefaultAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<EmailAccount> GetEmailAccountByIdDefaultAsync(int EmailAccountId)
        {
            return await FindByCondition(g => g.EmailAccountId == EmailAccountId).FirstOrDefaultAsync();
        }

        public async Task CreateEmailAccountAsync(EmailAccount EmailAccountToAdd)
        {
            if(!FindAnyByCondition(ea => ea.Email == EmailAccountToAdd.Email))
            {
                Create(EmailAccountToAdd);
                await SaveAsync();
            }
        }

        public async Task UpdateEmailAccountAsync(EmailAccount EmailAccountToUpdate)
        {
            Update(EmailAccountToUpdate);
            await SaveAsync();
        }

        public async Task<string> DeleteEmailAccountAsync(EmailAccount EmailAccountToDelete)
        {
            string AccountIdsToDelete = "";
            var AccountListToDelete = _Context.Accounts.Where(a => a.EmailAccountId == EmailAccountToDelete.EmailAccountId);
            foreach(var account in AccountListToDelete)
            {
                AccountIdsToDelete += $"Account id: {account.AccountId} Code ids: {await _IAccountRepository.DeleteAccountAsync(account)},";
            }
            Delete(EmailAccountToDelete);
            await SaveAsync();
            return AccountIdsToDelete;
        }

        public async Task<int> CountNumberOfEmailAccountsAsync()
        {
            return await CountAsync();
        }

        public async Task<IEnumerable<object>> GetAllEmailAccountsAsync()
        {
            return await GetAll().Select(ea => new
            {
                Id = ea.EmailAccountId,
                Email = ea.Email,
                Password = ea.EmailPassword
            }).ToListAsync();
        }

        public async Task<object> GetEmailAccountByIdAsync(int EmailAccountId)
        {
            return await FindByCondition(ea => ea.EmailAccountId == EmailAccountId).Include(ea => ea.Accounts).Select(ea => new 
            {
                Id = ea.EmailAccountId,
                Email = ea.Email,
                Password = ea.EmailPassword,
                Accounts = ea.Accounts.Select(a => new {
                    AccountId = a.AccountId,
                    Username = a.Username,
                    UserPassword = a.Password
                })
            }).FirstOrDefaultAsync();
        }
    }
}